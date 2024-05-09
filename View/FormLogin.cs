using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MusicPlayer.Database;

namespace MusicPlayer
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            btnHide.Click += btnHide_Click;
            btnShow.Click += btnShow_Click;
        }


        /* public event EventHandler<string> UserLoggedIn;
         protected virtual void onUserLoggedIn(string email)
         {
             UserLoggedIn?.Invoke(this, email);
         }*/
        private void btnExitDangNhap_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            Hide();
            /* string userEmail = "Ex";
             onUserLoggedIn(userEmail);*/
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == "" || txbPassWord.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            using (var context = new MusicDbContext())
            {
                var user = from u in context.Users
                    where u.Email == txbUserName.Text && u.Password == txbPassWord.Text
                    select u;
                if (user.Any())
                {
                    var mainForm = new MusicPlayerForm(user.First().UserId);
                    mainForm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                }
            }
        }

        public void clearAll()
        {
            txbPassWord.Clear();
            txbUserName.Clear();
        }

        private void txbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbUserName.Text))
                errorProvider1.SetError(txbUserName, "Vui lòng nhập tên đăng nhập");
            else
                errorProvider1.SetError(txbUserName, null);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            View.ForgetPW forgetPW = new View.ForgetPW();
            forgetPW.Show();
            this.Hide();
        }

        private void txbPassWord_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txbPassWord.Text))
                errorProvider1.SetError(txbPassWord, "Vui lòng nhập mật khẩu");
            else
                errorProvider1.SetError(txbPassWord, null);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            btnHide.Visible = false;
            btnShow.Visible = true;
            txbPassWord.UseSystemPasswordChar = false;
            txbPassWord.PasswordChar = '\0';
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Visible = false;
            btnHide.Visible = true;
            txbPassWord.UseSystemPasswordChar = true;
        }
    }
}