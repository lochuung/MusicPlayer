using MusicPlayer.UC.ChildrenUC;

namespace MusicPlayer.UC
{
    partial class UC_Home
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
            this.label = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.uC_ItemWTH1 = new UC_Item();
            this.uC_ItemWTH2 = new UC_Item();
            this.uC_ItemWTH3 = new UC_Item();
            this.uC_Item8 = new UC_Item();
            this.uC_Item1 = new UC_Item();
            this.uC_Item2 = new UC_Item();
            this.guna2Panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.label);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 317);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1193, 66);
            this.guna2Panel1.TabIndex = 8;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label.Location = new System.Drawing.Point(51, 40);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(224, 25);
            this.label.TabIndex = 5;
            this.label.Text = "Có Thể Bạn Muốn Nghe\r\n";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.uC_ItemWTH1);
            this.flowLayoutPanel2.Controls.Add(this.uC_ItemWTH2);
            this.flowLayoutPanel2.Controls.Add(this.uC_ItemWTH3);
            this.flowLayoutPanel2.Controls.Add(this.uC_Item8);
            this.flowLayoutPanel2.Controls.Add(this.uC_Item1);
            this.flowLayoutPanel2.Controls.Add(this.uC_Item2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 385);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1101, 393);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // uC_ItemWTH1
            // 
            this.uC_ItemWTH1.Location = new System.Drawing.Point(3, 3);
            this.uC_ItemWTH1.Name = "uC_ItemWTH1";
            this.uC_ItemWTH1.Size = new System.Drawing.Size(329, 399);
            this.uC_ItemWTH1.TabIndex = 0;
            // 
            // uC_ItemWTH2
            // 
            this.uC_ItemWTH2.Location = new System.Drawing.Point(338, 3);
            this.uC_ItemWTH2.Name = "uC_ItemWTH2";
            this.uC_ItemWTH2.Size = new System.Drawing.Size(329, 399);
            this.uC_ItemWTH2.TabIndex = 1;
            // 
            // uC_ItemWTH3
            // 
            this.uC_ItemWTH3.Location = new System.Drawing.Point(673, 3);
            this.uC_ItemWTH3.Name = "uC_ItemWTH3";
            this.uC_ItemWTH3.Size = new System.Drawing.Size(329, 399);
            this.uC_ItemWTH3.TabIndex = 2;
            // 
            // uC_Item8
            // 
            this.uC_Item8.Location = new System.Drawing.Point(3, 408);
            this.uC_Item8.Name = "uC_Item8";
            this.uC_Item8.Size = new System.Drawing.Size(329, 399);
            this.uC_Item8.TabIndex = 3;
            // 
            // uC_Item1
            // 
            this.uC_Item1.Location = new System.Drawing.Point(338, 408);
            this.uC_Item1.Name = "uC_Item1";
            this.uC_Item1.Size = new System.Drawing.Size(329, 399);
            this.uC_Item1.TabIndex = 4;
            // 
            // uC_Item2
            // 
            this.uC_Item2.Location = new System.Drawing.Point(673, 408);
            this.uC_Item2.Name = "uC_Item2";
            this.uC_Item2.Size = new System.Drawing.Size(329, 399);
            this.uC_Item2.TabIndex = 5;
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(1038, 753);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private UC_Item uC_ItemWTH1;
        private UC_Item uC_ItemWTH2;
        private UC_Item uC_ItemWTH3;
        private UC_Item uC_Item8;
        private UC_Item uC_Item1;
        private UC_Item uC_Item2;
    }
}
