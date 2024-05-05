using MusicPlayer.UC.ChildrenUC;

namespace MusicPlayer.UC
{
    partial class UC_Playlist
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.albumPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.albumTitle = new System.Windows.Forms.Label();
            this.ShortDescription = new System.Windows.Forms.Label();
            this.Guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.normalSection1 = new MusicPlayer.UC.ChildrenUC.NormalSection();
            this.artists = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.albumPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Guna2PictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.albumPanel);
            this.flowLayoutPanel1.Controls.Add(this.normalSection1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1038, 753);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // albumPanel
            // 
            this.albumPanel.Controls.Add(this.artists);
            this.albumPanel.Controls.Add(this.albumTitle);
            this.albumPanel.Controls.Add(this.ShortDescription);
            this.albumPanel.Controls.Add(this.Guna2PictureBox6);
            this.albumPanel.Location = new System.Drawing.Point(3, 3);
            this.albumPanel.Name = "albumPanel";
            this.albumPanel.Size = new System.Drawing.Size(1193, 494);
            this.albumPanel.TabIndex = 9;
            this.albumPanel.Visible = false;
            // 
            // albumTitle
            // 
            this.albumTitle.AutoSize = true;
            this.albumTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.albumTitle.Location = new System.Drawing.Point(449, 303);
            this.albumTitle.MaximumSize = new System.Drawing.Size(310, 0);
            this.albumTitle.Name = "albumTitle";
            this.albumTitle.Size = new System.Drawing.Size(102, 25);
            this.albumTitle.TabIndex = 10;
            this.albumTitle.Text = "Đang tải...";
            // 
            // ShortDescription
            // 
            this.ShortDescription.AutoSize = true;
            this.ShortDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortDescription.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ShortDescription.Location = new System.Drawing.Point(162, 407);
            this.ShortDescription.MaximumSize = new System.Drawing.Size(900, 0);
            this.ShortDescription.Name = "ShortDescription";
            this.ShortDescription.Size = new System.Drawing.Size(80, 20);
            this.ShortDescription.TabIndex = 11;
            this.ShortDescription.Text = "Đang tải...";
            // 
            // Guna2PictureBox6
            // 
            this.Guna2PictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.Guna2PictureBox6.BorderRadius = 30;
            this.Guna2PictureBox6.FillColor = System.Drawing.Color.Transparent;
            this.Guna2PictureBox6.Image = global::MusicPlayer.Properties.Resources.music_1001px;
            this.Guna2PictureBox6.ImageRotate = 0F;
            this.Guna2PictureBox6.Location = new System.Drawing.Point(454, 3);
            this.Guna2PictureBox6.Name = "Guna2PictureBox6";
            this.Guna2PictureBox6.Size = new System.Drawing.Size(293, 288);
            this.Guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Guna2PictureBox6.TabIndex = 9;
            this.Guna2PictureBox6.TabStop = false;
            this.Guna2PictureBox6.Tag = "pause";
            this.Guna2PictureBox6.UseTransparentBackground = true;
            // 
            // normalSection1
            // 
            this.normalSection1.Location = new System.Drawing.Point(3, 503);
            this.normalSection1.Name = "normalSection1";
            this.normalSection1.Size = new System.Drawing.Size(1193, 530);
            this.normalSection1.TabIndex = 10;
            // 
            // artists
            // 
            this.artists.AutoSize = true;
            this.artists.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artists.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.artists.Location = new System.Drawing.Point(450, 369);
            this.artists.MaximumSize = new System.Drawing.Size(260, 0);
            this.artists.Name = "artists";
            this.artists.Size = new System.Drawing.Size(80, 20);
            this.artists.TabIndex = 12;
            this.artists.Text = "Đang tải...";
            // 
            // UC_Playlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UC_Playlist";
            this.Size = new System.Drawing.Size(1038, 753);
            this.Load += new System.EventHandler(this.UC_Playlist_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.albumPanel.ResumeLayout(false);
            this.albumPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Guna2PictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel albumPanel;
        private NormalSection normalSection1;
        public System.Windows.Forms.Label albumTitle;
        public System.Windows.Forms.Label ShortDescription;
        public Guna.UI2.WinForms.Guna2PictureBox Guna2PictureBox6;
        public System.Windows.Forms.Label artists;
    }
}
