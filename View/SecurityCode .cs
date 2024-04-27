using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.View
{
    public partial class SecurityCode : Form
    {
        private ForgetPW forgetPW;
        public SecurityCode()
        {
            InitializeComponent();
            forgetPW = new ForgetPW();
            this.Controls.Add(forgetPW);
        }

        private void SecurityCode_Load(object sender, EventArgs e)
        {
            string emailsdt = forgetPW.EmailorSdtText;
            lblEmail.Text = emailsdt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ForgetPW forget = new ForgetPW();
            forget.Show();
            this.Hide();
        }
    }
}
