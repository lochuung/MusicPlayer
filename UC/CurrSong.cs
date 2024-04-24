using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Model;
using MusicPlayer.MusicApi;
using MusicPlayer.Utils;
using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utilities.BunifuSlider;
using Image = System.Drawing.Image;


namespace MusicPlayer.UC
{
    public partial class CurrSong : UserControl
    {
        public CurrSong()
        {
            InitializeComponent();
        }

        private void CurrSong_Load(object sender, EventArgs e)
        {

        }
    }
}
