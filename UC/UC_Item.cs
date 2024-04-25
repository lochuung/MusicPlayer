using System.Threading;
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

        public Guna2Panel Guna2Panel1 { get; set; }

        public Label Label13 { get; set; }

        public Label Label14 { get; set; }

        public Guna2PictureBox Guna2PictureBox6 { get; set; }

        public void SetImage(string url)
        {
            var thread = new Thread(() => { Guna2PictureBox6.Load(url); });
            thread.Start();
        }

        public void SetTitle(string title)
        {
            Label13.Text = title;
        }

        public void SetArtist(string artist)
        {
            Label14.Text = artist;
        }
    }
}