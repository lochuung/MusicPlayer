using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            var connectionString = "Data Source=MSI;Initial Catalog=MusicFM;Integrated Security=True";
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    if (ptbEmail.Image == Properties.Resources.warning ||
                        ptbSoDienThoai.Image == Properties.Resources.warning ||
                        ptbMatKhau.Image == Properties.Resources.warning ||
                        ptbNhapLaiMatKhau.Image == Properties.Resources.warning)
                    {
                        MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        ClearAll();
                    }
                    else
                    {
                        var query = @"INSERT INTO Users ([HoTen],[NamSinh],[Email],[SoDienThoai],[MatKhau]) 
                                       VALUES (@HoTen, @NamSinh, @Email, @SoDienThoai, @MatKhau)";

                        using (var cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@HoTen", txbHoTen.Text);
                            cmd.Parameters.AddWithValue("@Email", txbEmail.Text);
                            cmd.Parameters.AddWithValue("@NamSinh", dtRegister.Text);
                            cmd.Parameters.AddWithValue("@SoDienThoai", txbSdt.Text);
                            cmd.Parameters.AddWithValue("@MatKhau", txbMatKhauDangKy.Text);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Đăng ký thành công !", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        ClearAll();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            Application.Exit();
        }

        private void txbHoTen_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbHoTen.Text))
            {
                ptbHoTen.Visible = true;
                ptbHoTen.Image = Properties.Resources.check; 
            }
            else
            {
                ptbHoTen.Visible = false;
            }
        }

        private void txbEmail_Validated(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txbEmail.Text))
            {
                ptbEmail.Visible = true;
                ptbEmail.Image = Properties.Resources.check;
            }
            else
            {
                ptbEmail.Visible = true;
                ptbEmail.Image = Properties.Resources.warning;

                if(ptbEmail.Image == Properties.Resources.warning)
                {
                    toolTip1.SetToolTip(ptbEmail, "Bạn chưa nhập Email hoặc Email đã được đăng ký trước đó !");
                }
            }
        }

        private void txbSdt_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbSdt.Text) && txbSdt.Text.StartsWith("0") && txbSdt.Text.Length == 10)
            {
                ptbSoDienThoai.Visible = true;
                ptbSoDienThoai.Image = Properties.Resources.check;
            }
            else
            {
                ptbSoDienThoai.Visible = true;
                ptbSoDienThoai.Image = Properties.Resources.warning;
                if(ptbSoDienThoai.Image == Properties.Resources.warning)
                {
                    toolTip1.SetToolTip(ptbSoDienThoai, "Vui lòng nhập đúng sđt hoặc sđt đã được đăng ký trước đó !");
                }
                
            }
        }

        private void txbMatKhauDangKy_Validated(object sender, EventArgs e)
        {
            string password = txbMatKhauDangKy.Text;
            if(!string.IsNullOrWhiteSpace(password) && password.Replace(" ", "").Length >= 6 )
            {
                ptbMatKhau.Visible = true;
                ptbMatKhau.Image = Properties.Resources.check;
            }
            else
            {
                ptbMatKhau.Visible = true;
                ptbMatKhau.Image = Properties.Resources.warning;
                if(ptbMatKhau.Image == Properties.Resources.warning)
                {
                    toolTip1.SetToolTip(ptbMatKhau, "Mật khẩu tối thiểu 6 ký tự và không chứa khoảng trắng !");
                }
                
            }
        }

        private void txbNhapLaiMatKhau_Validated(object sender, EventArgs e)
        {
            if(txbMatKhauDangKy.Text == txbNhapLaiMatKhau.Text)
            {
                ptbNhapLaiMatKhau.Visible = true;
                ptbNhapLaiMatKhau.Image = Properties.Resources.check;
            }
            else
            {
                ptbNhapLaiMatKhau.Visible = true;
                ptbNhapLaiMatKhau.Image = Properties.Resources.warning;
                if(ptbNhapLaiMatKhau.Image == Properties.Resources.warning)
                {
                    toolTip1.SetToolTip(ptbNhapLaiMatKhau, "Vui lòng nhập đúng !");
                }
                
            }
        }
    }
}