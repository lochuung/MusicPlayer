namespace MusicPlayer.Model
{
    public class Music : BaseEntity
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

        public string Genres { get; set; }

        public Album Album { get; set; }
    }
}