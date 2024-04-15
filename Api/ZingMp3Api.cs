using System;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicPlayer.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WaitFormExample;

namespace MusicPlayer.MusicApi
{
    public class ZingMp3Api
    {
        private WaitForm waitForm = new WaitForm();
        public ZingMp3Api()
        {
            
            waitForm.StartPosition = FormStartPosition.CenterScreen;
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

        public async Task<string> GetSongInfo(string id)
        {
            waitForm.Show();
            var response = await ZingMp3ApiUtils.GetSongInfo(this, id);
            waitForm.Hide();
            return response;
        }
        
        public async Task<string> GetStreamingUrl(string id)
        {
            waitForm.Show();
            
            string response = await ZingMp3ApiUtils.GetSong(this, id);
            JObject json = JObject.Parse(response);
            string streamingUrl = json["128"].ToString();
            
            waitForm.Hide();
            return streamingUrl;
        }
    }
}