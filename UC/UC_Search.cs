using System;
using System.Windows.Forms;
using MusicPlayer.Model;
using Newtonsoft.Json;

namespace MusicPlayer.UC
{
    public partial class UC_Search : UserControl
    {
        public string searchData;

        public UC_Search()
        {
            InitializeComponent();
        }

        private void UC_Search_Load(object sender, EventArgs e)
        {
            noResultLabel.Left = (Width - noResultLabel.Width) / 2;
            LoadData();
        }

        public void LoadData()
        {
            if (string.IsNullOrEmpty(searchData)) return;

            dynamic json = JsonConvert.DeserializeObject(searchData);
            bool hasResult = json.counter.song > 0 || json.counter.playlist > 0 || json.counter.artist > 0;
            if (hasResult)
            {
                noResultLabel.Visible = false;
            }
            else
            {
                noResultLabel.Visible = true;
                noResultLabel.Left = (Width - noResultLabel.Width) / 2;
            }
            if (json.counter.song > 0)
                AddSongsResult(json.songs);
            else songSection.Visible = false;
            if (json.counter.playlist > 0)
                AddPlaylistsResult(json.playlists);
            else playlistSection.Visible = false;
            if (json.counter.artist > 0)
                AddArtistsResult(json.artists);
        }

        private void AddSongsResult(dynamic songs)
        {
            songSection.Visible = true;
            songSection.Title.Text = "Bài Hát";
            songSection.Title.Left = (songSection.Width - songSection.Title.Width) / 2;
            songSection.ClearItems();
            foreach (var song in songs)
            {
                if (song.streamingStatus != 1) continue;
                var music = new Music
                {
                    Id = song.encodeId,
                    Title = song.title,
                    Artists = song.artistsNames,
                    Thumbnail = song.thumbnail,
                    ThumbnailM = song.thumbnailM
                };
                songSection.AddItem(music, 2);
            }
        }

        private void AddPlaylistsResult(dynamic playlists)
        {
            playlistSection.Visible = true;
            playlistSection.Title.Text = "Playlist/Album";
            playlistSection.Title.Left = (playlistSection.Width - playlistSection.Title.Width) / 2;
            playlistSection.ClearItems();
            foreach (var playlist in playlists)
            {
                var album = new Album
                {
                    Id = playlist.encodeId,
                    Title = playlist.title,
                    Artists = playlist.artistsNames,
                    Thumbnail = playlist.thumbnail,
                    ThumbnailM = playlist.thumbnailM
                };
                playlistSection.AddItem(album);
            }
        }

        private void AddArtistsResult(dynamic artists)
        {
        }
    }
}