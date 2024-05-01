using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MusicPlayer.Database;

namespace MusicPlayer.View
{
    public partial class NewPW : Form
    {
        private readonly string email;
        private readonly Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[a-z]).{6,}$");

        public NewPW(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        public NewPW()
        {
            InitializeComponent();
        }

        private void btnThongTinPw_Click(object sender, EventArgs e)
        {
            var constraintPW = new ConstraintPW();
            constraintPW.ShowDialog();
        }

        private void txbMatKhauMoi_TextChanged(object sender, EventArgs e)
        {
            if (regex.IsMatch(txbMatKhauMoi.Text))
            {
                lblStrPw.Text = "Mật khẩu mạnh";
                lblStrPw.Visible = true;
                lblStrPw.Show();
            }
            else if (!string.IsNullOrWhiteSpace(txbMatKhauMoi.Text) && txbMatKhauMoi.Text.Replace(" ", "").Length >= 6)
            {
                var firstChar = txbMatKhauMoi.Text.FirstOrDefault();
                if (char.IsUpper(firstChar))
                {
                    lblStrPw.Text = "Mật khẩu trung bình";
                    lblStrPw.Visible = true;
                    lblStrPw.Show();
                }
            }
            else
            {
                lblStrPw.Text = "Mật khẩu yếu ";
                lblStrPw.Visible = true;
                lblStrPw.Show();
            }
        }

        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            var matKhauMoi = txbMatKhauMoi.Text;

            var capNhatThanhCong = CapNhatMatKhau(email, matKhauMoi);

            if (capNhatThanhCong)
            {
                MessageBox.Show("Cập nhật mật khẩu mới thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                var mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu mới thất bại!", "" +
                                                                   "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CapNhatMatKhau(string email, string matKhauMoi)
        {
            using (var context = new MusicDbContext())
            {
                var user = from u in context.Users
                    where u.Email == email
                    select u;
                if (user.Count() == 0) return false;
                user.First().Password = matKhauMoi;
                context.SaveChanges();
                return true;
            }
        }
    }
}