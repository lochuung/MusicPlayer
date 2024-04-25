using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Model;
using NAudio.Wave;

namespace MusicPlayer.UC.Trending
{
    public partial class Ranking : UserControl
    {
        public List<Music> RankingMusics = new List<Music>();

        public Ranking()
        {
            InitializeComponent();
        }

        public void AddItem(Music music)
        {
            var mainForm = (MusicPlayerForm)FindForm();

            var item = new UC_MusicItem();
            item.SetImage(music.ThumbnailM);
            item.SetTitle(music.Title);
            item.SetArtist(music.Artists);
            item.SetIndex(RankingMusics.Count + 1);

            musicList.Controls.Add(item);
            RankingMusics.Add(music);

            EventHandler clickHandle = (sender, e) =>
            {
                mainForm.musicList = RankingMusics;
                var thread = new Thread(() =>
                {
                    mainForm.Semaphore.WaitOne();
                    mainForm.currentMusic = music;
                    mainForm.currentSongIndex = RankingMusics.Count - 1;
                    mainForm.Semaphore.Release();

                    mainForm.Semaphore.WaitOne();
                    if (mainForm.waveOut.PlaybackState != PlaybackState.Stopped)
                        mainForm.waveOut.Stop();
                    mainForm.Semaphore.Release();
                    // using main thread to play music
                    mainForm.Invoke(new Action(() =>
                    {
                        mainForm.PlayMusic();
                    }));
                });
                thread.Start();
            };
            item.PlayBtn.Click += clickHandle;
        }
    }
}