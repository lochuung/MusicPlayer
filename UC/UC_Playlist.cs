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
            if (album != null && IsAlbumList(playlists))
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

            normalSection1.mainForm = mainForm;
            normalSection1.ClearItems();
            foreach (var music in playlists)
                normalSection1.AddItem(music, 1);
        }

        private bool IsAlbumList(List<Music> musics)
        {
            if (musics.Count == 0) return false;
            var album = musics[0].Album;
            foreach (var music in musics)
                if (music.Album != album)
                    return false;
            return true;
        }
    }
}