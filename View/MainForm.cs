using System;
using System.Windows.Forms;
using MusicPlayer.View;

namespace MusicPlayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();
            formLogin.Show();
            Hide();
        }

        private void btnExitMainForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var formRegister = new FormRegister();
            formRegister.Show();
            Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgetPW = new ForgetPW();
            forgetPW.Show();
            Hide();
        }
    }
}