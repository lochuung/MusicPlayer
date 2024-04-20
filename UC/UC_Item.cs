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

namespace MusicPlayer.UC
{
    public partial class UC_Item : UserControl
    {
        public UC_Item()
        {
            InitializeComponent();
        }
        
        public void SetImage(string url)
        {
            Thread thread = new Thread(() =>
            {
                guna2PictureBox6.Load(url);
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

        public Guna2Panel Guna2Panel1
        {
            get => guna2Panel1;
            set => guna2Panel1 = value;
        }

        public Label Label13
        {
            get => label13;
            set => label13 = value;
        }

        public Label Label14
        {
            get => label14;
            set => label14 = value;
        }

        public Guna2PictureBox Guna2PictureBox6
        {
            get => guna2PictureBox6;
            set => guna2PictureBox6 = value;
        }
    }
}
