using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Model;
using MusicPlayer.MusicApi;
using MusicPlayer.Properties;
using MusicPlayer.UC;
using NAudio.Wave;

namespace MusicPlayer
{
    public partial class MusicPlayerForm : Form
    {
        private static UC_Home _ucHome;
        private static UC_Trending _ucTrending;
        private static UC_CurrentSong _ucCurrentSong;
        private static UC_Search _ucSearch;
        private static UC_Playlist _ucPlaylist;


        private ZingMp3Api api;
        public Album currentAlbum;
        public Music currentMusic;
        public int currentSongIndex;
        public List<Music> musicList = new List<Music>();

        private MediaFoundationReader reader;

        // using semaphore to avoid multiple thread access to waveOut and currentMusic, currentSongIndex
        public Semaphore Semaphore = new Semaphore(2, 2);
        private Thread streamingThread;
        public WaveOutEvent waveOut = new WaveOutEvent();

        public MusicPlayerForm()
        {
            InitializeComponent();
        }

        private async void MusicPlayerForm_Load(object sender, EventArgs e)
        {
            _ucHome = new UC_Home();
            _ucCurrentSong = new UC_CurrentSong();
            _ucSearch = new UC_Search();
            _ucPlaylist = new UC_Playlist();
            _ucPlaylist.mainForm = this;
            ChangeUserControl(_ucHome);

            api = new ZingMp3Api(this);
            musicList = new List<Music>();
            currentMusic = null;
            homeBtn.Checked = true;
            repeatBtn.Checked = true;
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
                    bool isLoaded = false;
                    do
                    {
                        try
                        {
                            thumbnailImage.Load(currentMusic.ThumbnailM);
                            isLoaded = true;
                        }
                        catch (Exception e)
                        {
                            Thread.Sleep(3000);
                            thumbnailImage.Load(currentMusic.ThumbnailM);
                        }
                    } while (!isLoaded);
                }));
            });
            thread.Start();

            // hightlight current song and clear highlight of other songs
            // default theme color
            // var color = musicGridView.RowsDefaultCellStyle.BackColor;
            // for (int i = 0; i < musicGridView.Rows.Count; i++)
            // {
            //     musicGridView.Rows[i].DefaultCellStyle.BackColor = color;
            // }
            // musicGridView.Rows[currentSongIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
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

        private void ChangeUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            userControl.Width = containerPanel.Width;
            containerPanel.Controls.Add(userControl);
            userControl.BringToFront();
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
            songBtn.Checked = false;
            currentListBtn.Checked = false;
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            ChangeUserControl(_ucHome);
            UncheckAllButton();
            homeBtn.Checked = true;
        }

        private async void trendingBtn_Click(object sender, EventArgs e)
        {
            if (_ucTrending == null)
            {
                var jsonData = await api.GetTrendingData();
                _ucTrending = new UC_Trending(jsonData);
            }

            UncheckAllButton();
            trendingBtn.Checked = true;
            ChangeUserControl(_ucTrending);
        }

        private void releaseBtn_Click(object sender, EventArgs e)
        {
            UncheckAllButton();
            releaseBtn.Checked = true;
        }

        private void searchPageBtn_Click(object sender, EventArgs e)
        {
            UncheckAllButton();
            searchPageBtn.Checked = true;
            if (_ucSearch == null) _ucSearch = new UC_Search();
            ChangeUserControl(_ucSearch);
        }

        private void songBtn_Click(object sender, EventArgs e)
        {
            UncheckAllButton();
            songBtn.Checked = true;
            if (_ucCurrentSong == null) _ucCurrentSong = new UC_CurrentSong(currentMusic);
            ChangeUserControl(_ucCurrentSong);
        }

        private void currentListBtn_Click(object sender, EventArgs e)
        {
            if (_ucPlaylist == null) _ucPlaylist = new UC_Playlist();
            _ucPlaylist.LoadPlaylists();
            ChangeUserControl(_ucPlaylist);
            UncheckAllButton();
            currentListBtn.Checked = true;
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
            List<Music> musics = await api.GetMusicListFromAlbum(currentAlbum.Id);
            foreach (var music in musics)
            {
                music.Album = currentAlbum;
            }
            currentAlbum.Musics = musics;
            musicList = musics;
            currentSongIndex = 0;
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
    }
}