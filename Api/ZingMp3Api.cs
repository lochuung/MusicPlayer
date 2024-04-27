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
        public ZingMp3Api() : this(null)
        {
        }

        public ZingMp3Api(MusicPlayerForm musicPlayerForm)
        {
            WaitForm = new WaitForm(musicPlayerForm);
            Task.Run(() =>
            {
                Application.Run(WaitForm);
                WaitForm.Hide();
            });
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

        public WaitForm WaitForm { get; set; }

        public async Task<List<dynamic>> GetHomeData()
        {
            WaitForm.Show();

            var response = await ZingMp3ApiUtils.GetHome(this);
            dynamic responseDeserializeObject = JsonConvert.DeserializeObject(response);
            var data = new List<dynamic>();
            foreach (var item in responseDeserializeObject.items) data.Add(item);

            WaitForm.Hide();

            return data;
        }
        
        public async Task<List<Music>> GetNewReleaseData()
        {
            WaitForm.Show();

            var response = await ZingMp3ApiUtils.GetNewReleaseChart(this);
            dynamic responseDeserializeObject = JsonConvert.DeserializeObject(response);
            var data = new List<Music>();
            foreach (var item in responseDeserializeObject.items)
            {
                if (item.streamingStatus != 1) continue;
                var music = new Music
                {
                    Id = item.encodeId,
                    Title = item.title,
                    Artists = item.artistsNames,
                    Thumbnail = item.thumbnail,
                    ThumbnailM = item.thumbnailM
                };
                music.Album = new Album
                {
                    Id = item.album.encodeId,
                    Title = item.album.title,
                    Artists = item.album.artistsNames,
                    Thumbnail = item.album.thumbnail,
                    ThumbnailM = item.album.thumbnailM,
                    ShortDescription = item.album.sortDescription
                };
                data.Add(music);
            }

            WaitForm.Hide();

            return data;
        }

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

        public async Task<dynamic> GetTrendingData()
        {
            WaitForm.Show();
            var response = await ZingMp3ApiUtils.GetChartHome(this);
            dynamic responseDeserializeObject = JsonConvert.DeserializeObject(response);
            WaitForm.Hide();
            return responseDeserializeObject;
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
                if (song.streamingStatus != 1) continue;
                var music = new Music();
                music.Id = song.encodeId;
                music.Title = song.title;
                music.Artists = song.artistsNames;
                music.ThumbnailM = song.thumbnailM;
                music.Thumbnail = song.thumbnail;
                music.Album = new Album
                {
                    Id = song.album.encodeId,
                    Title = song.album.title,
                    Artists = song.album.artistsNames,
                    Thumbnail = song.album.thumbnail,
                    ThumbnailM = song.album.thumbnailM,
                    ShortDescription = song.album.sortDescription
                };
                musics.Add(music);
            }

            WaitForm.Hide();
            return musics;
        }

        public async Task<string> GetSearchData(string query)
        {
            WaitForm.Show();
            var response = await ZingMp3ApiUtils.Search(this, query);
            WaitForm.Hide();
            return response;
        }

        public async Task<List<Music>> GetMusicListFromAlbum(string albumId)
        {
            WaitForm.Show();
            var response = await ZingMp3ApiUtils.GetPlaylistDetail(this, albumId);
            dynamic responseDeserializeObject = JsonConvert.DeserializeObject(response);
            JArray songArray = responseDeserializeObject.song.items;
            var musics = new List<Music>();

            foreach (dynamic song in songArray)
            {
                if (song.streamingStatus != 1) continue;
                var music = new Music();
                music.Id = song.encodeId;
                music.Title = song.title;
                music.Artists = song.artistsNames;
                music.ThumbnailM = song.thumbnailM;
                music.Thumbnail = song.thumbnail;
                musics.Add(music);
            }

            WaitForm.Hide();
            return musics;
        }
    }
}