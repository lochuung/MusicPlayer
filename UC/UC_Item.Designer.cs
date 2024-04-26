namespace MusicPlayer.UC
{
    partial class UC_Item
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.Guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Guna2PictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // Guna2Panel1
            // 
            this.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.Guna2Panel1.BorderRadius = 10;
            this.Guna2Panel1.Controls.Add(this.Label13);
            this.Guna2Panel1.Controls.Add(this.Label14);
            this.Guna2Panel1.Controls.Add(this.Guna2PictureBox6);
            this.Guna2Panel1.CustomizableEdges = customizableEdges3;
            this.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Guna2Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.Guna2Panel1.Name = "Guna2Panel1";
            this.Guna2Panel1.ShadowDecoration.BorderRadius = 10;
            this.Guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.Guna2Panel1.Size = new System.Drawing.Size(329, 399);
            this.Guna2Panel1.TabIndex = 0;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Label13.Location = new System.Drawing.Point(40, 283);
            this.Label13.MaximumSize = new System.Drawing.Size(260, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(102, 25);
            this.Label13.TabIndex = 7;
            this.Label13.Text = "Đang tải...";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label14.Location = new System.Drawing.Point(40, 336);
            this.Label14.MaximumSize = new System.Drawing.Size(260, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(80, 20);
            this.Label14.TabIndex = 8;
            this.Label14.Text = "Đang tải...";
            // 
            // Guna2PictureBox6
            // 
            this.Guna2PictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.Guna2PictureBox6.BorderRadius = 30;
            this.Guna2PictureBox6.CustomizableEdges = customizableEdges1;
            this.Guna2PictureBox6.FillColor = System.Drawing.Color.Transparent;
            this.Guna2PictureBox6.Image = global::MusicPlayer.Properties.Resources.music_1001px;
            this.Guna2PictureBox6.ImageRotate = 0F;
            this.Guna2PictureBox6.Location = new System.Drawing.Point(40, 16);
            this.Guna2PictureBox6.Name = "Guna2PictureBox6";
            this.Guna2PictureBox6.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.Guna2PictureBox6.Size = new System.Drawing.Size(248, 248);
            this.Guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Guna2PictureBox6.TabIndex = 6;
            this.Guna2PictureBox6.TabStop = false;
            this.Guna2PictureBox6.Tag = "pause";
            this.Guna2PictureBox6.UseTransparentBackground = true;
            // 
            // UC_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Guna2Panel1);
            this.Name = "UC_Item";
            this.Size = new System.Drawing.Size(329, 399);
            this.Guna2Panel1.ResumeLayout(false);
            this.Guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Guna2PictureBox6)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        
        public Guna.UI2.WinForms.Guna2Panel Guna2Panel1;
        public System.Windows.Forms.Label Label13;
        public System.Windows.Forms.Label Label14;
        public Guna.UI2.WinForms.Guna2PictureBox Guna2PictureBox6;
    }
}
