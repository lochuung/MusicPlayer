using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MusicPlayer.Admin
{
    public partial class Uc_Profile : UserControl
    {
        public Uc_Profile()
        {
            InitializeComponent();
        }

        public Uc_Profile(string hoTen)
        {
            InitializeComponent();
            lblHoTenPF.Text = hoTen;
        }

        public void UpdateName(string hoTen)
        {
            lblHoTenPF.Text = hoTen;
        }

        private void lblHoTenPF_Click(object sender, EventArgs e)
        {
            /*string email = "";
            email = GetUserName()*/
        }
        /* private String GetUserName(string email, string password)
         {
             string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
             string HoTen = "";
             using (SqlConnection con = new SqlConnection(connectionString))
             {
                 con.Open();
                 string query = "select HoTen from users where Email = @Email AND MatKhau = @MatKhau";
                 using (SqlCommand cmd = new SqlCommand(query,con))
                 {
                     cmd.Parameters.AddWithValue("@Email", email);
                     cmd.Parameters.AddWithValue("@MatKhau", password);
                     object result = cmd.ExecuteScalar();
                     {
                         if(result != null)
                         {
                             HoTen = result.ToString();
                         }
                     }
                 }
             }
             return HoTen;
         }*/

        private void lblHoTenPF_TextAlignChanged(object sender, EventArgs e)
        {
            /*string emailDangNhap = "example@example.com";

            string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT HoTen FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", emailDangNhap);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string hoTen = result.ToString();
                        lblHoTenPF.Text = hoTen;
                    }
                }
            }*/
        }

        private void UC_Profile_Enter(object sender, EventArgs e)
        {
            var email = lblHoTenPF.Text;

            var connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT * FROM users WHERE Email = @Email";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txbHoTenPF.Text = reader["HoTen"].ToString();
                            dtPF.Text = reader["NamSinh"].ToString();
                            txbEmailPF.Text = reader["Email"].ToString();
                            txbSoDienThoaiPF.Text = reader["SoDienThoai"].ToString();
                            txbMatKhauPF.Text = reader["MatKhau"].ToString();
                            cbVaiTroPF.Text = reader["VaiTro"].ToString();
                        }
                    }
                }
            }
        }
    }
}