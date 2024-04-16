using System.IO;

namespace MusicPlayer.Model
{
    public class Music
    {
        private string id;
        private string title;
        private string artists;
        private string thumbnailM;
        private string thumbnail;
        private string genres;
        private string composers;
        private Album _album;
        private Stream thumbnailStream;
        private Stream thumbnailMStream;

        public Music()
        {
        }

        public Music(string id, string title, string artists, string thumbnailM, string thumbnail, string genres, Album album)
        {
            this.id = id;
            this.title = title;
            this.artists = artists;
            this.thumbnailM = thumbnailM;
            this.thumbnail = thumbnail;
            this.genres = genres;
            _album = album;
        }

        public string Composers
        {
            get => composers;
            set => composers = value;
        }

        public Stream ThumbnailStream
        {
            get => thumbnailStream;
            set => thumbnailStream = value;
        }

        public Stream ThumbnailMStream
        {
            get => thumbnailMStream;
            set => thumbnailMStream = value;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Artists
        {
            get => artists;
            set => artists = value;
        }

        public string Genres
        {
            get => genres;
            set => genres = value;
        }

        public Album Album
        {
            get => _album;
            set => _album = value;
        }

        public string ThumbnailM
        {
            get => thumbnailM;
            set => thumbnailM = value;
        }

        public string Thumbnail
        {
            get => thumbnail;
            set => thumbnail = value;
        }
    }
}