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

namespace MusicPlayer.View
{
    public partial class NewPW : Form
    {
        Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[a-z]).{6,}$");
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
            /*string email = txbEmail.Text;
            string matKhauMoi = txbMatKhauMoi.Text;

            bool capNhatThanhCong = CapNhatMatKhau(email, matKhauMoi);

            if (capNhatThanhCong)
            {
                MessageBox.Show("Cập nhật mật khẩu mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        private bool CapNhatMatKhau(string email, string matKhauMoi)
        {
            var connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=UserFM;Integrated Security=True";
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Users SET MatKhau = @MatKhauMoi WHERE Email = @Email";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
                    cmd.Parameters.AddWithValue("@Email", email);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
