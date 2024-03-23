namespace MusicPlayer.MusicApi
{
    public class ZingMp3Api
    {
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
    }
}