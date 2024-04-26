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
            this.albumItem = new MusicPlayer.UC.ChildrenUC.UC_Item();
            this.normalSection1 = new MusicPlayer.UC.ChildrenUC.NormalSection();
            this.flowLayoutPanel1.SuspendLayout();
            this.albumPanel.SuspendLayout();
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
            this.albumPanel.Controls.Add(this.albumItem);
            this.albumPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.albumPanel.Location = new System.Drawing.Point(3, 3);
            this.albumPanel.Name = "albumPanel";
            this.albumPanel.Size = new System.Drawing.Size(1193, 494);
            this.albumPanel.TabIndex = 9;
            this.albumPanel.Visible = false;
            // 
            // albumItem
            // 
            this.albumItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.albumItem.Location = new System.Drawing.Point(453, 9);
            this.albumItem.Name = "albumItem";
            this.albumItem.Size = new System.Drawing.Size(329, 485);
            this.albumItem.TabIndex = 0;
            // 
            // normalSection1
            // 
            this.normalSection1.Location = new System.Drawing.Point(3, 503);
            this.normalSection1.Name = "normalSection1";
            this.normalSection1.Size = new System.Drawing.Size(1193, 530);
            this.normalSection1.TabIndex = 10;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel albumPanel;
        private NormalSection normalSection1;
        private UC_Item albumItem;
    }
}
