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
using MusicPlayer.Properties;

namespace MusicPlayer.UC
{
    public partial class UC_MusicItem : UserControl
    {
        public UC_MusicItem()
        {
            InitializeComponent();
        }
        
        public void ShowPlayBtn()
        {
            playBtn.Image = Resources.play_100px;
            playBtn.HoverState.Image = Resources.play_100px_png1;
        }
        
        public void ShowPauseBtn()
        {
            playBtn.Image = Resources.pause_100px;
            playBtn.HoverState.Image = Resources.pause_100px_png1;
        }
        
        public void SetImage(string url)
        {
            Thread thread = new Thread(() =>
            {
                guna2PictureBox1.Load(url);
            });
            thread.Start();
        }
        
        public void SetTitle(string title)
        {
            label13.Text = title;
        }
        
        public void SetArtist(string artist)
        {
            label14.Text = artist;
        }

        public Guna2ImageButton PlayBtn
        {
            get => playBtn;
            set => playBtn = value;
        }
    }
}
