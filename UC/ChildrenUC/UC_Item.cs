using System.Threading;
using System.Windows.Forms;

namespace MusicPlayer.UC.ChildrenUC
{
    public partial class UC_Item : UserControl
    {
        public UC_Item()
        {
            InitializeComponent();
        }

        public void SetImage(string url)
        {
            var thread = new Thread(() =>
            {
                var isLoaded = false;
                while (!isLoaded)
                    try
                    {
                        Guna2PictureBox6.Load(url);
                        isLoaded = true;
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại kết nối mạng", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            });
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