using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MusicPlayer.Model;
using MusicPlayer.UC.ChildrenUC;

namespace MusicPlayer.UC
{
    public partial class UC_Home : UserControl
    {
        public List<dynamic> homeData = new List<dynamic>();

        public UC_Home()
        {
            InitializeComponent();
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            var mainForm = (MusicPlayerForm)FindForm();
            foreach (var item in homeData)
                if (item.sectionType == "playlist")
                {
                    var largeSection = new LargeSection();
                    largeSection.mainForm = mainForm;
                    largeSection.Title.Text = item.title;
                    foreach (var playlist in item.items)
                    {
                        var album = new Album
                        {
                            Id = playlist.encodeId,
                            Title = playlist.title,
                            Artists = playlist.artistsNames,
                            ShortDescription = playlist.sortDescription,
                            Thumbnail = playlist.thumbnail,
                            ThumbnailM = playlist.thumbnailM
                        };
                        largeSection.AddItem(album, false);
                    }

                    largeSection.Width = flowLayoutPanel1.Width - 30;
                    flowLayoutPanel1.Controls.Add(largeSection);
                }
        }
    }
}