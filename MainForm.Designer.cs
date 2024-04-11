namespace MusicPlayer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnDangKy = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangNhap = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExitMainForm = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-5, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(612, 717);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.linkLabel1.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkLabel1.Location = new System.Drawing.Point(759, 489);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(187, 69);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sự cố khi đăng nhập ? \r\n\r\n\r\n";
            // 
            // btnDangKy
            // 
            this.btnDangKy.BorderRadius = 19;
            this.btnDangKy.BorderThickness = 1;
            this.btnDangKy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangKy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangKy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangKy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangKy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.Black;
            this.btnDangKy.HoverState.BorderColor = System.Drawing.Color.Teal;
            this.btnDangKy.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnDangKy.Location = new System.Drawing.Point(699, 395);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(285, 57);
            this.btnDangKy.TabIndex = 13;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BorderRadius = 19;
            this.btnDangNhap.BorderThickness = 1;
            this.btnDangNhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangNhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangNhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.Black;
            this.btnDangNhap.HoverState.BorderColor = System.Drawing.Color.Teal;
            this.btnDangNhap.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnDangNhap.Location = new System.Drawing.Point(699, 281);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(285, 57);
            this.btnDangNhap.TabIndex = 12;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(729, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 42);
            this.label1.TabIndex = 11;
            this.label1.Text = "TÀI KHOẢN";
            // 
            // btnExitMainForm
            // 
            this.btnExitMainForm.BorderRadius = 5;
            this.btnExitMainForm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExitMainForm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExitMainForm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExitMainForm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExitMainForm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExitMainForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExitMainForm.ForeColor = System.Drawing.Color.White;
            this.btnExitMainForm.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExitMainForm.Image = ((System.Drawing.Image)(resources.GetObject("btnExitMainForm.Image")));
            this.btnExitMainForm.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExitMainForm.Location = new System.Drawing.Point(1022, 0);
            this.btnExitMainForm.Name = "btnExitMainForm";
            this.btnExitMainForm.Size = new System.Drawing.Size(71, 53);
            this.btnExitMainForm.TabIndex = 15;
            this.btnExitMainForm.Click += new System.EventHandler(this.btnExitMainForm_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(9)))), ((int)(((byte)(58)))));
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(103, 200);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(387, 252);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 16;
            this.guna2PictureBox2.TabStop = false;
            // 
            // bunifuSnackbar1
            // 
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1092, 701);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.btnExitMainForm);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2Button btnDangKy;
        private Guna.UI2.WinForms.Guna2Button btnDangNhap;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnExitMainForm;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
 
    }
}