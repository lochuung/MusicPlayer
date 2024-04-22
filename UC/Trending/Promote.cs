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
using MusicPlayer.Model;
using NAudio.Wave;

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
            var item = new UC_Item();
            item.SetImage(music.ThumbnailM);
            item.SetTitle(music.Title);
            item.SetArtist(music.Artists);
            EventHandler clickHandle = (sender, e) =>
            {
                MusicPlayerForm mainForm = (MusicPlayerForm)FindForm();
                // remove if already exist
                mainForm.musicList = mainForm.musicList.Where(m => m.Id != music.Id).ToList();
                mainForm.musicList.Add(music);
                mainForm.currentMusic = music;
                mainForm.currentSongIndex = mainForm.musicList.Count - 1;
                
                mainForm.semaphore.WaitOne();
                if (mainForm.waveOut.PlaybackState != PlaybackState.Stopped) 
                    mainForm.waveOut.Stop();
                mainForm.semaphore.Release();
                mainForm.PlayMusic();
            };
            item.Guna2Panel1.Click += clickHandle;
            item.Label13.Click += clickHandle;
            item.Label14.Click += clickHandle;
            item.Guna2PictureBox6.Click += clickHandle;
            
            musicList.Controls.Add(item);
            PromoteMusics.Add(music);
        }
    }
}
