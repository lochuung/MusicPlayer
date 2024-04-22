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
            this.promoteUC = new MusicPlayer.UC.Trending.Promote();
            this.promote1 = new MusicPlayer.UC.Trending.Promote();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.promoteUC);
            this.flowLayoutPanel1.Controls.Add(this.promote1);
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
            this.promoteUC.Size = new System.Drawing.Size(1182, 519);
            this.promoteUC.TabIndex = 0;
            // 
            // promote1
            // 
            this.promote1.Location = new System.Drawing.Point(3, 528);
            this.promote1.Name = "promote1";
            this.promote1.Size = new System.Drawing.Size(1193, 530);
            this.promote1.TabIndex = 1;
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
        private Trending.Promote promoteUC;
        private Trending.Promote promote1;
    }
}
