namespace MusicPlayer.UC
{
    partial class UC_Search
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Title = new System.Windows.Forms.Label();
            this.songSection = new MusicPlayer.UC.ChildrenUC.NormalSection();
            this.playlistSection = new MusicPlayer.UC.ChildrenUC.LargeSection();
            this.noResultLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel1);
            this.flowLayoutPanel1.Controls.Add(this.songSection);
            this.flowLayoutPanel1.Controls.Add(this.playlistSection);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1038, 753);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.noResultLabel);
            this.guna2Panel1.Controls.Add(this.Title);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1193, 100);
            this.guna2Panel1.TabIndex = 8;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.Location = new System.Drawing.Point(24, 36);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(196, 30);
            this.Title.TabIndex = 6;
            this.Title.Text = "Kết quả tìm kiếm:";
            // 
            // songSection
            // 
            this.songSection.Location = new System.Drawing.Point(3, 109);
            this.songSection.Name = "songSection";
            this.songSection.Size = new System.Drawing.Size(1193, 530);
            this.songSection.TabIndex = 9;
            this.songSection.Visible = false;
            // 
            // playlistSection
            // 
            this.playlistSection.Location = new System.Drawing.Point(3, 645);
            this.playlistSection.Name = "playlistSection";
            this.playlistSection.Size = new System.Drawing.Size(1193, 530);
            this.playlistSection.TabIndex = 10;
            this.playlistSection.Visible = false;
            // 
            // noResultLabel
            // 
            this.noResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.noResultLabel.AutoSize = true;
            this.noResultLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noResultLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.noResultLabel.Location = new System.Drawing.Point(354, 39);
            this.noResultLabel.Name = "noResultLabel";
            this.noResultLabel.Size = new System.Drawing.Size(264, 25);
            this.noResultLabel.TabIndex = 10;
            this.noResultLabel.Text = "Không tìm thấy kết quả nào.";
            // 
            // UC_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UC_Search";
            this.Size = new System.Drawing.Size(1038, 753);
            this.Load += new System.EventHandler(this.UC_Search_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.Label Title;
        private ChildrenUC.NormalSection songSection;
        private ChildrenUC.LargeSection playlistSection;
        public System.Windows.Forms.Label noResultLabel;
    }
}
