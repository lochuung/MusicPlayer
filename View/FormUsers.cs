using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Model;
using MusicPlayer.MusicApi;
using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utilities.BunifuSlider;

namespace MusicPlayer
{
    public partial class FormUsers : Form
    {
        private readonly ZingMp3Api api;
        private readonly WaveOut waveOut = new WaveOut();
        private Music currentMusic;

        private int currentSongIndex;
        private string hoTen;

        private List<Music> musicList = new List<Music>();
        private MediaFoundationReader reader;
        private Thread streamingThread;

        public FormUsers()
        {
            InitializeComponent();
            api = new ZingMp3Api();
        }

        public FormUsers(string hoTen)
        {
            this.hoTen = hoTen;
            api = new ZingMp3Api();
            InitializeComponent();
        }


        private void btnExitMainForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
            if (streamingThread != null) streamingThread.Abort();
        }

        private void trendingBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = trendingBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(0);
            titleLabel.Text = "Top Trending";
        }

        private void releaseBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = releaseBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(1);
            titleLabel.Text = "Mới phát hành";
        }

        private void playlistBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = playlistBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(2);
            titleLabel.Text = "Playlists";
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = searchBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(3);
            titleLabel.Text = "Tìm kiếm";
        }

        private void playingBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = playingBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(4);
            titleLabel.Text = "Phát nhạc";
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = homeBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(5);
            titleLabel.Text = "Trang chủ";
        }

        private void playMusicBtn_Click(object sender, EventArgs e)
        {
            if (currentMusic == null)
            {
                MessageBox.Show("Vui lòng chọn bài hát để phát");
                return;
            }

            PlayMusic();

            playingBtn_Click(sender, e);
        }

        private void PlayMusic()
        {
            if (waveOut.PlaybackState == PlaybackState.Stopped)
            {
                if (streamingThread != null) streamingThread.Abort();
                LoadSongData();
                LoadStreaming();
                pauseButton.Visible = true;
                playMusicBtn.Visible = false;
            }
            else if (waveOut.PlaybackState == PlaybackState.Paused)
            {
                waveOut.Play();
                pauseButton.Visible = true;
                playMusicBtn.Visible = false;
            }
        }

        private async void LoadSongData()
        {
            songNameLabel.Text = currentMusic.Title;
            singerNameLabel.Text = currentMusic.Artists;
            genreLabel.Text = currentMusic.Genres;
            composerLabel.Text = currentMusic.Composers;
            thumbnail.Load(currentMusic.ThumbnailM);
            smallThumbnail.Load(currentMusic.Thumbnail);
            songPlayerLabel.Text = currentMusic.Title;
            artistsPlayerLabel.Text = currentMusic.Artists;

            // hightlight current song and clear highlight of other songs
            // default theme color
            var color = musicGridView.RowsDefaultCellStyle.BackColor;
            for (var i = 0; i < musicGridView.Rows.Count; i++) musicGridView.Rows[i].DefaultCellStyle.BackColor = color;
            musicGridView.Rows[currentSongIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
        }

        private async void LoadStreaming()
        {
            // reset slider
            musicSlider.Value = 0;
            currentTimeLabel.Text = "00:00";
            endTimeLabel.Text = "00:00";

            var streaming = await api.GetStreamingUrl(currentMusic.Id);
            reader = new MediaFoundationReader(streaming);
            waveOut.Init(reader);
            streamingThread = new Thread(() =>
            {
                waveOut.Play();
                while (waveOut.PlaybackState != PlaybackState.Stopped)
                {
                    musicSlider.Invoke(new Action(() =>
                    {
                        musicSlider.Maximum = (int)reader.TotalTime.TotalSeconds;
                        musicSlider.Value = (int)reader.CurrentTime.TotalSeconds;
                        currentTimeLabel.Text = reader.CurrentTime.ToString("mm\\:ss");
                        endTimeLabel.Text = reader.TotalTime.ToString("mm\\:ss");
                    }));
                    Thread.Sleep(1000);
                }

                // Load next song
                currentSongIndex++;
                if (currentSongIndex >= musicList.Count) currentSongIndex = 0;

                currentMusic = musicList[currentSongIndex];
                LoadSongData();
                LoadStreaming();
            });
            streamingThread.Start();
        }

        private void musicSlider_Scroll(object sender, BunifuHScrollBar.ScrollEventArgs e)
        {
            reader.CurrentTime = TimeSpan.FromSeconds(musicSlider.Value);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            waveOut.Pause();
            pauseButton.Visible = false;
            playMusicBtn.Visible = true;
        }

        private void muteBtn_Click(object sender, EventArgs e)
        {
            waveOut.Volume = 0;
            volumeSlider.Value = 0;
        }

        private void maxVolumeBtn_Click(object sender, EventArgs e)
        {
            waveOut.Volume = 1;
            volumeSlider.Value = 100;
        }

        private void volumeSlider_Scroll(object sender, BunifuHScrollBar.ScrollEventArgs e)
        {
            waveOut.Volume = volumeSlider.Value / 100f;
        }

        private async void FormUsers_Load(object sender, EventArgs e)
        {
            musicList = await api.GetTrendingSongs();
            LoadMultipleSongData();
            musicGridView.ClearSelection();
        }

        private void LoadMultipleSongData()
        {
            musicGridView.Rows.Clear();
            musicGridView.Rows.Add(musicList.Count);
            api.WaitForm.Show();

            // create multiple threads to load images, load song info, to make it faster
            var threads = new List<Thread>();
            for (var i = 0; i < musicList.Count; i++)
            {
                var index = i;
                var loadImagesThread = new Thread(() =>
                {
                    var cell = new DataGridViewImageCell();
                    cell.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    musicGridView.Rows[index].Cells[1] = cell;

                    // load genres and composers
                    var music = musicList[index];
                    dynamic songInfo = JsonConvert.DeserializeObject(api.GetSongInfo(music.Id).Result);
                    var genresString = "";
                    if (songInfo.genres != null)
                    {
                        JArray genres = songInfo.genres;
                        foreach (dynamic genre in genres) genresString += genre.name.ToString() + ", ";
                        music.Genres = genresString.Substring(0, genresString.Length - 2);
                    }

                    if (songInfo.composers != null)
                    {
                        JArray composers = songInfo.composers;
                        var composersString = "";
                        foreach (dynamic composer in composers) composersString += composer.name.ToString() + ", ";
                        music.Composers = composersString.Substring(0, composersString.Length - 2);
                    }
                });
                threads.Add(loadImagesThread);
                loadImagesThread.Start();
            }

            // load data
            for (var i = 0; i < musicList.Count; i++)
            {
                var music = musicList[i];

                musicGridView.Rows[i].Cells[0].Value = i + 1;
                musicGridView.Rows[i].Cells[2].Value = music.Title;
                musicGridView.Rows[i].Cells[3].Value = music.Artists;
                musicGridView.Rows[i].Cells[4].Value = music.Album.Title;
            }

            api.WaitForm.Hide();
        }

        private void trendingGridView_SelectionChanged(object sender, EventArgs e)
        {
            var rowsCount = musicGridView.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return;
            if (currentMusic == null)
            {
                currentMusic = musicList[musicGridView.SelectedRows[0].Index];
                currentSongIndex = musicGridView.SelectedRows[0].Index;
                return;
            }

            var row = musicGridView.SelectedRows[0];
            if (row == null) return;
            currentMusic = musicList[row.Index];
            currentSongIndex = row.Index;
            if (waveOut.PlaybackState != PlaybackState.Stopped) waveOut.Stop();
            PlayMusic();
            // unselect all rows
            musicGridView.ClearSelection();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            currentSongIndex++;
            if (currentSongIndex >= musicList.Count) currentSongIndex = 0;

            currentMusic = musicList[currentSongIndex];
            if (waveOut.PlaybackState != PlaybackState.Stopped) waveOut.Stop();
            PlayMusic();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            currentSongIndex--;
            if (currentSongIndex < 0) currentSongIndex = musicList.Count - 1;

            currentMusic = musicList[currentSongIndex];
            if (waveOut.PlaybackState != PlaybackState.Stopped) waveOut.Stop();
            PlayMusic();
        }

        private void smallThumbnail_Click(object sender, EventArgs e)
        {
            playingBtn_Click(sender, e);
        }
    }
}