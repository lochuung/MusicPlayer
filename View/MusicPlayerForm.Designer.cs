namespace MusicPlayer
{
    partial class MusicPlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayerForm));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.loveMusic = new Guna.UI2.WinForms.Guna2Button();
            this.playListBtn = new Guna.UI2.WinForms.Guna2Button();
            this.searchPageBtn = new Guna.UI2.WinForms.Guna2Button();
            this.releaseBtn = new Guna.UI2.WinForms.Guna2Button();
            this.trendingBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.homeBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnExitMainForm = new Guna.UI2.WinForms.Guna2Button();
            this.searchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.songTitle = new System.Windows.Forms.Label();
            this.muteBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.endTime = new System.Windows.Forms.Label();
            this.currentTime = new System.Windows.Forms.Label();
            this.volumeTrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
            this.musicTrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
            this.shuffleBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.playBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.nextBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.repeatBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.prevBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.artistsName = new System.Windows.Forms.Label();
            this.thumbnailImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.containerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.changePW = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailImage)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.changePW);
            this.guna2Panel1.Controls.Add(this.loveMusic);
            this.guna2Panel1.Controls.Add(this.playListBtn);
            this.guna2Panel1.Controls.Add(this.searchPageBtn);
            this.guna2Panel1.Controls.Add(this.releaseBtn);
            this.guna2Panel1.Controls.Add(this.trendingBtn);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.homeBtn);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(244, 753);
            this.guna2Panel1.TabIndex = 0;
            // 
            // loveMusic
            // 
            this.loveMusic.Animated = true;
            this.loveMusic.BackColor = System.Drawing.Color.Transparent;
            this.loveMusic.BorderRadius = 10;
            this.loveMusic.CustomImages.HoveredImage = global::MusicPlayer.Properties.Resources.love_100px_png1;
            this.loveMusic.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.loveMusic.CustomImages.ImageSize = new System.Drawing.Size(25, 25);
            this.loveMusic.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.loveMusic.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.loveMusic.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.loveMusic.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.loveMusic.FillColor = System.Drawing.Color.White;
            this.loveMusic.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.loveMusic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(180)))), ((int)(((byte)(195)))));
            this.loveMusic.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(142)))));
            this.loveMusic.Image = global::MusicPlayer.Properties.Resources.love_100px;
            this.loveMusic.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.loveMusic.ImageSize = new System.Drawing.Size(25, 25);
            this.loveMusic.Location = new System.Drawing.Point(32, 440);
            this.loveMusic.Name = "loveMusic";
            this.loveMusic.Size = new System.Drawing.Size(180, 45);
            this.loveMusic.TabIndex = 9;
            this.loveMusic.Text = "Nhạc yêu thích";
            this.loveMusic.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.loveMusic.UseTransparentBackground = true;
            this.loveMusic.Click += new System.EventHandler(this.loveMusic_Click);
            // 
            // playListBtn
            // 
            this.playListBtn.Animated = true;
            this.playListBtn.BackColor = System.Drawing.Color.Transparent;
            this.playListBtn.BorderRadius = 10;
            this.playListBtn.CustomImages.HoveredImage = global::MusicPlayer.Properties.Resources.albums_100px_png1;
            this.playListBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.playListBtn.CustomImages.ImageSize = new System.Drawing.Size(25, 25);
            this.playListBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.playListBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.playListBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.playListBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.playListBtn.FillColor = System.Drawing.Color.White;
            this.playListBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.playListBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(180)))), ((int)(((byte)(195)))));
            this.playListBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(142)))));
            this.playListBtn.Image = global::MusicPlayer.Properties.Resources.albums_100px;
            this.playListBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.playListBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.playListBtn.Location = new System.Drawing.Point(32, 338);
            this.playListBtn.Name = "playListBtn";
            this.playListBtn.Size = new System.Drawing.Size(180, 45);
            this.playListBtn.TabIndex = 8;
            this.playListBtn.Text = "Playlist/Album";
            this.playListBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.playListBtn.Click += new System.EventHandler(this.currentListBtn_Click);
            // 
            // searchPageBtn
            // 
            this.searchPageBtn.Animated = true;
            this.searchPageBtn.BackColor = System.Drawing.Color.Transparent;
            this.searchPageBtn.BorderRadius = 10;
            this.searchPageBtn.CustomImages.HoveredImage = global::MusicPlayer.Properties.Resources.search_100px_png1;
            this.searchPageBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchPageBtn.CustomImages.ImageSize = new System.Drawing.Size(25, 25);
            this.searchPageBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.searchPageBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.searchPageBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.searchPageBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.searchPageBtn.FillColor = System.Drawing.Color.White;
            this.searchPageBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.searchPageBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(180)))), ((int)(((byte)(195)))));
            this.searchPageBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(142)))));
            this.searchPageBtn.Image = global::MusicPlayer.Properties.Resources.search_100px;
            this.searchPageBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchPageBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.searchPageBtn.Location = new System.Drawing.Point(32, 389);
            this.searchPageBtn.Name = "searchPageBtn";
            this.searchPageBtn.Size = new System.Drawing.Size(180, 45);
            this.searchPageBtn.TabIndex = 5;
            this.searchPageBtn.Text = "Tìm kiếm";
            this.searchPageBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchPageBtn.UseTransparentBackground = true;
            this.searchPageBtn.Click += new System.EventHandler(this.searchPageBtn_Click);
            // 
            // releaseBtn
            // 
            this.releaseBtn.Animated = true;
            this.releaseBtn.BackColor = System.Drawing.Color.Transparent;
            this.releaseBtn.BorderRadius = 10;
            this.releaseBtn.CustomImages.HoveredImage = global::MusicPlayer.Properties.Resources.music_100px_png1;
            this.releaseBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.releaseBtn.CustomImages.ImageSize = new System.Drawing.Size(25, 25);
            this.releaseBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.releaseBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.releaseBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.releaseBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.releaseBtn.FillColor = System.Drawing.Color.White;
            this.releaseBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.releaseBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(180)))), ((int)(((byte)(195)))));
            this.releaseBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(142)))));
            this.releaseBtn.Image = global::MusicPlayer.Properties.Resources.music_100px;
            this.releaseBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.releaseBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.releaseBtn.Location = new System.Drawing.Point(32, 287);
            this.releaseBtn.Name = "releaseBtn";
            this.releaseBtn.Size = new System.Drawing.Size(180, 45);
            this.releaseBtn.TabIndex = 3;
            this.releaseBtn.Text = "Mới phát hành";
            this.releaseBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.releaseBtn.UseTransparentBackground = true;
            this.releaseBtn.Click += new System.EventHandler(this.releaseBtn_Click);
            // 
            // trendingBtn
            // 
            this.trendingBtn.Animated = true;
            this.trendingBtn.BackColor = System.Drawing.Color.Transparent;
            this.trendingBtn.BorderRadius = 10;
            this.trendingBtn.CustomImages.HoveredImage = global::MusicPlayer.Properties.Resources.positive_dynamic_128;
            this.trendingBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.trendingBtn.CustomImages.ImageSize = new System.Drawing.Size(25, 25);
            this.trendingBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.trendingBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.trendingBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.trendingBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.trendingBtn.FillColor = System.Drawing.Color.White;
            this.trendingBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.trendingBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(180)))), ((int)(((byte)(195)))));
            this.trendingBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(142)))));
            this.trendingBtn.Image = global::MusicPlayer.Properties.Resources.positive_dynamic_128__1_;
            this.trendingBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.trendingBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.trendingBtn.Location = new System.Drawing.Point(32, 236);
            this.trendingBtn.Name = "trendingBtn";
            this.trendingBtn.Size = new System.Drawing.Size(180, 45);
            this.trendingBtn.TabIndex = 2;
            this.trendingBtn.Text = "Top Trending";
            this.trendingBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.trendingBtn.UseTransparentBackground = true;
            this.trendingBtn.Click += new System.EventHandler(this.trendingBtn_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 10;
            this.guna2PictureBox1.Image = global::MusicPlayer.Properties.Resources.FMMusic;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(32, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(175, 97);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // homeBtn
            // 
            this.homeBtn.Animated = true;
            this.homeBtn.BackColor = System.Drawing.Color.Transparent;
            this.homeBtn.BorderRadius = 10;
            this.homeBtn.CustomImages.HoveredImage = global::MusicPlayer.Properties.Resources.home_7_128__1_;
            this.homeBtn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.homeBtn.CustomImages.ImageSize = new System.Drawing.Size(25, 25);
            this.homeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homeBtn.FillColor = System.Drawing.Color.White;
            this.homeBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.homeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(180)))), ((int)(((byte)(195)))));
            this.homeBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(142)))));
            this.homeBtn.Image = global::MusicPlayer.Properties.Resources.home_7_128;
            this.homeBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.homeBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.homeBtn.Location = new System.Drawing.Point(32, 185);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(180, 45);
            this.homeBtn.TabIndex = 0;
            this.homeBtn.Text = "Trang chủ";
            this.homeBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.homeBtn.UseTransparentBackground = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(219)))), ((int)(((byte)(242)))));
            this.guna2Panel2.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2Panel2.Controls.Add(this.btnExitMainForm);
            this.guna2Panel2.Controls.Add(this.searchTextBox);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(244, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1038, 75);
            this.guna2Panel2.TabIndex = 1;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::MusicPlayer.Properties.Resources.Group_18;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(891, 7);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(60, 60);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 17;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // btnExitMainForm
            // 
            this.btnExitMainForm.Animated = true;
            this.btnExitMainForm.BorderRadius = 5;
            this.btnExitMainForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExitMainForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExitMainForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExitMainForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExitMainForm.FillColor = System.Drawing.Color.Transparent;
            this.btnExitMainForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExitMainForm.ForeColor = System.Drawing.Color.White;
            this.btnExitMainForm.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnExitMainForm.Image = ((System.Drawing.Image)(resources.GetObject("btnExitMainForm.Image")));
            this.btnExitMainForm.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExitMainForm.Location = new System.Drawing.Point(976, 9);
            this.btnExitMainForm.Name = "btnExitMainForm";
            this.btnExitMainForm.Size = new System.Drawing.Size(51, 56);
            this.btnExitMainForm.TabIndex = 16;
            this.btnExitMainForm.Click += new System.EventHandler(this.btnExitMainForm_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Animated = true;
            this.searchTextBox.AutoRoundedCorners = true;
            this.searchTextBox.BorderColor = System.Drawing.Color.Gray;
            this.searchTextBox.BorderRadius = 20;
            this.searchTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchTextBox.DefaultText = "";
            this.searchTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(219)))), ((int)(((byte)(242)))));
            this.searchTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.searchTextBox.IconLeft = global::MusicPlayer.Properties.Resources.search_100px_png1;
            this.searchTextBox.Location = new System.Drawing.Point(452, 16);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.PasswordChar = '\0';
            this.searchTextBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.searchTextBox.PlaceholderText = "Tìm kiếm";
            this.searchTextBox.SelectedText = "";
            this.searchTextBox.Size = new System.Drawing.Size(395, 42);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.songTitle);
            this.guna2Panel3.Controls.Add(this.muteBtn);
            this.guna2Panel3.Controls.Add(this.endTime);
            this.guna2Panel3.Controls.Add(this.currentTime);
            this.guna2Panel3.Controls.Add(this.volumeTrackBar);
            this.guna2Panel3.Controls.Add(this.musicTrackBar);
            this.guna2Panel3.Controls.Add(this.shuffleBtn);
            this.guna2Panel3.Controls.Add(this.playBtn);
            this.guna2Panel3.Controls.Add(this.nextBtn);
            this.guna2Panel3.Controls.Add(this.repeatBtn);
            this.guna2Panel3.Controls.Add(this.prevBtn);
            this.guna2Panel3.Controls.Add(this.artistsName);
            this.guna2Panel3.Controls.Add(this.thumbnailImage);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel3.Location = new System.Drawing.Point(244, 659);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1038, 94);
            this.guna2Panel3.TabIndex = 2;
            // 
            // songTitle
            // 
            this.songTitle.AutoSize = true;
            this.songTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.songTitle.Location = new System.Drawing.Point(101, 6);
            this.songTitle.Name = "songTitle";
            this.songTitle.Size = new System.Drawing.Size(0, 25);
            this.songTitle.TabIndex = 1;
            this.songTitle.Click += new System.EventHandler(this.songTitle_Click);
            // 
            // muteBtn
            // 
            this.muteBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.muteBtn.HoverState.Image = global::MusicPlayer.Properties.Resources.mute_100px_png11;
            this.muteBtn.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.muteBtn.Image = global::MusicPlayer.Properties.Resources.mute_100px;
            this.muteBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.muteBtn.ImageRotate = 0F;
            this.muteBtn.ImageSize = new System.Drawing.Size(27, 27);
            this.muteBtn.Location = new System.Drawing.Point(854, 21);
            this.muteBtn.Name = "muteBtn";
            this.muteBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.muteBtn.Size = new System.Drawing.Size(44, 46);
            this.muteBtn.TabIndex = 12;
            this.muteBtn.Click += new System.EventHandler(this.muteBtn_Click);
            // 
            // endTime
            // 
            this.endTime.AutoSize = true;
            this.endTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTime.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.endTime.Location = new System.Drawing.Point(804, 34);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(49, 20);
            this.endTime.TabIndex = 11;
            this.endTime.Text = "00:00";
            // 
            // currentTime
            // 
            this.currentTime.AutoSize = true;
            this.currentTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTime.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.currentTime.Location = new System.Drawing.Point(467, 34);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(49, 20);
            this.currentTime.TabIndex = 10;
            this.currentTime.Text = "00:00";
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.volumeTrackBar.Location = new System.Drawing.Point(904, 33);
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(84, 23);
            this.volumeTrackBar.TabIndex = 9;
            this.volumeTrackBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(85)))), ((int)(((byte)(140)))));
            this.volumeTrackBar.Value = 100;
            this.volumeTrackBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.volumeTrackBar_Scroll);
            // 
            // musicTrackBar
            // 
            this.musicTrackBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.musicTrackBar.Location = new System.Drawing.Point(522, 33);
            this.musicTrackBar.Name = "musicTrackBar";
            this.musicTrackBar.Size = new System.Drawing.Size(276, 23);
            this.musicTrackBar.TabIndex = 8;
            this.musicTrackBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(85)))), ((int)(((byte)(140)))));
            this.musicTrackBar.Value = 0;
            this.musicTrackBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.musicTrackBar_Scroll);
            // 
            // shuffleBtn
            // 
            this.shuffleBtn.CheckedState.ImageSize = new System.Drawing.Size(27, 27);
            this.shuffleBtn.HoverState.Image = global::MusicPlayer.Properties.Resources.shuffle_100px_png1;
            this.shuffleBtn.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.shuffleBtn.Image = global::MusicPlayer.Properties.Resources.shuffle_100px;
            this.shuffleBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.shuffleBtn.ImageRotate = 0F;
            this.shuffleBtn.ImageSize = new System.Drawing.Size(27, 27);
            this.shuffleBtn.Location = new System.Drawing.Point(417, 21);
            this.shuffleBtn.Name = "shuffleBtn";
            this.shuffleBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.shuffleBtn.Size = new System.Drawing.Size(44, 46);
            this.shuffleBtn.TabIndex = 7;
            this.shuffleBtn.Click += new System.EventHandler(this.shuffleBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.playBtn.HoverState.Image = global::MusicPlayer.Properties.Resources.play_100px_png1;
            this.playBtn.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.playBtn.Image = global::MusicPlayer.Properties.Resources.play_100px;
            this.playBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.playBtn.ImageRotate = 0F;
            this.playBtn.ImageSize = new System.Drawing.Size(27, 27);
            this.playBtn.Location = new System.Drawing.Point(317, 21);
            this.playBtn.Name = "playBtn";
            this.playBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.playBtn.Size = new System.Drawing.Size(44, 46);
            this.playBtn.TabIndex = 6;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.nextBtn.HoverState.Image = global::MusicPlayer.Properties.Resources.end_100px_png1;
            this.nextBtn.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.nextBtn.Image = global::MusicPlayer.Properties.Resources.end_100px;
            this.nextBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.nextBtn.ImageRotate = 0F;
            this.nextBtn.ImageSize = new System.Drawing.Size(27, 27);
            this.nextBtn.Location = new System.Drawing.Point(367, 21);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.nextBtn.Size = new System.Drawing.Size(44, 46);
            this.nextBtn.TabIndex = 5;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // repeatBtn
            // 
            this.repeatBtn.CheckedState.ImageSize = new System.Drawing.Size(27, 27);
            this.repeatBtn.HoverState.Image = global::MusicPlayer.Properties.Resources.repeat_100px_png1;
            this.repeatBtn.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.repeatBtn.Image = global::MusicPlayer.Properties.Resources.repeat_100px;
            this.repeatBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.repeatBtn.ImageRotate = 0F;
            this.repeatBtn.ImageSize = new System.Drawing.Size(27, 27);
            this.repeatBtn.Location = new System.Drawing.Point(217, 21);
            this.repeatBtn.Name = "repeatBtn";
            this.repeatBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.repeatBtn.Size = new System.Drawing.Size(44, 46);
            this.repeatBtn.TabIndex = 4;
            this.repeatBtn.Click += new System.EventHandler(this.repeatBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.prevBtn.HoverState.Image = global::MusicPlayer.Properties.Resources.skip_to_start_100px_png1;
            this.prevBtn.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.prevBtn.Image = global::MusicPlayer.Properties.Resources.skip_to_start_100px;
            this.prevBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.prevBtn.ImageRotate = 0F;
            this.prevBtn.ImageSize = new System.Drawing.Size(27, 27);
            this.prevBtn.Location = new System.Drawing.Point(267, 21);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.prevBtn.Size = new System.Drawing.Size(44, 46);
            this.prevBtn.TabIndex = 3;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // artistsName
            // 
            this.artistsName.AutoSize = true;
            this.artistsName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistsName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.artistsName.Location = new System.Drawing.Point(101, 29);
            this.artistsName.MaximumSize = new System.Drawing.Size(120, 0);
            this.artistsName.Name = "artistsName";
            this.artistsName.Size = new System.Drawing.Size(0, 20);
            this.artistsName.TabIndex = 2;
            this.artistsName.Click += new System.EventHandler(this.artistsName_Click);
            // 
            // thumbnailImage
            // 
            this.thumbnailImage.BorderRadius = 10;
            this.thumbnailImage.FillColor = System.Drawing.Color.Transparent;
            this.thumbnailImage.ImageRotate = 0F;
            this.thumbnailImage.Location = new System.Drawing.Point(13, 9);
            this.thumbnailImage.Name = "thumbnailImage";
            this.thumbnailImage.Size = new System.Drawing.Size(76, 76);
            this.thumbnailImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnailImage.TabIndex = 0;
            this.thumbnailImage.TabStop = false;
            this.thumbnailImage.Tag = "pause";
            this.thumbnailImage.Click += new System.EventHandler(this.thumbnailImage_Click);
            // 
            // containerPanel
            // 
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(244, 75);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(1038, 584);
            this.containerPanel.TabIndex = 3;
            // 
            // changePW
            // 
            this.changePW.BackColor = System.Drawing.Color.White;
            this.changePW.BorderRadius = 10;
            this.changePW.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.changePW.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.changePW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.changePW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.changePW.FillColor = System.Drawing.Color.White;
            this.changePW.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.changePW.ForeColor = System.Drawing.Color.Black;
            this.changePW.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(86)))), ((int)(((byte)(142)))));
            this.changePW.Image = ((System.Drawing.Image)(resources.GetObject("changePW.Image")));
            this.changePW.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.changePW.ImageSize = new System.Drawing.Size(25, 25);
            this.changePW.Location = new System.Drawing.Point(32, 645);
            this.changePW.Name = "changePW";
            this.changePW.Size = new System.Drawing.Size(180, 45);
            this.changePW.TabIndex = 10;
            this.changePW.Text = "Đổi mật khẩu ";
            this.changePW.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // MusicPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MusicPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fine Music - Music Player";
            this.Load += new System.EventHandler(this.MusicPlayerForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button homeBtn;
        private Guna.UI2.WinForms.Guna2Button releaseBtn;
        private Guna.UI2.WinForms.Guna2Button trendingBtn;
        private Guna.UI2.WinForms.Guna2Button searchPageBtn;
        private Guna.UI2.WinForms.Guna2Panel containerPanel;
        private Guna.UI2.WinForms.Guna2TextBox searchTextBox;
        private Guna.UI2.WinForms.Guna2Button btnExitMainForm;
        private Guna.UI2.WinForms.Guna2PictureBox thumbnailImage;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label artistsName;
        private System.Windows.Forms.Label songTitle;
        private Guna.UI2.WinForms.Guna2ImageButton prevBtn;
        private Guna.UI2.WinForms.Guna2ImageButton shuffleBtn;
        public Guna.UI2.WinForms.Guna2ImageButton playBtn;
        private Guna.UI2.WinForms.Guna2ImageButton nextBtn;
        private Guna.UI2.WinForms.Guna2ImageButton repeatBtn;
        private Guna.UI2.WinForms.Guna2ImageButton muteBtn;
        private System.Windows.Forms.Label endTime;
        private System.Windows.Forms.Label currentTime;
        private Guna.UI2.WinForms.Guna2TrackBar volumeTrackBar;
        private Guna.UI2.WinForms.Guna2TrackBar musicTrackBar;
        public Guna.UI2.WinForms.Guna2Button playListBtn;
        private Guna.UI2.WinForms.Guna2Button loveMusic;
        private Guna.UI2.WinForms.Guna2Button changePW;
    }
}