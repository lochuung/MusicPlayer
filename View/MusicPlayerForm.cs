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
        private static readonly UC_Home _ucHome = new UC_Home();
        private static UC_Trending _ucTrending;
        private WaveOutEvent waveOut = new WaveOutEvent();

        private ZingMp3Api api;
        private Music currentMusic;

        private int currentSongIndex;


        private List<Music> musicList = new List<Music>();
        private MediaFoundationReader reader;
        private Thread streamingThread;

        public MusicPlayerForm()
        {
            InitializeComponent();
            ChangeUserControl(_ucHome);
            homeBtn.Checked = true;
            repeatBtn.Checked = true;
        }

        private void PlayMusic()
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
            thumbnailImage.Load(currentMusic.ThumbnailM);

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
            musicTrackBar.Value = 0;
            musicTrackBar.Maximum = 1;
            // reset time label
            currentTime.Text = "00:00";
            endTime.Text = "00:00";

            var streaming = await api.GetStreamingUrl(currentMusic.Id);
            reader = new MediaFoundationReader(streaming);
            
            waveOut.Init(reader);
            streamingThread = new Thread(() =>
            {
                waveOut.Play();

                while (waveOut.PlaybackState == PlaybackState.Playing
                       || waveOut.PlaybackState == PlaybackState.Paused)
                {
                    // Console.WriteLine(reader.CurrentTime);
                    // Console.WriteLine(waveOut.PlaybackState);
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
                    currentSongIndex++;
                    if (shuffleBtn.Checked)
                    {
                        var random = new Random();
                        currentSongIndex = random.Next(0, musicList.Count);
                    }
                    if (currentSongIndex >= musicList.Count) currentSongIndex = 0;

                    currentMusic = musicList[currentSongIndex];
                    LoadSongData();
                    LoadStreaming();
                }
            });
            streamingThread.Start();
        }

        private void ChangeUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            containerPanel.Controls.Clear();
            containerPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void UncheckAllButton()
        {
            homeBtn.Checked = false;
            trendingBtn.Checked = false;
            releaseBtn.Checked = false;
            albumBtn.Checked = false;
            searchPageBtn.Checked = false;
            artistBtn.Checked = false;
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            ChangeUserControl(new UC_Home());
            UncheckAllButton();
            homeBtn.Checked = true;
        }

        private void trendingBtn_Click(object sender, EventArgs e)
        {
            if (_ucTrending == null) _ucTrending = new UC_Trending();
            ChangeUserControl(_ucTrending);
            UncheckAllButton();
            trendingBtn.Checked = true;
        }

        private void releaseBtn_Click(object sender, EventArgs e)
        {
            UncheckAllButton();
            releaseBtn.Checked = true;
        }

        private void albumBtn_Click(object sender, EventArgs e)
        {
            UncheckAllButton();
            albumBtn.Checked = true;
        }

        private void searchPageBtn_Click(object sender, EventArgs e)
        {
            UncheckAllButton();
            searchPageBtn.Checked = true;
        }

        private void artistBtn_Click(object sender, EventArgs e)
        {
            UncheckAllButton();
            artistBtn.Checked = true;
        }

        private void btnExitMainForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
            if (streamingThread != null) streamingThread.Abort();
        }

        private void repeatBtn_Click(object sender, EventArgs e)
        {
            repeatBtn.Checked = !repeatBtn.Checked;
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            currentSongIndex--;
            if (currentSongIndex < 0) currentSongIndex = musicList.Count - 1;

            currentMusic = musicList[currentSongIndex];
            if (waveOut.PlaybackState != PlaybackState.Stopped) waveOut.Stop();
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
            playBtn.HoverState.Image = Resources.play_100px;
        }

        private void ShowPauseButton()
        {
            playBtn.Image = Resources.pause_100px;
            playBtn.HoverState.Image = Resources.pause_100px;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            currentSongIndex++;
            if (currentSongIndex >= musicList.Count) currentSongIndex = 0;

            currentMusic = musicList[currentSongIndex];
            if (waveOut.PlaybackState != PlaybackState.Stopped) waveOut.Stop();
            PlayMusic();
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
            waveOut.Volume = 0;
            volumeTrackBar.Value = 0;
        }

        private void volumeBtn_Click(object sender, EventArgs e)
        {
            waveOut.Volume = 1;
            volumeTrackBar.Value = 100;
        }

        private async void MusicPlayerForm_Load(object sender, EventArgs e)
        {
            api = new ZingMp3Api();
            musicList = await api.GetTrendingSongs();
            currentMusic = musicList[0];
        }
    }
}