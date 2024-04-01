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

                    if(txbHoTenAU.Text == "" ||
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

       /* private void ptbNhapLaiMatKhau_Click(object sender, EventArgs e)
        {
            if(txbMatKhauAU.Text == txbNhapLaiMatKhauAU.Text)
            {
                ptbNhapLaiMatKhau.Image = Image.FromFile(@"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\check.png");
            }
        }
*/
        private void ptbNhapLaiMatKhau_Click_1(object sender, EventArgs e)
        {
            if (txbMatKhauAU.Text == txbNhapLaiMatKhauAU.Text)
            {
                ptbNhapLaiMatKhau.Image = Image.FromFile(@"C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\Picture\check.png");
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
    }
}
