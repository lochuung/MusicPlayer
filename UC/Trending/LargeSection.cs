using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Model;
using NAudio.Wave;

namespace MusicPlayer.UC.Trending
{
    public partial class LargeSection : UserControl
    {
        public List<Music> musics = new List<Music>();

        public LargeSection()
        {
            InitializeComponent();
        }

        public void AddItem(Music music)
        {
            var mainForm = (MusicPlayerForm)FindForm();

            var item = new UC_Item();
            item.SetImage(music.ThumbnailM);
            item.SetTitle(music.Title);
            item.SetArtist(music.Artists);

            musics.Add(music);

            var songIndex = musics.Count - 1;

            EventHandler clickHandle = (sender, e) =>
            {
                mainForm.musicList = musics;
                var thread = new Thread(() =>
                {
                    mainForm.Semaphore.WaitOne();
                    mainForm.currentMusic = music;
                    mainForm.currentSongIndex = songIndex;
                    mainForm.Semaphore.Release();

                    mainForm.Semaphore.WaitOne();
                    if (mainForm.waveOut.PlaybackState != PlaybackState.Stopped)
                        mainForm.waveOut.Stop();
                    mainForm.Semaphore.Release();
                    // using main thread to play music
                    mainForm.Invoke(new Action(() => { mainForm.PlayMusic(); }));
                });
                thread.Start();
            };
            item.Guna2Panel1.Click += clickHandle;
            item.Label13.Click += clickHandle;
            item.Label14.Click += clickHandle;
            item.Guna2PictureBox6.Click += clickHandle;

            MusicList.Controls.Add(item);
        }
    }
}