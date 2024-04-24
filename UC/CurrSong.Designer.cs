
namespace MusicPlayer.UC
{
    partial class CurrSong
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
            this.ptrImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTenBaiHat = new System.Windows.Forms.Label();
            this.lblTenCaSi = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ptrImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ptrImage
            // 
            this.ptrImage.Image = global::MusicPlayer.Properties.Resources.music_1001px;
            this.ptrImage.ImageRotate = 0F;
            this.ptrImage.Location = new System.Drawing.Point(24, 141);
            this.ptrImage.Name = "ptrImage";
            this.ptrImage.Size = new System.Drawing.Size(412, 371);
            this.ptrImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrImage.TabIndex = 0;
            this.ptrImage.TabStop = false;
            // 
            // lblTenBaiHat
            // 
            this.lblTenBaiHat.AutoSize = true;
            this.lblTenBaiHat.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBaiHat.Location = new System.Drawing.Point(90, 540);
            this.lblTenBaiHat.Name = "lblTenBaiHat";
            this.lblTenBaiHat.Size = new System.Drawing.Size(275, 38);
            this.lblTenBaiHat.TabIndex = 1;
            this.lblTenBaiHat.Text = "Bến Tương Phùng ";
            this.lblTenBaiHat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTenCaSi
            // 
            this.lblTenCaSi.AutoSize = true;
            this.lblTenCaSi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCaSi.Location = new System.Drawing.Point(128, 601);
            this.lblTenCaSi.Name = "lblTenCaSi";
            this.lblTenCaSi.Size = new System.Drawing.Size(181, 23);
            this.lblTenCaSi.TabIndex = 2;
            this.lblTenCaSi.Text = "Phú Quý, Lê Chí Trung";
            this.lblTenCaSi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.BorderColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2Button1.Location = new System.Drawing.Point(626, 79);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(195, 45);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "Lời bài hát ";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(506, 141);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(459, 500);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // CurrSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.lblTenCaSi);
            this.Controls.Add(this.lblTenBaiHat);
            this.Controls.Add(this.ptrImage);
            this.Name = "CurrSong";
            this.Size = new System.Drawing.Size(1038, 753);
            this.Load += new System.EventHandler(this.CurrSong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptrImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox ptrImage;
        private System.Windows.Forms.Label lblTenBaiHat;
        private System.Windows.Forms.Label lblTenCaSi;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}
