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
    public partial class FormLogin : Form
    {
        
        public FormLogin()
        {
            InitializeComponent();
            
        }
       /* public event EventHandler<string> UserLoggedIn;
        protected virtual void onUserLoggedIn(string email)
        {
            UserLoggedIn?.Invoke(this, email);
        }*/
        private void btnExitDangNhap_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
           /* string userEmail = "Ex";
            onUserLoggedIn(userEmail);*/
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            /*if (txbUserName.Text == "tuong" && txbPassWord.Text == "1")
            {
                FormAdmin formAdmin = new FormAdmin();
                formAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbUserName.Clear();
                txbPassWord.Clear();
            }*/
            string connectionString = "Data Source=MSI;Initial Catalog=MusicFM;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = string.Format("SELECT * FROM Users WHERE Email = '{0}' AND MatKhau = '{1}'", txbUserName.Text, txbPassWord.Text);

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //cmd.Parameters.AddWithValue("@Email", txbUserName.Text);
                    //cmd.Parameters.AddWithValue("@MatKhau", txbPassWord.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string HoTen = reader["HoTen"].ToString();
                            FormUsers formUsers = new FormUsers(HoTen);
                            formUsers.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clearAll();
                        }
                    }
                }
            }
        }
        public void clearAll()
        {
            txbPassWord.Clear();
            txbUserName.Clear();
        }
    }
}
