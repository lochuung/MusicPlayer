using System;
using System.Windows.Forms;
using MusicPlayer.Model;
using MusicPlayer.UC.Trending;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MusicPlayer.UC
{
    public partial class UC_Trending : UserControl
    {
        public UC_Trending() : this("")
        {
        }

        public UC_Trending(string jsonData)
        {
            JsonData = jsonData;
            InitializeComponent();
        }

        public string JsonData { get; set; }

        private void UC_Trending_Load(object sender, EventArgs e)
        {
            dynamic data = JsonConvert.DeserializeObject(JsonData);
            AddPromoteSongs(data.RTChart.promotes);
            AddNewReleaseSongs(data.newRelease);
            AddTopVNSongs(data.weekChart.vn.items);
            AddTopKRSongs(data.weekChart.korea.items);
            AddTrendingSongs(data.RTChart.items);
        }

        private void AddPromoteSongs(JArray promotes)
        {
            promoteUC.Title.Text = "Gợi ý tuần này";
            // set center title
            promoteUC.Title.Left = (promoteUC.Width - promoteUC.Title.Width) / 2;
            foreach (dynamic promote in promotes)
            {
                if (promote.streamingStatus != 1) continue;
                var music = new Music
                {
                    Id = promote.encodeId,
                    Title = promote.title,
                    Artists = promote.artistsNames,
                    Thumbnail = promote.thumbnail,
                    ThumbnailM = promote.thumbnailM
                };
                promoteUC.AddItem(music);
            }
        }

        private void AddTopVNSongs(JArray vnSongs)
        {
            topVN.Title.Text = "Bảng xếp hạng nhạc Việt theo tuần";
            // set center title
            topVN.Title.Left = (topVN.Width - topVN.Title.Width) / 2;
            foreach (dynamic promote in vnSongs)
            {
                if (promote.streamingStatus != 1) continue;
                var music = new Music
                {
                    Id = promote.encodeId,
                    Title = promote.title,
                    Artists = promote.artistsNames,
                    Thumbnail = promote.thumbnail,
                    ThumbnailM = promote.thumbnailM
                };
                topVN.AddItem(music);
            }

            SetNonScrollable(topVN);
        }

        private void AddTopKRSongs(JArray krSongs)
        {
            topKR.Title.Text = "Bảng xếp hạng nhạc Hàn theo tuần";
            // set center title
            topKR.Title.Left = (topKR.Width - topKR.Title.Width) / 2;
            foreach (dynamic promote in krSongs)
            {
                if (promote.streamingStatus != 1) continue;
                var music = new Music
                {
                    Id = promote.encodeId,
                    Title = promote.title,
                    Artists = promote.artistsNames,
                    Thumbnail = promote.thumbnail,
                    ThumbnailM = promote.thumbnailM
                };
                topKR.AddItem(music);
            }

            SetNonScrollable(topKR);
        }

        private void AddTrendingSongs(JArray trending)
        {
            top100.Title.Text = "Top 100 trending";
            // set center title
            top100.Title.Left = (top100.Width - top100.Title.Width) / 2;
            foreach (dynamic promote in trending)
            {
                if (promote.streamingStatus != 1) continue;
                var music = new Music
                {
                    Id = promote.encodeId,
                    Title = promote.title,
                    Artists = promote.artistsNames,
                    Thumbnail = promote.thumbnail,
                    ThumbnailM = promote.thumbnailM
                };
                top100.AddItem(music);
            }

            SetNonScrollable(top100);
        }

        private void AddNewReleaseSongs(JArray newReleaseSongs)
        {
            newRelease1.Title.Text = "Bài hát mới phát hành";
            // set center title
            newRelease1.Title.Left = (newRelease1.Width - newRelease1.Title.Width) / 2;
            foreach (dynamic promote in newReleaseSongs)
            {
                if (promote.streamingStatus != 1) continue;
                var music = new Music
                {
                    Id = promote.encodeId,
                    Title = promote.title,
                    Artists = promote.artistsNames,
                    Thumbnail = promote.thumbnail,
                    ThumbnailM = promote.thumbnailM
                };
                newRelease1.AddItem(music);
            }

            SetNonScrollable(newRelease1);
        }

        private void SetNonScrollable(NormalSection normalSection)
        {
            // turn off auto scroll and show all items in flow layout panel
            normalSection.MusicList.AutoScroll = false;
            normalSection.MusicList.WrapContents = true;

            // set height of flow layout panel
            var itemHeight = new UC_MusicItem().Height;
            var height =
                (int)Math.Floor((double)normalSection.musics.Count * itemHeight / 3.0) + itemHeight;
            normalSection.Height = height + normalSection.Guna2Panel1.Height;
            normalSection.MusicList.Height = height;
        }
    }
}