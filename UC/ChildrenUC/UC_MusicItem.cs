using System.Threading;
using System.Windows.Forms;
using MusicPlayer.Properties;

namespace MusicPlayer.UC.ChildrenUC
{
    public partial class UC_MusicItem : UserControl
    {
        public UC_MusicItem()
        {
            InitializeComponent();
        }

        public void ShowPlayBtn()
        {
            PlayBtn.Image = Resources.play_100px;
            PlayBtn.HoverState.Image = Resources.play_100px_png1;
        }

        public void ShowPauseBtn()
        {
            PlayBtn.Image = Resources.pause_100px;
            PlayBtn.HoverState.Image = Resources.pause_100px_png1;
        }

        public void SetImage(string url)
        {
            var thread = new Thread(() =>
            {
                var isLoad = false;
                do
                {
                    try
                    {
                        guna2PictureBox1.Load(url);
                        isLoad = true;
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại kết nối mạng", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } while (!isLoad);
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

        public void SetIndex(int index)
        {
            this.index.Text = index.ToString();
        }
    }
}