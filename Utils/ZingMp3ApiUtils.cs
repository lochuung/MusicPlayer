using System.Collections.Generic;
using MusicPlayer.MusicApi;

namespace MusicPlayer.Utils
{
    public class ZingMp3ApiUtils
    {
        private static readonly string SONG_PATH = "/api/v2/song/get/streaming";

        private static readonly string PLAYLIST_DETAIL_PATH = "/api/v2/page/get/playlist";

        private static readonly string HOME_PATH = "/api/v2/page/get/home";

        private static readonly string TOP100_PATH = "/api/v2/page/get/top100";

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

        public static string GetPlaylistDetail(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(PLAYLIST_DETAIL_PATH, api, id) }
            };
            return RequestUtils.GetResponse(api, PLAYLIST_DETAIL_PATH, param)
                .Result;
        }

        public static string GetHome(ZingMp3Api api)
        {
            var param = new Dictionary<string, string>
            {
                { "page", "1" },
                { "segmentId", "-1" },
                { "count", "30" },
                { "sig", HashingUtils.HashParamNoId(HOME_PATH, api) }
            };
            return RequestUtils.GetResponse(api, HOME_PATH, param)
                .Result;
        }

        public static string GetTop100(ZingMp3Api api)
        {
            var param = new Dictionary<string, string>
            {
                { "sig", HashingUtils.HashParamNoId(TOP100_PATH, api) }
            };
            return RequestUtils.GetResponse(api, TOP100_PATH, param)
                .Result;
        }

        public static string GetChartHome(ZingMp3Api api)
        {
            var param = new Dictionary<string, string>
            {
                { "sig", HashingUtils.HashParamNoId(CHART_HOME_PATH, api) }
            };
            return RequestUtils.GetResponse(api, CHART_HOME_PATH, param)
                .Result;
        }

        public static string GetNewReleaseChart(ZingMp3Api api)
        {
            var param = new Dictionary<string, string>
            {
                { "sig", HashingUtils.HashParamNoId(NEW_RELEASE_CHART_PATH, api) }
            };
            return RequestUtils.GetResponse(api, NEW_RELEASE_CHART_PATH, param)
                .Result;
        }

        public static string GetSongInfo(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(SONG_INFO_PATH, api, id) }
            };
            return RequestUtils.GetResponse(api, SONG_INFO_PATH, param)
                .Result;
        }

        public static string GetArtistSongList(ZingMp3Api api, string id, int page, int count)
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
            return RequestUtils.GetResponse(api, ARTIST_SONG_LIST_PATH, param)
                .Result;
        }

        public static string GetArtist(ZingMp3Api api, string name)
        {
            var param = new Dictionary<string, string>
            {
                { "alias", name },
                { "sig", HashingUtils.HashParamNoId(ARTIST_PATH, api) }
            };
            return RequestUtils.GetResponse(api, ARTIST_PATH, param)
                .Result;
        }

        public static string GetLyric(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(LYRIC_PATH, api, id) }
            };
            return RequestUtils.GetResponse(api, LYRIC_PATH, param)
                .Result;
        }

        public static string Search(ZingMp3Api api, string keyword)
        {
            var param = new Dictionary<string, string>
            {
                { "q", keyword },
                { "sig", HashingUtils.HashParamNoId(SEARCH_PATH, api) }
            };
            return RequestUtils.GetResponse(api, SEARCH_PATH, param)
                .Result;
        }

        public static string GetMvList(ZingMp3Api api, string id, int page, int count)
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
            return RequestUtils.GetResponse(api, MV_LIST_PATH, param)
                .Result;
        }

        public static string GetMvCategory(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "type", "video" },
                { "sig", HashingUtils.HashCategoryMv(MV_CATEGORY_PATH, api, id, "video") }
            };
            return RequestUtils.GetResponse(api, MV_CATEGORY_PATH, param)
                .Result;
        }

        public static string GetMv(ZingMp3Api api, string id)
        {
            var param = new Dictionary<string, string>
            {
                { "id", id },
                { "sig", HashingUtils.HashParam(MV_PATH, api, id) }
            };
            return RequestUtils.GetResponse(api, MV_PATH, param)
                .Result;
        }
    }
}