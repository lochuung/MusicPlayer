using System.Windows.Forms;
using MusicPlayer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MusicPlayer.UC
{
    public partial class UC_Trending : UserControl
    {
        public string JsonData {  get; set; }

        public UC_Trending() : this("")
        {
        }

        public UC_Trending(string jsonData)
        {
            JsonData = jsonData;
            InitializeComponent();
        }

        private void UC_Trending_Load(object sender, System.EventArgs e)
        {
            dynamic data = JsonConvert.DeserializeObject(JsonData);
            AddPromoteSongs(data.RTChart.promotes);
        }
        
        private void AddPromoteSongs(JArray promotes)
        {
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
    }
}