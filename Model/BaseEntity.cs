namespace MusicPlayer.Model
{
    public class BaseEntity
    {
        public BaseEntity()
        {
        }

        public BaseEntity(string id, string title, string thumbnail, string thumbnailM, string artists)
        {
            Id = id;
            Title = title;
            Thumbnail = thumbnail;
            ThumbnailM = thumbnailM;
            Artists = artists;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        public string ThumbnailM { get; set; }

        public string Artists { get; set; }
    }
}