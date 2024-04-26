using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MusicPlayer.Model;
using NAudio.Wave;

namespace MusicPlayer.UC.Trending
{
    public partial class NormalSection : UserControl
    {
        public List<Music> musics = new List<Music>();

        public NormalSection()
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
            item.SetIndex(musics.Count + 1);

            MusicList.Controls.Add(item);
            musics.Add(music);

            var musicIndex = musics.Count - 1;

            EventHandler clickHandle = (sender, e) =>
            {
                mainForm.musicList = musics;
                var thread = new Thread(() =>
                {
                    mainForm.Semaphore.WaitOne();
                    mainForm.currentMusic = music;
                    mainForm.currentSongIndex = musicIndex;
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
            item.PlayBtn.Click += clickHandle;
        }
    }
}