using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicPlayer.Database;
using MusicPlayer.Database.Entity;
using MusicPlayer.Model;
using MusicPlayer.MusicApi;
using MusicPlayer.Properties;
using MusicPlayer.UC;
using NAudio.Wave;

namespace MusicPlayer
{
    public partial class MusicPlayerForm : Form
    {
        private UC_CurrentSong _ucCurrentSong;
        private UC_Home _ucHome;
        private UC_NewRelease _ucNewRelease;
        public UC_Playlist _ucPlaylist;
        private UC_Search _ucSearch;
        private UC_Trending _ucTrending;


        private ZingMp3Api api;
        public Album currentAlbum;
        public Music currentMusic;
        public int currentSongIndex;

        // database
        public MusicDbContext dbContext;
        public List<Music> musicList = new List<Music>();
        public List<Music> loveMusicList = new List<Music>();

        private MediaFoundationReader reader;

        // using semaphore to avoid multiple thread access to waveOut and currentMusic, currentSongIndex
        public Semaphore Semaphore = new Semaphore(2, 2);
        private Thread streamingThread;

        public User user;
        public WaveOutEvent waveOut = new WaveOutEvent();

        public MusicPlayerForm()
        {
            InitializeComponent();
        }

        public MusicPlayerForm(int userId)
        {
            InitializeComponent();
            dbContext = new MusicDbContext();
            user = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
        }

        private async void MusicPlayerForm_Load(object sender, EventArgs e)
        {
            api = new ZingMp3Api(this);

            musicList = new List<Music>();
            currentMusic = null;
            repeatBtn.Checked = true;

            _ucHome = new UC_Home();
            var homeData = await api.GetHomeData();
            _ucHome.homeData = homeData;

            _ucTrending = new UC_Trending(await api.GetTrendingData());

            _ucNewRelease = new UC_NewRelease(await api.GetNewReleaseData());

            _ucCurrentSong = new UC_CurrentSong();
            _ucSearch = new UC_Search();
            _ucPlaylist = new UC_Playlist();
            _ucPlaylist.mainForm = this;

            api.WaitForm.Show();

            AddUserControl(_ucHome);
            AddUserControl(_ucTrending);
            AddUserControl(_ucNewRelease);
            AddUserControl(_ucSearch);
            AddUserControl(_ucCurrentSong);
            AddUserControl(_ucPlaylist);

            api.WaitForm.Hide();

            homeBtn_Click(sender, e);
        }

        public void PlayMusic()
        {
            if (waveOut == null)
            {
                LoadSongData();
                LoadStreaming();
                ShowPlayButton();
            }
            else if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Pause();
                ShowPlayButton();
            }
            else if (waveOut.PlaybackState == PlaybackState.Stopped)
            {
                if (streamingThread != null) streamingThread.Abort();
                LoadSongData();
                LoadStreaming();
                ShowPauseButton();
            }
            else if (waveOut.PlaybackState == PlaybackState.Paused)
            {
                waveOut.Play();
                ShowPauseButton();
            }
        }

