using System.Collections.Generic;
using MusicPlayer.MusicApi;

namespace MusicPlayer.Utils
{
    public class ZingMp3ApiUtils
    {
        private static readonly string SONG_PATH = "/api/v2/song/get/streaming";

        public static string GetSong(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(SONG_PATH, api, id) }
            };
            return RequestUtils.GetResponse(api, SONG_PATH, param)
                .Result;
        }
    }
}