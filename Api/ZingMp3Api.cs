using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicPlayer.Model;
using MusicPlayer.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WaitFormExample;

namespace MusicPlayer.MusicApi
{
    public class ZingMp3Api
    {
        public ZingMp3Api()
        {
            WaitForm.StartPosition = FormStartPosition.CenterScreen;
            Url = "https://zingmp3.vn";
            Version = "1.6.34";
            SecretKey = "2aa2d1c561e809b267f3638c4a307aab";
            ApiKey = "88265e23d4284f25963e6eedac8fbfa3";
            var timestamp = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1))
                .TotalSeconds;
            Ctime = Math.Floor(timestamp).ToString();
        }

        public ZingMp3Api(string version, string url,
            string secretKey, string apiKey,
            string ctime)
        {
            Version = version;
            Url = url;
            SecretKey = secretKey;
            ApiKey = apiKey;
            Ctime = ctime;
        }

        public string Version { get; set; }

        public string Url { get; set; }

        public string SecretKey { get; set; }

        public string ApiKey { get; set; }

        public string Ctime { get; set; }

        public WaitForm WaitForm { get; set; } = new WaitForm();

        public async Task<string> GetSongInfo(string id)
        {
            WaitForm.Show();
            var response = await ZingMp3ApiUtils.GetSongInfo(this, id);
            WaitForm.Hide();
            return response;
        }

        public async Task<string> GetStreamingUrl(string id)
        {
            WaitForm.Show();

            var response = await ZingMp3ApiUtils.GetSong(this, id);
            var json = JObject.Parse(response);
            var streamingUrl = json["128"].ToString();

            WaitForm.Hide();
            return streamingUrl;
        }

        public async Task<List<Music>> GetTrendingSongs()
        {
            WaitForm.Show();
            var response = await ZingMp3ApiUtils.GetChartHome(this);
            dynamic responseDeserializeObject = JsonConvert.DeserializeObject(response);
            JArray songArray = responseDeserializeObject.RTChart.items;
            var musics = new List<Music>();

            foreach (dynamic song in songArray)
            {
                var music = new Music();
                music.Id = song.encodeId;
                music.Title = song.title;
                music.Artists = song.artistsNames;
                music.ThumbnailM = song.thumbnailM;
                music.Thumbnail = song.thumbnail;
                music.Album = new Album();
                music.Album.Id = song.album.encodeId;
                music.Album.Title = song.album.title;
                musics.Add(music);
            }

            WaitForm.Hide();
            return musics;
        }
    }
}