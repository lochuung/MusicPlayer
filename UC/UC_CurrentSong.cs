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

namespace MusicPlayer.UC
{
    public partial class UC_CurrentSong : UserControl
    {
        public Music CurrentMusic { get; set; }
        public UC_CurrentSong()
        {
            InitializeComponent();
        }

        public UC_CurrentSong(Music currentMusic)
        {
            InitializeComponent();
            CurrentMusic = currentMusic;
        }
    }
}
