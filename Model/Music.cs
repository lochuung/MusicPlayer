using System.Threading.Tasks;
using MusicPlayer.MusicApi;

namespace MusicPlayer.Model
{
    public class Music : BaseEntity
    {
        public Music()
        {
        }

        public Music(string id)
        {
            Id = id;
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

        public async Task LoadMusicFromId(ZingMp3Api api)
        {
            var music = await api.GetSongInfo(Id);
            Title = music.Title;
            Artists = music.Artists;
            ThumbnailM = music.ThumbnailM;
            Thumbnail = music.Thumbnail;
            Genres = music.Genres;
            Album = music.Album;
        }
    }
}