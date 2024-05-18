using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Database.Entity;
using MusicPlayer.Model;
using MusicPlayer.Properties;
using NAudio.Wave;
using Umbraco.Core;

namespace MusicPlayer.UC.ChildrenUC
{
    public partial class NormalSection : UserControl
    {
        public MusicPlayerForm mainForm;
        public List<Music> musics = new List<Music>();

        public NormalSection()
        {
            InitializeComponent();
        }

        public void AddItem(Music music, int column = 3, bool isScrollable = false)
        {
            if (mainForm == null) mainForm = (MusicPlayerForm)FindForm();

            var item = CreateMusicItem(music, musics.Count + 1);

            MusicList.Controls.Add(item);
            musics.Add(music);

            EventHandler clickHandle = (sender, e) =>
            {
                var thread = new Thread(() =>
                {
                    mainForm.Semaphore.WaitOne();
                    mainForm.musicList = new List<Music>();
                    mainForm.musicList.Clear();
                    mainForm.musicList.AddRange(musics);
                    var musicIndex = mainForm.musicList.FindIndex(x => x.Id == music.Id);
                    mainForm.currentSongIndex = musicIndex;
                    mainForm.currentMusic = mainForm.musicList[musicIndex];
                    mainForm.Semaphore.Release();
                    // using main thread to play music
                    mainForm.Invoke(new Action(() =>
                    {
                        if (mainForm.waveOut.PlaybackState != PlaybackState.Stopped)
                            mainForm.waveOut.Stop();
                        mainForm.PlayMusic();
                    }));
                });
                thread.Start();
                // if norsection is not in uc playlist then load playlist
                if (mainForm._ucPlaylist.Visible == false)
                    mainForm._ucPlaylist.LoadPlaylists();
            };
            item.PlayBtn.Click += clickHandle;
            item.index.Click += clickHandle;
            item.guna2PictureBox1.Click += clickHandle;
            item.label13.Click += clickHandle;
            item.label14.Click += clickHandle;
            item.guna2Panel1.Click += clickHandle;

            // like button click event
            item.likeBtn.Click += (sender, e) =>
            {
                if (item.likeBtn.Checked)
                {
                    item.likeBtn.Checked = false;
                    if (mainForm.user.LikePlaylists != null)
                        mainForm.user.LikePlaylists.RemoveAll(x => x.MusicCode == music.Id);
                    mainForm.dbContext.SaveChanges();
                }
                else
                {
                    item.likeBtn.Checked = true;
                    var likePlaylist = new LikeMusic
                    {
                        UserId = mainForm.user.UserId,
                        MusicCode = music.Id
                    };
                    if (mainForm.user.LikePlaylists == null)
                        mainForm.user.LikePlaylists = new List<LikeMusic>();
                    var checkExist = mainForm.user.LikePlaylists
                        .Where(x => x.MusicCode == music.Id).ToList();
                    if (checkExist.Count > 0)
                        return;
                    if (mainForm.user.LikePlaylists == null)
                        mainForm.user.LikePlaylists = new List<LikeMusic>();
                    mainForm.user.LikePlaylists.Add(likePlaylist);
                    mainForm.dbContext.SaveChanges();
                
                    mainForm.LoadLoveMusic();
                }
            };

            // set item width
            var itemWidth = (MusicList.Width - 20) / column;
            item.Width = itemWidth - (isScrollable ? 20 : 0);
            var xLikeButtonLocation = item.likeBtn.Left;
            var xlbl13Location = item.label13.Left;
            item.label13.MaximumSize = new Size(xLikeButtonLocation - xlbl13Location, 0);
            item.label14.MaximumSize = new Size(xLikeButtonLocation - xlbl13Location, 0);
            if (!isScrollable)
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
                item.index.Left = 10;
            else if (indexLength == 2)
                item.index.Left = 5;
            else
                item.index.Left = 0;

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
                        mainForm.Invoke(new Action(() =>
                        {
                            // hightlight the current playing music
                            for (var i = 0; i < musics.Count; i++)
                            {
                                var item = (UC_MusicItem)MusicList.Controls[i];
                                if (mainForm.currentMusic != null && mainForm.currentMusic.Id == musics[i].Id)
                                {
                                    item.BackColor = Color.FromArgb(193, 223, 246);
                                    item.PlayBtn.Image = mainForm.playBtn.Image;
                                }
                                else
                                {
                                    item.PlayBtn.Image = Resources.play_100px;
                                    item.BackColor = Color.FromArgb(240, 243, 250);
                                }

                                if (mainForm.user.LikePlaylists == null)
                                    continue;

                                if (mainForm.user.LikePlaylists
                                        .Where(x => x.MusicCode == musics[i].Id).ToList().Count > 0)
                                    item.likeBtn.Checked = true;
                                else
                                    item.likeBtn.Checked = false;
                            }
                        }));
                }
            });
            thread.Start();
        }
    }
}