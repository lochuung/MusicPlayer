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
    public partial class Uc_Profile : UserControl
    {
        public string UserNameFormLogin { get; set; }
        public Uc_Profile()
        {
            InitializeComponent();
        }

        public String Email
        {
            set { lblHoTenPF.Text = value; }
        }

        private void lblHoTenPF_Click(object sender, EventArgs e)
        {
            string email = lblHoTenPF.Text;

            string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT HoTen FROM users WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string hoTen = result.ToString();
                        lblHoTenPF.Text = hoTen; 
                    }
                   
                }
            }
        }


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
            string email = lblHoTenPF.Text; 

            string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM users WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
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
