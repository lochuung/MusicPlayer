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

namespace MusicPlayer.UC
{
    public partial class UC_Playlist : UserControl
    {
        public MusicPlayerForm mainForm;
        public UC_Playlist()
        {
            InitializeComponent();
        }

        private void UC_Playlist_Load(object sender, EventArgs e)
        {
            if (mainForm == null)
            {
                mainForm = (MusicPlayerForm)FindForm();
            }
            normalSection1.Title.Text = "Playlists đang phát";
            normalSection1.Title.Left = (normalSection1.Width - normalSection1.Title.Width) / 2;
            LoadPlaylists();
        }

        public void LoadPlaylists()
        {
            List<Music> playlists = mainForm.musicList;
            if (playlists == null || playlists.Count == 0)
            {
                return;
            }
            normalSection1.ClearItems();
            foreach (Music music in playlists)
            {
                normalSection1.AddItem(music, 1);
            }
        }
    }
}
