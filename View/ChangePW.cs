using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicPlayer.Database;

namespace MusicPlayer.View
{
    public partial class ChangePW : Form
    {
        private readonly string email;
        private readonly Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[a-z]).{6,}$");
        private bool isValid = false;
        public ChangePW()
        {
            InitializeComponent();
            btnHide.Click += btnHide_Click;
            btnShow.Click += btnShow_Click;
        }
        public ChangePW(string email)
        {
            InitializeComponent();
            this.email = email;
        }
        private void btnExitMainForm_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnThongTinPw_Click(object sender, EventArgs e)
        {
            var constrainPw = new View.ConstraintPW();
            constrainPw.ShowDialog();
        }
        private void txbNewPw_TextChanged(object sender, EventArgs e)
        {
            if (regex.IsMatch(txbNewPw.Text))
            {
                lblStrPw.Text = "Mật khẩu mạnh";
                lblStrPw.Visible = true;
                lblStrPw.Show();
                isValid = true;
            }
            else if (!string.IsNullOrWhiteSpace(txbNewPw.Text) && txbNewPw.Text.Replace(" ", "").Length >= 6)
            {
                var firstChar = txbNewPw.Text.FirstOrDefault();
                if (char.IsUpper(firstChar))
                {
                    lblStrPw.Text = "Mật khẩu trung bình";
                    lblStrPw.Visible = true;
                    lblStrPw.Show();
                    isValid = false;
                }
            }
            else
            {
                lblStrPw.Text = "Mật khẩu yếu ";
                lblStrPw.Visible = true;
                lblStrPw.Show();
                isValid = false;
            }
        }

        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            var matKhauMoi = txbNewPw.Text;
            var matKhauCu = txbPwNow.Text;
            var thayDoiMatKhau = ThayDoiMatKhau(email, matKhauMoi, matKhauCu);
            if(thayDoiMatKhau == true && matKhauMoi == txbRePw.Text)
            {
                MessageBox.Show("Cập nhật mật khẩu mới thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu mới thất bại!", "" +
                                                                   "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ThayDoiMatKhau(string email, string matKhauMoi, string matKhauCu)
        {
            using (var context = new MusicDbContext())
            {
                try
                {
                    var user = context.Users.FirstOrDefault(u => u.Email == email);
                    if (user != null)
                    {
                        if (user.Password == matKhauCu)
                        {
                            user.Password = matKhauMoi;
                            context.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Người dùng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private void btnHide_Click(object sender, EventArgs e)
        {
            btnHide.Visible = false;
            btnShow.Visible = true;
            txbNewPw.UseSystemPasswordChar = false;
            txbNewPw.PasswordChar = '\0';
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Visible = false;
            btnHide.Visible = true;
            txbNewPw.UseSystemPasswordChar = true;
        }

    }
}
