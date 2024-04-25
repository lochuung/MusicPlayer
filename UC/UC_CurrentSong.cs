using System.Windows.Forms;
using MusicPlayer.Model;

namespace MusicPlayer.UC
{
    public partial class UC_CurrentSong : UserControl
    {
        public UC_CurrentSong()
        {
            InitializeComponent();
        }

        public UC_CurrentSong(Music currentMusic)
        {
            InitializeComponent();
            CurrentMusic = currentMusic;
        }

        public Music CurrentMusic { get; set; }
    }
}