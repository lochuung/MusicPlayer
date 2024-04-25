namespace MusicPlayer.UC
{
    partial class UC_Trending
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
            this.promoteUC = new MusicPlayer.UC.Trending.LargeSection();
            this.newRelease1 = new MusicPlayer.UC.Trending.NormalSection();
            this.topVN = new MusicPlayer.UC.Trending.NormalSection();
            this.topKR = new MusicPlayer.UC.Trending.NormalSection();
            this.top100 = new MusicPlayer.UC.Trending.NormalSection();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.promoteUC);
            this.flowLayoutPanel1.Controls.Add(this.newRelease1);
            this.flowLayoutPanel1.Controls.Add(this.topVN);
            this.flowLayoutPanel1.Controls.Add(this.topKR);
            this.flowLayoutPanel1.Controls.Add(this.top100);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1038, 753);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // promoteUC
            // 
            this.promoteUC.Location = new System.Drawing.Point(3, 3);
            this.promoteUC.Name = "promoteUC";
            this.promoteUC.Size = new System.Drawing.Size(1193, 530);
            this.promoteUC.TabIndex = 0;
            // 
            // newRelease1
            // 
            this.newRelease1.Location = new System.Drawing.Point(3, 539);
            this.newRelease1.Name = "newRelease1";
            this.newRelease1.Size = new System.Drawing.Size(1193, 530);
            this.newRelease1.TabIndex = 1;
            // 
            // topVN
            // 
            this.topVN.Location = new System.Drawing.Point(3, 1075);
            this.topVN.Name = "topVN";
            this.topVN.Size = new System.Drawing.Size(1193, 530);
            this.topVN.TabIndex = 2;
            // 
            // topKR
            // 
            this.topKR.Location = new System.Drawing.Point(3, 1611);
            this.topKR.Name = "topKR";
            this.topKR.Size = new System.Drawing.Size(1193, 530);
            this.topKR.TabIndex = 3;
            // 
            // top100
            // 
            this.top100.Location = new System.Drawing.Point(3, 2147);
            this.top100.Name = "top100";
            this.top100.Size = new System.Drawing.Size(1193, 530);
            this.top100.TabIndex = 4;
            // 
            // UC_Trending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UC_Trending";
            this.Size = new System.Drawing.Size(1038, 753);
            this.Load += new System.EventHandler(this.UC_Trending_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Trending.LargeSection promoteUC;
        private Trending.NormalSection newRelease1;
        private Trending.NormalSection topVN;
        private Trending.NormalSection topKR;
        private Trending.NormalSection top100;
    }
}
