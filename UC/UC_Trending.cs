﻿using System;
using System.Windows.Forms;
using MusicPlayer.Model;
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
            AddTrendingSongs(data.RTChart.items);
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

        private void AddTrendingSongs(JArray trending)
        {
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
                ranking1.AddItem(music);
            }
        }
    }
}