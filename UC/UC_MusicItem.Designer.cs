namespace MusicPlayer.UC
{
    partial class UC_MusicItem
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.likeBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.playBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.likeBtn);
            this.guna2Panel1.Controls.Add(this.playBtn);
            this.guna2Panel1.Controls.Add(this.label13);
            this.guna2Panel1.Controls.Add(this.label14);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(410, 102);
            this.guna2Panel1.TabIndex = 0;
            // 
            // likeBtn
            // 
            this.likeBtn.CheckedState.ImageSize = new System.Drawing.Size(27, 27);
            this.likeBtn.HoverState.Image = global::MusicPlayer.Properties.Resources.love_100px_png1;
            this.likeBtn.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.likeBtn.Image = global::MusicPlayer.Properties.Resources.love_100px_png11;
            this.likeBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.likeBtn.ImageRotate = 0F;
            this.likeBtn.ImageSize = new System.Drawing.Size(27, 27);
            this.likeBtn.Location = new System.Drawing.Point(301, 28);
            this.likeBtn.Name = "likeBtn";
            this.likeBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.likeBtn.Size = new System.Drawing.Size(44, 46);
            this.likeBtn.TabIndex = 12;
            // 
            // playBtn
            // 
            this.playBtn.CheckedState.ImageSize = new System.Drawing.Size(27, 27);
            this.playBtn.HoverState.Image = global::MusicPlayer.Properties.Resources.play_100px_png1;
            this.playBtn.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.playBtn.Image = global::MusicPlayer.Properties.Resources.play_100px;
            this.playBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.playBtn.ImageRotate = 0F;
            this.playBtn.ImageSize = new System.Drawing.Size(27, 27);
            this.playBtn.Location = new System.Drawing.Point(351, 28);
            this.playBtn.Name = "playBtn";
            this.playBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.playBtn.Size = new System.Drawing.Size(44, 46);
            this.playBtn.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(85, 24);
            this.label13.MaximumSize = new System.Drawing.Size(220, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 19);
            this.label13.TabIndex = 10;
            this.label13.Text = "Đang tải...";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label14.Location = new System.Drawing.Point(85, 58);
            this.label14.MaximumSize = new System.Drawing.Size(220, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "Đang tải...";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 20;
            this.guna2PictureBox1.Image = global::MusicPlayer.Properties.Resources.music_1001px;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(13, 16);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(65, 68);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // UC_MusicItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UC_MusicItem";
            this.Size = new System.Drawing.Size(410, 102);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2ImageButton likeBtn;
        private Guna.UI2.WinForms.Guna2ImageButton playBtn;
    }
}
