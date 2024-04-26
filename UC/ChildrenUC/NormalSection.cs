using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Model;
using NAudio.Wave;

namespace MusicPlayer.UC.ChildrenUC
{
    public partial class NormalSection : UserControl
    {
        public List<Music> musics = new List<Music>();
        public MusicPlayerForm mainForm;

        public NormalSection()
        {
            InitializeComponent();
        }

        public void AddItem(Music music, int column = 3)
        {
            if (mainForm == null)
            {
                mainForm = (MusicPlayerForm)FindForm();
            }

            var item = CreateMusicItem(music, musics.Count + 1);

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
            item.index.Click += clickHandle;
            item.guna2PictureBox1.Click += clickHandle;
            item.label13.Click += clickHandle;
            item.label14.Click += clickHandle;
            item.guna2Panel1.Click += clickHandle;
            
            // set item width
            var itemWidth = (MusicList.Width - 20) / column;
            item.Width = itemWidth;
            SetNonScrollable(column);
        }
        
        private UC_MusicItem CreateMusicItem(Music music, int index)
        {
            var item = new UC_MusicItem();
            item.SetImage(music.ThumbnailM);
            item.SetTitle(music.Title);
            item.SetArtist(music.Artists);
            item.SetIndex(index);
            var indexLength = item.index.Text.Length;
            if (indexLength == 1)
            {
                item.index.Left = 10;
            }
            else if (indexLength == 2)
            {
                item.index.Left = 5;
            }
            else
            {
                item.index.Left = 0;
            }

            return item;
        }
        
        public void ClearItems()
        {
            MusicList.Controls.Clear();
            musics.Clear();
        }
        
        private void SetNonScrollable(int column = 3)
        {
            // turn off auto scroll and show all items in flow layout panel
            MusicList.AutoScroll = false;
            MusicList.WrapContents = true;

            // set height of flow layout panel
            var itemHeight = new UC_MusicItem().Height;
            var height =
                (int)Math.Floor((double)musics.Count * itemHeight / column) + itemHeight;
            Height = height + Guna2Panel1.Height;
            MusicList.Height = height;
        }

        private void NormalSection_Load(object sender, EventArgs e)
        {
            // create a new thread to observe the music list
            var thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (mainForm != null)
                    {
                        mainForm.Invoke(new Action(() =>
                        {
                            // hightlight the current playing music
                            for (var i = 0; i < musics.Count; i++)
                            {
                                var item = (UC_MusicItem)MusicList.Controls[i];
                                if (mainForm.currentMusic != null && mainForm.currentMusic.Id == musics[i].Id)
                                {
                                    item.BackColor = System.Drawing.Color.FromArgb(193, 223, 246);
                                    item.PlayBtn.Image = mainForm.playBtn.Image;
                                }
                                else
                                {
                                    item.PlayBtn.Image = Properties.Resources.play_100px;
                                    item.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
                                }
                            }
                        }));
                    }
                }
            });
            thread.Start();
        }
    }
}