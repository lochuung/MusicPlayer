using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using MusicPlayer.Database;

namespace MusicPlayer.View
{
    public partial class NewPW : Form
    {
        Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[a-z]).{6,}$");
        private string email;

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
            ConstraintPW constraintPW = new ConstraintPW();
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
            else if(!string.IsNullOrWhiteSpace(txbMatKhauMoi.Text) && txbMatKhauMoi.Text.Replace(" ", "").Length >= 6)
            {
                char firstChar = txbMatKhauMoi.Text.FirstOrDefault();
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
             string matKhauMoi = txbMatKhauMoi.Text;

             bool capNhatThanhCong = CapNhatMatKhau(email, matKhauMoi);

             if (capNhatThanhCong)
             {
                 MessageBox.Show("Cập nhật mật khẩu mới thành công!", 
                     "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    MainForm mainForm = new MainForm();
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
                if (user.Count() == 0)
                {
                    return false;
                }
                user.First().Password = matKhauMoi;
                context.SaveChanges();
                return true;
            }
        }
    }
}
