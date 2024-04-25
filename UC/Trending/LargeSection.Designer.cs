namespace MusicPlayer.UC.Trending
{
    partial class LargeSection
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
            this.Title = new System.Windows.Forms.Label();
            this.MusicList = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.Title);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1193, 100);
            this.guna2Panel1.TabIndex = 7;
            // 
            // title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(85)))), ((int)(((byte)(140)))));
            this.Title.Location = new System.Drawing.Point(525, 38);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(133, 25);
            this.Title.TabIndex = 6;
            this.Title.Text = "Large Section";
            // 
            // musicList
            // 
            this.MusicList.AutoScroll = true;
            this.MusicList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MusicList.Location = new System.Drawing.Point(0, 100);
            this.MusicList.Name = "MusicList";
            this.MusicList.Size = new System.Drawing.Size(1193, 430);
            this.MusicList.TabIndex = 8;
            this.MusicList.WrapContents = false;
            // 
            // LargeSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MusicList);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "LargeSection";
            this.Size = new System.Drawing.Size(1193, 530);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
