using System.Collections.Generic;

namespace MusicPlayer.Model
{
    public class Album
    {
        private string id;
        private string title;
        private List<Music> _musics;

        public Album()
        {
        }

        public Album(string id, string title, List<Music> musics)
        {
            this.id = id;
            this.title = title;
            _musics = musics;
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

        public List<Music> Musics
        {
            get => _musics;
            set => _musics = value;
        }
    }
}