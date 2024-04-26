using System;
using System.Windows.Forms;

namespace MusicPlayer.UC
{
    public partial class UC_Playlist : UserControl
    {
        public MusicPlayerForm mainForm;

        public UC_Playlist()
        {
            InitializeComponent();
        }

        private void UC_Playlist_Load(object sender, EventArgs e)
        {
            if (mainForm == null) mainForm = (MusicPlayerForm)FindForm();
            normalSection1.Title.Text = "Các bài hát trong playlist/album";
            normalSection1.Title.Left = (normalSection1.Width - normalSection1.Title.Width) / 2;
            LoadPlaylists();
        }

        public void LoadPlaylists()
        {
            var playlists = mainForm.musicList;
            if (playlists == null || playlists.Count == 0) return;
            var album = mainForm.currentAlbum;
            if (album != null && playlists == album.Musics)
            {
                albumPanel.Visible = true;
                albumItem.SetTitle(album.Title);
                albumItem.SetImage(album.ThumbnailM);
                albumItem.SetArtist(album.Artists);
            }
            else
            {
                albumPanel.Visible = false;
            }
            normalSection1.ClearItems();
            foreach (var music in playlists) 
                normalSection1.AddItem(music, 1);
        }
    }
}