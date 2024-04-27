using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MusicPlayer.Model;

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
            if (album != null && IsAlbumList(playlists, album))
            {
                albumPanel.Visible = true;
                albumTitle.Text = album.Title;
                artists.Text = album.Artists;
                ShortDescription.Text = album.ShortDescription;
                var isLoaded = false;
                while (!isLoaded)
                    try
                    {
                        Guna2PictureBox6.Load(album.ThumbnailM);
                        isLoaded = true;
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại kết nối mạng", "Lỗi", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
            }
            else
            {
                albumPanel.Visible = false;
            }

            normalSection1.mainForm = mainForm;
            normalSection1.ClearItems();
            foreach (var music in playlists)
                normalSection1.AddItem(music, 1);
        }

        private bool IsAlbumList(List<Music> musics, Album album)
        {
            if (musics.Count == 0) return false;
            foreach (var music in musics)
                if (music.Album != album)
                    return false;
            return true;
        }
    }
}