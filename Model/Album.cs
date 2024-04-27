using System.Collections.Generic;

namespace MusicPlayer.Model
{
    public class Album : BaseEntity
    {
        public Album()
        {
        }

        public Album(List<Music> musics)
        {
            Musics = musics;
        }

        public Album(string id, string title, string thumbnail, string thumbnailM, string artists, List<Music> musics) :
            base(id, title, thumbnail, thumbnailM, artists)
        {
            Musics = musics;
        }
        
        public string ShortDescription { get; set; }

        public List<Music> Musics { get; set; }
    }
}