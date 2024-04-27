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
    public partial class UC_NewRelease : UserControl
    {
        public List<Music> musics;
        public UC_NewRelease() : this(null)
        {
        }
        
        public UC_NewRelease(List<Music> musics)
        {
            this.musics = musics;
            InitializeComponent();
        }

        private void UC_NewRelease_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        public void LoadData()
        {
            if (musics == null) return;
            normalSection1.Title.Text = "Mới phát hành";
            // set center title
            normalSection1.Title.Left = (normalSection1.Width - normalSection1.Title.Width) / 2;
            foreach (Music m in musics)
            {
                normalSection1.AddItem(m, column: 1, isScrollable: false);
            }
        }
    }
}
