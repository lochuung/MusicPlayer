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

        private void btnExitDangNhap_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
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
            string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=UsersMusicManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = string.Format("SELECT * FROM ThongTinUsers WHERE Email = '{0}' AND MatKhau = '{1}'", txbUserName.Text, txbPassWord.Text);

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //cmd.Parameters.AddWithValue("@Email", txbUserName.Text);
                    //cmd.Parameters.AddWithValue("@MatKhau", txbPassWord.Text);
                    

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string vaiTro = reader["VaiTro"].ToString();
                            /*MessageBox.Show(vaiTro.Count().ToString());*/
                            if (vaiTro == @"Admin")
                            {
                                FormAdmin formAdmin = new FormAdmin();
                                formAdmin.Show();
                                this.Hide();
                            }
                            else if (vaiTro == @"User")
                            {
                                FormUsers formUsers = new FormUsers();
                                formUsers.Show();
                                this.Hide();
                            }
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
