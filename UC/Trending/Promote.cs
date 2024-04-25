﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Model;

namespace MusicPlayer.UC.Trending
{
    public partial class Promote : UserControl
    {
        public List<Music> PromoteMusics = new List<Music>();

        public Promote()
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
            
            PromoteMusics.Add(music);
            
            EventHandler clickHandle = (sender, e) =>
            {
                mainForm.musicList = PromoteMusics;
                int songIndex = PromoteMusics.Count - 1;
                var thread = new Thread(() =>
                {
                    mainForm.Semaphore.WaitOne();
                    mainForm.currentMusic = music;
                    mainForm.currentSongIndex = songIndex;
                    mainForm.Semaphore.Release();

                    mainForm.Semaphore.WaitOne();
                    if (mainForm.waveOut.PlaybackState != NAudio.Wave.PlaybackState.Stopped)
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
            item.Guna2Panel1.Click += clickHandle;
            item.Label13.Click += clickHandle;
            item.Label14.Click += clickHandle;
            item.Guna2PictureBox6.Click += clickHandle;

            musicList.Controls.Add(item);
        }
    }
}