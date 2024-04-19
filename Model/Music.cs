using System.IO;

namespace MusicPlayer.Model
{
    public class Music
    {
        public Music()
        {
        }

        public Music(string id, string title, string artists, string thumbnailM, string thumbnail, string genres,
            Album album)
        {
            Id = id;
            Title = title;
            Artists = artists;
            ThumbnailM = thumbnailM;
            Thumbnail = thumbnail;
            Genres = genres;
            Album = album;
        }

        public string Composers { get; set; }

        public Stream ThumbnailStream { get; set; }

        public Stream ThumbnailMStream { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Artists { get; set; }

        public string Genres { get; set; }

        public Album Album { get; set; }

        public string ThumbnailM { get; set; }

        public string Thumbnail { get; set; }
    }
}