using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Model;
using NAudio.Wave;

namespace MusicPlayer.UC.ChildrenUC
{
    public partial class LargeSection : UserControl
    {
        public MusicPlayerForm mainForm;
        public List<BaseDTO> musics = new List<BaseDTO>();

        public LargeSection()
        {
            InitializeComponent();
        }

        public void AddItem(BaseDTO dto, bool isScrollable = true)
        {
            if (mainForm == null)
                mainForm = (MusicPlayerForm)FindForm();

            var item = new UC_Item();
            item.SetImage(dto.ThumbnailM);
            item.SetTitle(dto.Title);
            item.SetArtist(dto is Album
                           && !string.IsNullOrEmpty(((Album)dto).ShortDescription)
                ? ((Album)dto).ShortDescription
                : dto.Artists);

            musics.Add(dto);

            var songIndex = musics.Count - 1;

            EventHandler clickHandle = (sender, e) =>
            {
                var musicList = new List<Music>();
                foreach (var m in musics) musicList.Add((Music)m);
                mainForm.musicList = musicList;
                mainForm._ucPlaylist.LoadPlaylists();
                var thread = new Thread(() =>
                {
                    mainForm.Semaphore.WaitOne();
                    mainForm.currentMusic = (Music)dto;
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
            if (dto is Album)
                clickHandle = (sender, e) =>
                {
                    var album = (Album)dto;
                    mainForm.currentAlbum = album;
                    mainForm.LoadAlbum();
                };
            item.Guna2Panel1.Click += clickHandle;
            item.Label13.Click += clickHandle;
            item.Label14.Click += clickHandle;
            item.Guna2PictureBox6.Click += clickHandle;

            MusicList.Controls.Add(item);

            if (!isScrollable)
                SetNonScrollable();
        }

        private void SetNonScrollable()
        {
            // turn off auto scroll and show all items in flow layout panel
            MusicList.AutoScroll = false;
            MusicList.WrapContents = true;

            // set height of flow layout panel
            var itemHeight = new UC_Item().Height;
            var height =
                (int)Math.Floor((double)musics.Count * itemHeight) / 4 + itemHeight / 2
                * (musics.Count % 4 == 0 ? 0 : 1);
            Height = height + guna2Panel1.Height;
            MusicList.Height = height;
        }

        public void ClearItems()
        {
            MusicList.Controls.Clear();
            musics.Clear();
        }
    }
}