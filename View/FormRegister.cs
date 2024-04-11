using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI;Initial Catalog=MusicFM;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    if (txbHoTen.Text == "" ||
                        txbEmail.Text == "" ||
                        !txbSdt.Text.StartsWith("0") ||
                        txbMatKhauDangKy.Text == "" ||
                        txbMatKhauDangKy.Text != txbNhapLaiMatKhau.Text)
                    {
                        MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAll();
                    }
                    else
                    {
                        string query = @"INSERT INTO Users ([HoTen],[NamSinh],[Email],[SoDienThoai],[MatKhau]) 
                                       VALUES (@HoTen, @NamSinh, @Email, @SoDienThoai, @MatKhau)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {

                            cmd.Parameters.AddWithValue("@HoTen", txbHoTen.Text);
                            cmd.Parameters.AddWithValue("@Email", txbEmail.Text);
                            cmd.Parameters.AddWithValue("@NamSinh", dtRegister.Text);
                            cmd.Parameters.AddWithValue("@SoDienThoai", txbSdt.Text);
                            cmd.Parameters.AddWithValue("@MatKhau", txbMatKhauDangKy.Text);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Đăng ký thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAll();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
