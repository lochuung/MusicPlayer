using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json.Nodes;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.MusicApi;
using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utilities.BunifuCheckBox.Transitions;

namespace MusicPlayer
{
    public partial class FormUsers : Form
    {
        private string hoTen;
        
        private ZingMp3Api api;
        private readonly string songId = "Z7U00WDE";
        private MediaFoundationReader reader;
        private WaveOut waveOut = new WaveOut();
        Thread streamingThread;

        public FormUsers()
        {
            this.api = new ZingMp3Api(this);
            InitializeComponent();
        }

        public FormUsers(string hoTen)
        {
            this.hoTen = hoTen;
            this.api = new ZingMp3Api(this);
        }

        private void btnExitMainForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
            if (streamingThread != null)
            {
                streamingThread.Abort();
            }
        }

        private void trendingBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = trendingBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(0);
        }

        private void releaseBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = releaseBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(1);
        }

        private void playlistBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = playlistBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(2);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = searchBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(3);
        }

        private void playingBtn_Click(object sender, EventArgs e)
        {
            indicator.Top = playingBtn.Top + indicator.Size.Height - 2;
            bunifuPages1.SetPage(4);
        }

        private void playMusicBtn_Click(object sender, EventArgs e)
        {
            if (songId == null || songId.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn bài hát để phát");
            }
            LoadSongData();
            playingBtn_Click(sender, e);
            if (waveOut.PlaybackState == PlaybackState.Stopped)
            {
                LoadStreaming();
            }
            else if (waveOut.PlaybackState == PlaybackState.Paused)
            {
                waveOut.Play();
            }
            else if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Pause();
            }
        }

        private async void LoadSongData()
        {
            dynamic songInfo = JsonConvert.DeserializeObject(await api.GetSongInfo(songId));
            string songName = songInfo.title;
            string artists = songInfo.artistsNames;
            string thumbnail = songInfo.thumbnailM;
            
            JArray genres = songInfo.genres;
            string genresString = "";
            foreach (dynamic genre in genres)
            {
                genresString += genre.name + ", ";
            }
            genresString = genresString.Substring(0, genresString.Length - 2);
            
            JArray composers = songInfo.composers;
            string composersString = "";
            foreach (dynamic composer in composers)
            {
                composersString += composer.name + ", ";
            }
            composersString = composersString.Substring(0, composersString.Length - 2);
            
            songNameLabel.Text = songName;
            singerNameLabel.Text = artists;
            genreLabel.Text = genresString;
            composerLabel.Text = composersString;
            this.thumbnail.Load(thumbnail);
        }

        private async void LoadStreaming()
        {
            string streaming = await api.GetStreamingUrl(songId);
            reader = new MediaFoundationReader(streaming);
            streamingThread = new Thread(() =>
            {
                waveOut.Init(reader);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    musicSlider.Invoke(new Action(() =>
                    {
                        musicSlider.Maximum = (int) reader.TotalTime.TotalSeconds;
                        musicSlider.Value = (int) reader.CurrentTime.TotalSeconds;
                    }));
                    Thread.Sleep(1000);
                }
            });
            streamingThread.Start();
        }

        private void musicSlider_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            reader.CurrentTime = TimeSpan.FromSeconds(musicSlider.Value);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            waveOut.Pause();
        }
    }
}