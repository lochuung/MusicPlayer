using System;
using System.Linq;
using System.Windows.Forms;
using MusicPlayer.Database;
using MusicPlayer.Database.Entity;
using MusicPlayer.Properties;

namespace MusicPlayer
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnExitFormRegister_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            if (ptbEmail.Image == Resources.warning ||
                ptbSoDienThoai.Image == Resources.warning ||
                ptbMatKhau.Image == Resources.warning ||
                ptbNhapLaiMatKhau.Image == Resources.warning)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ClearAll();
                return;
            }


            using (var context = new MusicDbContext())
            {
                // check exist
                var email = txbEmail.Text;
                var userCheck = from u in context.Users
                                where u.Email == email || u.PhoneNumber == txbSdt.Text
                                select u;
                if (userCheck.Count() > 0)
                {
                    MessageBox.Show("Email hoặc số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                var user = new User
                {
                    FullName = txbHoTen.Text,
                    Email = txbEmail.Text,
                    PhoneNumber = txbSdt.Text,
                    Birthday = dtRegister.Value,
                    Password = txbMatKhauDangKy.Text
                };
                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show("Đăng ký thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
            }

            /*try
            {
            }*/
            /*catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        public void ClearAll()
        {
            txbHoTen.Clear();
            txbEmail.Clear();
            txbMatKhauDangKy.Clear();
            txbNhapLaiMatKhau.Clear();
            txbSdt.Clear();
            dtRegister.ResetText();
        }

        private void btnExitDangNhap_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void txbHoTen_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbHoTen.Text))
            {
                ptbHoTen.Visible = true;
                ptbHoTen.Image = Resources.check;
            }
            else
            {
                ptbHoTen.Visible = false;
            }
        }

        private void txbEmail_Validated(object sender, EventArgs e)
        {
            var email = txbEmail.Text;
            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".com"))
            {
                ptbEmail.Visible = true;
                ptbEmail.Image = Resources.check;
            }
            else
            {
                ptbEmail.Visible = true;
                ptbEmail.Image = Resources.warning;
                toolTip1.SetToolTip(ptbEmail, "Vui lòng nhập đúng email !");
            }
        }

        private void txbSdt_Validated(object sender, EventArgs e)
        {
            var phoneNumber = txbSdt.Text;
            if (!string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.Length == 10)
            {
                ptbSoDienThoai.Visible = true;
                ptbSoDienThoai.Image = Resources.check;
            }
            else
            {
                ptbSoDienThoai.Visible = true;
                ptbSoDienThoai.Image = Resources.warning;
                toolTip1.SetToolTip(ptbSoDienThoai, "Vui lòng nhập đúng số điện thoại !");
            }
        }

        private void txbMatKhauDangKy_Validated(object sender, EventArgs e)
        {
            var password = txbMatKhauDangKy.Text;
            if (!string.IsNullOrWhiteSpace(password) && password.Replace(" ", "").Length >= 6)
            {
                ptbMatKhau.Visible = true;
                ptbMatKhau.Image = Resources.check;
            }
            else
            {
                ptbMatKhau.Visible = true;
                ptbMatKhau.Image = Resources.warning;
                toolTip1.SetToolTip(ptbMatKhau, "Mật khẩu tối thiểu 6 ký tự và không chứa khoảng trắng !");
            }
        }

        private void txbNhapLaiMatKhau_Validated(object sender, EventArgs e)
        {
            if (txbMatKhauDangKy.Text == txbNhapLaiMatKhau.Text && !string.IsNullOrEmpty(txbNhapLaiMatKhau.Text))
            {
                ptbNhapLaiMatKhau.Visible = true;
                ptbNhapLaiMatKhau.Image = Resources.check;
            }
            else
            {
                ptbNhapLaiMatKhau.Visible = true;
                ptbNhapLaiMatKhau.Image = Resources.warning;
                toolTip1.SetToolTip(ptbNhapLaiMatKhau, "Vui lòng nhập đúng !");
            }
        }
    }
}