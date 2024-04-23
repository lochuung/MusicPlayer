using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MusicPlayerForm mainForm = (MusicPlayerForm)FindForm();
            
            var item = new UC_MusicItem();
            item.SetImage(music.ThumbnailM);
            item.SetTitle(music.Title);
            item.SetArtist(music.Artists);
            
            musicList.Controls.Add(item);
            RankingMusics.Add(music);
            mainForm.musicList.Clear();
            mainForm.musicList.AddRange(RankingMusics);
            
            EventHandler clickHandle = (sender, e) =>
            {
                 int index = mainForm.musicList.IndexOf(mainForm.musicList.Find(m => m.Id == music.Id));
                 mainForm.currentMusic = music;
                 mainForm.currentSongIndex = index;
                 
                 mainForm.semaphore.WaitOne();
                 if (mainForm.waveOut.PlaybackState != PlaybackState.Stopped) 
                     mainForm.waveOut.Stop();
                 mainForm.semaphore.Release();
                 mainForm.PlayMusic();
            };
            item.PlayBtn.Click += clickHandle;
        }
    }
}
