using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MusicPlayer.Model;
using NAudio.Wave;

namespace MusicPlayer.UC.Trending
{
    public partial class NormalSection : UserControl
    {
        public List<Music> NewReleaseMusics = new List<Music>();
        public NormalSection()
        {
            InitializeComponent();
        }

        public Label Title
        {
            get => title;
            set => title = value;
        }

        public FlowLayoutPanel MusicList
        {
            get => musicList;
            set => musicList = value;
        }

        public Guna2Panel Guna2Panel1
        {
            get => guna2Panel1;
            set => guna2Panel1 = value;
        }

        public void AddItem(Music music)
        {
            var mainForm = (MusicPlayerForm)FindForm();

            var item = new UC_MusicItem();
            item.SetImage(music.ThumbnailM);
            item.SetTitle(music.Title);
            item.SetArtist(music.Artists);
            item.SetIndex(NewReleaseMusics.Count + 1);

            musicList.Controls.Add(item);
            NewReleaseMusics.Add(music);

            EventHandler clickHandle = (sender, e) =>
            {
                mainForm.musicList = NewReleaseMusics;
                var thread = new Thread(() =>
                {
                    mainForm.Semaphore.WaitOne();
                    mainForm.currentMusic = music;
                    mainForm.currentSongIndex = NewReleaseMusics.Count - 1;
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
