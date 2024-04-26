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
        public List<BaseEntity> musics = new List<BaseEntity>();

        public LargeSection()
        {
            InitializeComponent();
        }

        public void AddItem(BaseEntity dto)
        {
            var mainForm = (MusicPlayerForm)FindForm();

            var item = new UC_Item();
            item.SetImage(dto.ThumbnailM);
            item.SetTitle(dto.Title);
            item.SetArtist(dto.Artists);

            musics.Add(dto);

            var songIndex = musics.Count - 1;

            EventHandler clickHandle = (sender, e) =>
            {
                var musicList = new List<Music>();
                foreach (var m in musics) musicList.Add((Music)m);
                mainForm.musicList = musicList;
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
        }
        
        public void ClearItems()
        {
            MusicList.Controls.Clear();
            musics.Clear();
        }
    }
}