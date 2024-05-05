using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPlayer.MusicApi;

namespace MusicPlayer.Utils
{
    public class ZingMp3ApiUtils
    {
        private static readonly string SONG_PATH = "/api/v2/song/get/streaming";

        private static readonly string PLAYLIST_DETAIL_PATH = "/api/v2/page/get/playlist";

        private static readonly string HOME_PATH = "/api/v2/page/get/home";

        private static readonly string TOP100_PATH = "/api/v2/page/get/top-100";

        private static readonly string CHART_HOME_PATH = "/api/v2/page/get/chart-home";

        private static readonly string NEW_RELEASE_CHART_PATH = "/api/v2/page/get/newrelease-chart";

        private static readonly string SONG_INFO_PATH = "/api/v2/song/get/info";

        private static readonly string ARTIST_SONG_LIST_PATH = "/api/v2/song/get/list";

        private static readonly string ARTIST_PATH = "/api/v2/page/get/artist";

        private static readonly string LYRIC_PATH = "/api/v2/lyric/get/lyric";

        private static readonly string SEARCH_PATH = "/api/v2/search/multi";

        private static readonly string MV_LIST_PATH = "/api/v2/video/get/list";

        private static readonly string MV_CATEGORY_PATH = "/api/v2/genre/get/info";

        private static readonly string MV_PATH = "/api/v2/page/get/video";

        public static async Task<string> GetSong(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(SONG_PATH, api, id) }
            };
            return await RequestUtils.GetResponse(api, SONG_PATH, param);
        }

        public static async Task<string> GetPlaylistDetail(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(PLAYLIST_DETAIL_PATH, api, id) }
            };
            return await RequestUtils.GetResponse(api, PLAYLIST_DETAIL_PATH, param);
        }

        public static async Task<string> GetHome(ZingMp3Api api)
        {
            var param = new Dictionary<string, string>
            {
                { "page", "1" },
                { "segmentId", "-1" },
                { "count", "30" },
                { "sig", HashingUtils.HashParamHome(HOME_PATH, api) }
            };
            return await RequestUtils.GetResponse(api, HOME_PATH, param);
        }

        public static async Task<string> GetTop100(ZingMp3Api api)
        {
            var param = new Dictionary<string, string>
            {
                { "sig", HashingUtils.HashParamNoId(TOP100_PATH, api) }
            };
            return await RequestUtils.GetResponse(api, TOP100_PATH, param);
        }

        public static async Task<string> GetChartHome(ZingMp3Api api)
        {
            var param = new Dictionary<string, string>
            {
                { "sig", HashingUtils.HashParamNoId(CHART_HOME_PATH, api) }
            };
            return await RequestUtils.GetResponse(api, CHART_HOME_PATH, param);
        }

        public static async Task<string> GetNewReleaseChart(ZingMp3Api api)
        {
            var param = new Dictionary<string, string>
            {
                { "sig", HashingUtils.HashParamNoId(NEW_RELEASE_CHART_PATH, api) }
            };
            return await RequestUtils.GetResponse(api, NEW_RELEASE_CHART_PATH, param);
        }

        public static async Task<string> GetSongInfo(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(SONG_INFO_PATH, api, id) }
            };
            var response = await RequestUtils.GetResponse(api, SONG_INFO_PATH, param);
            return response;
        }

        public static async Task<string> GetArtistSongList(ZingMp3Api api, string id, int page, int count)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "type", "artist" },
                { "page", page.ToString() },
                { "count", count.ToString() },
                { "sort", "new" },
                { "sectionId", "aSong" },
                {
                    "sig", HashingUtils.HashListMv(ARTIST_SONG_LIST_PATH, api, id, "artist", page.ToString(),
                        count.ToString())
                }
            };
            return await RequestUtils.GetResponse(api, ARTIST_SONG_LIST_PATH, param);
        }

        public static async Task<string> GetArtist(ZingMp3Api api, string name)
        {
            var param = new Dictionary<string, string>
            {
                { "alias", name },
                { "sig", HashingUtils.HashParamNoId(ARTIST_PATH, api) }
            };
            return await RequestUtils.GetResponse(api, ARTIST_PATH, param);
        }

        public static async Task<string> GetLyric(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(LYRIC_PATH, api, id) }
            };
            return await RequestUtils.GetResponse(api, LYRIC_PATH, param);
        }

        public static async Task<string> Search(ZingMp3Api api, string keyword)
        {
            var param = new Dictionary<string, string>
            {
                { "q", keyword },
                { "sig", HashingUtils.HashParamNoId(SEARCH_PATH, api) }
            };
            return await RequestUtils.GetResponse(api, SEARCH_PATH, param);
        }

        public static async Task<string> GetMvList(ZingMp3Api api, string id, int page, int count)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "type", "genre" },
                { "page", page.ToString() },
                { "count", count.ToString() },
                { "sort", "listen" },
                { "sig", HashingUtils.HashListMv(MV_LIST_PATH, api, id, "genre", page.ToString(), count.ToString()) }
            };
            return await RequestUtils.GetResponse(api, MV_LIST_PATH, param);
        }

        public static async Task<string> GetMvCategory(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "type", "video" },
                { "sig", HashingUtils.HashCategoryMv(MV_CATEGORY_PATH, api, id, "video") }
            };
            return await RequestUtils.GetResponse(api, MV_CATEGORY_PATH, param);
        }

        public static async Task<string> GetMv(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(MV_PATH, api, id) }
            };
            return await RequestUtils.GetResponse(api, MV_PATH, param);
        }
    }
}