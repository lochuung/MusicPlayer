using System.Collections.Generic;

namespace MusicPlayer.Model
{
    public class Album
    {
        public Album()
        {
        }

        public Album(string id, string title, List<Music> musics)
        {
            Id = id;
            Title = title;
            Musics = musics;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public List<Music> Musics { get; set; }
    }
}