using System.Windows.Forms;
using MusicPlayer.Model;

namespace MusicPlayer.UC
{
    public partial class UC_CurrentSong : UserControl
    {
        private static MusicPlayerForm mainForm;
        public UC_CurrentSong()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            if (mainForm == null) mainForm = (MusicPlayerForm)FindForm();
            if (mainForm.currentMusic == null) return;
            var currentMusic = mainForm.currentMusic;
            bool isLoaded = false;
            do
            {
                try
                {
                    currSong1.ptrImage.Load(currentMusic.ThumbnailM);
                    isLoaded = true;
                }
                catch
                {
                    MessageBox.Show("Vui lòng kiểm tra lại kết nối mạng", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } while (!isLoaded);
            currSong1.lblTenBaiHat.Text = currentMusic.Title;
            currSong1.lblTenCaSi.Text = currentMusic.Artists;
            currSong1.labelAlbum.Text = currentMusic.Album.Title;
        }
    }
}