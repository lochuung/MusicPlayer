using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MusicPlayer.Admin
{
    public partial class Uc_AddUser : UserControl
    {
        
        public Uc_AddUser()
        {
            InitializeComponent();
        }

        private void btnDangKyAU_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=UsersMusicManagement;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    if (txbHoTenAU.Text == "" ||
                    txbEmailAU.Text == "" ||
                    txbSoDienThoaiAU.Text == "" ||
                    !txbSoDienThoaiAU.Text.StartsWith("0") ||
                    txbMatKhauAU.Text == "" ||
                    cbVaiTroAU.SelectedItem == null ||
                    txbMatKhauAU.Text != txbNhapLaiMatKhauAU.Text)
                    {
                        MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearAll();
                    }
                    else if(ptbEmailAu.ImageLocation == @"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\error.png" ||
                             ptbNhapLaiMatKhau.ImageLocation == @"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\error.png" ||
                             ptbSoDienThoaiAu.ImageLocation == @"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\error.png")
                    {
                        MessageBox.Show("Vui lòng nhập đúng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string query = @"INSERT INTO ThongTinUsers ([HoTen],[NamSinh],[Email],[SoDienThoai],[MatKhau],[VaiTro]) 
                                       VALUES (@HoTen, @NamSinh, @Email, @SoDienThoai, @MatKhau, @VaiTro)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {

                            cmd.Parameters.AddWithValue("@HoTen", txbHoTenAU.Text);
                            cmd.Parameters.AddWithValue("@NamSinh", dtAU.Text);
                            cmd.Parameters.AddWithValue("@Email", txbEmailAU.Text);
                            cmd.Parameters.AddWithValue("@SoDienThoai", txbSoDienThoaiAU.Text);
                            cmd.Parameters.AddWithValue("@MatKhau", txbMatKhauAU.Text);
                            cmd.Parameters.AddWithValue("@VaiTro", cbVaiTroAU.SelectedItem.ToString());

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Đăng ký thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearAll();
                    }
                    
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void clearAll()
        {
            txbHoTenAU.Clear();
            txbEmailAU.Clear();
            txbMatKhauAU.Clear();
            txbNhapLaiMatKhauAU.Clear();
            txbSoDienThoaiAU.Clear();
            dtAU.ResetText();
            cbVaiTroAU.SelectedIndex = -1;
        }

        private void txbNhapLaiMatKhauAU_TextChanged(object sender, EventArgs e)
        {
            if (txbNhapLaiMatKhauAU.Text != txbMatKhauAU.Text || txbNhapLaiMatKhauAU.Text == "")
            {
                ptbNhapLaiMatKhau.ImageLocation = @"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\error.png";
            }
            else
            {
                ptbNhapLaiMatKhau.ImageLocation = @"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\check.png";
            }
        }

        private void txbEmailAU_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=UsersMusicManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                String query = @"select * from ThongTinUsers where Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", txbEmailAU.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read() || txbEmailAU.Text == "")
                        {
                            ptbEmailAu.ImageLocation = @"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\error.png";
                        }
                        else
                        {
                            ptbEmailAu.ImageLocation = @"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\check.png";
                        }
                    }
                }
            }
        }

        private void txbSoDienThoaiAU_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=UsersMusicManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                String query = @"select * from ThongTinUsers where SoDienThoai = @SoDienThoai";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", txbSoDienThoaiAU.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() || txbSoDienThoaiAU.Text == "")
                        {
                            ptbSoDienThoaiAu.ImageLocation = @"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\error.png";
                        }
                        else
                        {
                            ptbSoDienThoaiAu.ImageLocation = @"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\check.png";
                        }
                    }
                }
            }
        }
    }
}
