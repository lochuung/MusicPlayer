﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace MusicPlayer.View
{
    public partial class SecurityCode : Form
    {
        private ForgetPW forgetPW;
        private string email;

        public SecurityCode(string email)
        {
            InitializeComponent();
            this.email = email;
            lblEmail.Text = email;
        }
        public SecurityCode(ForgetPW forgetPW)
        {
            InitializeComponent();
            forgetPW = new ForgetPW();
            string emailsdt = forgetPW.EmailorSdtText;
            lblEmail.Text = emailsdt;
            lblEmail.Visible = true;
            lblEmail.Show();

            /*this.Controls.Add(forgetPW);*/
        }

        private void SecurityCode_Load(object sender, EventArgs e)
        {
            /*string emailsdt = forgetPW.EmailorSdtText;
            lblEmail.Text = emailsdt;*/
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ForgetPW forget = new ForgetPW();
            forget.Show();
            this.Hide();
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txbCode.Text))
            {
                lblNhapMa.Visible = true;
                lblNhapMa.Show();
            }
            else
            {
                NewPW newPW = new NewPW();
                newPW.Show();
                this.Hide();
            }
        }
    }
}