        private void LoadSongData()
        {
            songTitle.Text = currentMusic.Title;
            artistsName.Text = currentMusic.Artists;
            // genreLabel.Text = currentMusic.Genres;
            // composerLabel.Text = currentMusic.Composers;
            // this.thumbnail.Load(currentMusic.ThumbnailM);
            var thread = new Thread(() =>
            {
                Invoke(new MethodInvoker(delegate
                {
                    // if connection is lost thumbnail will try load again every 3 seconds
                    var isLoaded = false;
                    do
                    {
                        try
                        {
                            thumbnailImage.Load(currentMusic.ThumbnailM);
                            isLoaded = true;
                        }
                        catch
                        {
                            MessageBox.Show("Vui lòng kiểm tra lại kết nối mạng", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } while (!isLoaded);
                }));
            });
            thread.Start();
        }

        private async void LoadStreaming()
        {
            // reset track bar
            // disable previous and next button
            prevBtn.Enabled = false;
            nextBtn.Enabled = false;
            musicTrackBar.Value = 0;
            musicTrackBar.Maximum = 1;
            // reset time label
            currentTime.Text = "00:00";
            endTime.Text = "00:00";

            var streaming = await api.GetStreamingUrl(currentMusic.Id);

            Semaphore.WaitOne();
            reader = new MediaFoundationReader(streaming);
            if (waveOut == null)
            {
                waveOut = new WaveOutEvent();
            }
            else
            {
                waveOut.Stop();
                waveOut.Dispose();
            }

            waveOut.Init(reader);
            Semaphore.Release();

            streamingThread = new Thread(() =>
            {
                waveOut.Play();

                while (waveOut.PlaybackState == PlaybackState.Playing
                       || waveOut.PlaybackState == PlaybackState.Paused)
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        musicTrackBar.Maximum = (int)reader.TotalTime.TotalSeconds;
                        musicTrackBar.Value = (int)reader.CurrentTime.TotalSeconds;
                        currentTime.Text = reader.CurrentTime.ToString("mm\\:ss");
                        endTime.Text = reader.TotalTime.ToString("mm\\:ss");
                    }));
                    Thread.Sleep(1000);
                }

                // Load next song
                if (repeatBtn.Checked)
                {
                    Semaphore.WaitOne();
                    currentSongIndex++;
                    if (shuffleBtn.Checked)
                    {
                        var random = new Random();
                        currentSongIndex = random.Next(0, musicList.Count);
                    }

                    if (currentSongIndex >= musicList.Count) currentSongIndex = 0;
                    Semaphore.Release();

                    currentMusic = musicList[currentSongIndex];
                    // load data and streaming at main thread
                    waveOut.Stop();
                    Invoke(new MethodInvoker(delegate { PlayMusic(); }));
                }
            });
            streamingThread.Start();
            // enable previous and next button
            prevBtn.Enabled = true;
            nextBtn.Enabled = true;
        }

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            userControl.Width = containerPanel.Width;
            containerPanel.Controls.Add(userControl);
            // go to flow panel in user control and set width to container panel width

            foreach (Control control in userControl.Controls)
                if (control is FlowLayoutPanel)
                {
                    control.Width = containerPanel.Width;
                    foreach (Control c in control.Controls)
                        // subtract 30 to avoid horizontal scroll bar
                        c.Width = control.Width - 30;
                    break;
                }
        }

        private void UncheckAllButton()
        {
            homeBtn.Checked = false;
            trendingBtn.Checked = false;
            releaseBtn.Checked = false;
            searchPageBtn.Checked = false;
            // songBtn.Checked = false;
            playListBtn.Checked = false;

            _ucHome.Visible = false;
            _ucTrending.Visible = false;
            _ucNewRelease.Visible = false;
            _ucSearch.Visible = false;
            _ucCurrentSong.Visible = false;
            _ucPlaylist.Visible = false;
        }

        private async void homeBtn_Click(object sender, EventArgs e)
        {
            if (_ucHome == null)
            {
                _ucHome = new UC_Home();
                _ucHome.homeData = await api.GetHomeData();
            }

            UncheckAllButton();
            homeBtn.Checked = true;
            _ucHome.Visible = true;
        }

        private async void trendingBtn_Click(object sender, EventArgs e)
        {
            if (_ucTrending == null)
            {
                var data = await api.GetTrendingData();

                _ucTrending = new UC_Trending(data);
            }

            UncheckAllButton();
            trendingBtn.Checked = true;
            _ucTrending.Visible = true;
        }

        private async void releaseBtn_Click(object sender, EventArgs e)
        {
            if (_ucNewRelease == null)
            {
                var data = await api.GetNewReleaseData();
                _ucNewRelease = new UC_NewRelease(data);
            }

            UncheckAllButton();
            releaseBtn.Checked = true;
            _ucNewRelease.Visible = true;
        }

        private void searchPageBtn_Click(object sender, EventArgs e)
        {
            UncheckAllButton();
            if (_ucSearch == null) _ucSearch = new UC_Search();
            searchPageBtn.Checked = true;
            _ucSearch.Visible = true;
        }

        private void songBtn_Click(object sender, EventArgs e)
        {
            UncheckAllButton();
            if (_ucCurrentSong == null) _ucCurrentSong = new UC_CurrentSong();
            // songBtn.Checked = true;
            _ucCurrentSong.Visible = true;
            _ucCurrentSong.LoadData();
        }

        private void currentListBtn_Click(object sender, EventArgs e)
        {
            if (_ucPlaylist == null) _ucPlaylist = new UC_Playlist();
            UncheckAllButton();
            playListBtn.Checked = true;
            _ucPlaylist.Visible = true;
        }

        private void btnExitMainForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // exit all thread
            Environment.Exit(0);
        }

        private void repeatBtn_Click(object sender, EventArgs e)
        {
            repeatBtn.Checked = !repeatBtn.Checked;
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (currentMusic == null) return;
            currentSongIndex--;
            if (currentSongIndex < 0) currentSongIndex = musicList.Count - 1;
            if (shuffleBtn.Checked)
            {
                var random = new Random();
                currentSongIndex = random.Next(0, currentSongIndex + 1);
            }

            currentMusic = musicList[currentSongIndex];
            Semaphore.WaitOne();
            if (waveOut.PlaybackState != PlaybackState.Stopped) waveOut.Stop();
            Semaphore.Release();
            PlayMusic();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (currentMusic == null) return;
            currentSongIndex++;
            if (currentSongIndex >= musicList.Count) currentSongIndex = 0;
            if (shuffleBtn.Checked)
            {
                var random = new Random();
                // [currentSongIndex, musicList.Count)
                currentSongIndex = random.Next(0, musicList.Count - currentSongIndex) + currentSongIndex;
            }

            currentMusic = musicList[currentSongIndex];
            Semaphore.WaitOne();
            if (waveOut.PlaybackState != PlaybackState.Stopped) waveOut.Stop();
            Semaphore.Release();
            PlayMusic();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (currentMusic == null) return;
            ShowPlayButton();
            PlayMusic();
        }

        private void ShowPlayButton()
        {
            playBtn.Image = Resources.play_100px;
            playBtn.HoverState.Image = Resources.play_100px_png1;
        }

        private void ShowPauseButton()
        {
            playBtn.Image = Resources.pause_100px;
            playBtn.HoverState.Image = Resources.pause_100px_png1;
        }

        private void shuffleBtn_Click(object sender, EventArgs e)
        {
            shuffleBtn.Checked = !shuffleBtn.Checked;
        }

        private void musicTrackBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (reader == null) return;
            reader.CurrentTime = TimeSpan.FromSeconds(musicTrackBar.Value);
        }

        private void volumeTrackBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (waveOut == null) return;
            waveOut.Volume = volumeTrackBar.Value / 100f;
        }

        private void muteBtn_Click(object sender, EventArgs e)
        {
            if (waveOut.Volume == 0)
            {
                waveOut.Volume = 1;
                volumeTrackBar.Value = 100;
            }
            else
            {
                waveOut.Volume = 0;
                volumeTrackBar.Value = 0;
            }
        }

        private void volumeBtn_Click(object sender, EventArgs e)
        {
            waveOut.Volume = 1;
            volumeTrackBar.Value = 100;
        }

        public async void LoadAlbum()
        {
            if (currentAlbum == null) return;
            var musics = await api.GetMusicListFromAlbum(currentAlbum.Id);
            foreach (var music in musics) music.Album = currentAlbum;
            currentAlbum.Musics = musics;
            musicList = musics;
            currentSongIndex = 0;
            _ucPlaylist.LoadPlaylists();
            // currentListBtn click
            currentListBtn_Click(null, null);
        }

        private async void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searchTextBox == null || searchTextBox.Text == "")
                {
                    MessageBox.Show("Hãy nhập từ khóa tìm kiếm");
                    return;
                }

                var searchData = await api.GetSearchData(searchTextBox.Text);
                searchPageBtn_Click(sender, e);
                _ucSearch.searchData = searchData;
                _ucSearch.LoadData();
            }
        }

        private void thumbnailImage_Click(object sender, EventArgs e)
        {
            currentListBtn_Click(sender, e);
        }

        private void artistsName_Click(object sender, EventArgs e)
        {
            currentListBtn_Click(sender, e);
        }

        private void songTitle_Click(object sender, EventArgs e)
        {
            currentListBtn_Click(sender, e);
        }

        private async void loveMusic_Click(object sender, EventArgs e)
        {
            LoadLoveMusic();
            
            musicList = loveMusicList;
            currentSongIndex = 0;
            currentMusic = loveMusicList.Count() != 0 ? musicList[currentSongIndex]
                    : currentMusic;
            _ucPlaylist.LoadPlaylists();
            currentListBtn_Click(sender, e);
        }

        public void LoadLoveMusic()
        {
            // load love music to current list
            var loveMusic = from p in dbContext.LikePlaylists
                where p.UserId == user.UserId
                select p;
            if (user.LikePlaylists == null)
            {
                user.LikePlaylists = loveMusic.ToList();
            }
            
            loveMusicList.Clear();
            
            foreach (var likePlaylist in loveMusic)
            {
                if (loveMusicList.Any(m => m.Id == likePlaylist.MusicCode)) continue;
                Task.Run(async () =>
                {
                    var music = await api.GetSongInfo(likePlaylist.MusicCode);
                    loveMusicList.Add(music);
                    _ucPlaylist.Invoke(new Action(() =>
                    {
                        if (musicList == loveMusicList)
                            _ucPlaylist.LoadPlaylists();
                    }));
                });
            }
        }

        private void changePW_Click(object sender, EventArgs e)
        {
            var changePW = new View.ChangePW(user.Email);
            changePW.ShowDialog();
        }
    }
}