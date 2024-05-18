using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MusicPlayer.Database;
using MusicPlayer.Database.Entity;
using MusicPlayer.Properties;

namespace MusicPlayer
{
    public partial class FormRegister : Form
    {
        private readonly Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[a-z]).{6,}$");
        
        private User user;
        public FormRegister()
        {
            InitializeComponent();
            btnHide.Click += btnHide_Click;
            btnShow.Click += btnShow_Click;
        }

        public FormRegister(User user)
        {
            this.user = user;
            InitializeComponent();
            btnHide.Click += btnHide_Click;
            btnShow.Click += btnShow_Click;
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            if (user == null) return;
            txbHoTen.Text = user.FullName;
            txbEmail.Text = user.Email;
            txbSdt.Text = user.PhoneNumber;
            dtRegister.Value = user.Birthday;
            txbMatKhauDangKy.Hide();
            txbNhapLaiMatKhau.Hide();
            label3.Hide();
            label4.Hide();
            btnHide.Hide();
            btnShow.Hide();
            btnDangKyTaiKhoan.Text = "Cập nhật";
        }

        private void btnExitFormRegister_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txbHoTen.Text) ||
                String.IsNullOrEmpty(txbEmail.Text) ||
                String.IsNullOrEmpty(txbSdt.Text))
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (user == null)
            {
                if (txbMatKhauDangKy.Text != txbNhapLaiMatKhau.Text || String.IsNullOrEmpty(txbMatKhauDangKy.Text)
                    || String.IsNullOrEmpty(txbNhapLaiMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu phải giống nhau", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }


            using (var context = new MusicDbContext())
            {
                // check exist
                var email = txbEmail.Text;
                var userCheck = from u in context.Users
                                where u.Email == email || u.PhoneNumber == txbSdt.Text
                                select u;
                // update
                if (this.user != null)
                {
                    // validate email and phone number
                    if (userCheck.Count() > 0 && 
                        (userCheck.First().Email != this.user.Email 
                         || userCheck.First().PhoneNumber != this.user.PhoneNumber)
                        )
                    {
                        MessageBox.Show("Email hoặc số điện thoại đã tồn tại ở tài khoản khác!", 
                            "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }
                    
                    this.user.FullName = txbHoTen.Text;
                    this.user.Email = txbEmail.Text;
                    this.user.PhoneNumber = txbSdt.Text;
                    this.user.Birthday = dtRegister.Value;
                    context.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                
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
            if (regex.Match(password).Success)
            {
                ptbMatKhau.Visible = true;
                ptbMatKhau.Image = Resources.check;
            }
            else
            {
                ptbMatKhau.Visible = true;
                ptbMatKhau.Image = Resources.warning;
                toolTip1.SetToolTip(ptbMatKhau, "Mật khẩu tối thiểu 6 ký tự" +
                    " và chứa kí tự đặc biệt hoặc kí tự in hoa !");

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
        private void btnHide_Click(object sender, EventArgs e)
        {
            btnHide.Visible = false;
            btnShow.Visible = true;
            txbMatKhauDangKy.UseSystemPasswordChar = false;
            txbMatKhauDangKy.PasswordChar = '\0';
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Visible = false;
            btnHide.Visible = true;
            txbMatKhauDangKy.UseSystemPasswordChar = true;
        }
    }
}