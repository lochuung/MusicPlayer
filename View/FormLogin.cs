using System;
using System.Data.SqlClient;
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
            var mainForm = new MainForm();
            mainForm.Show();
            Hide();
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
            var connectionString = "Data Source=MSI;Initial Catalog=MusicFM;Integrated Security=True";
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = string.Format("SELECT * FROM Users WHERE Email = '{0}' AND MatKhau = '{1}'",
                    txbUserName.Text, txbPassWord.Text);

                using (var cmd = new SqlCommand(query, con))
                {
                    //cmd.Parameters.AddWithValue("@Email", txbUserName.Text);
                    //cmd.Parameters.AddWithValue("@MatKhau", txbPassWord.Text);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var HoTen = reader["HoTen"].ToString();
                            var formUsers = new FormUsers(HoTen);
                            formUsers.Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Erros", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            clearAll();
                        }
                    }
                }
            }

            var load = new LoadFormUsers();
            load.Show();
            Hide();
        }

        public void clearAll()
        {
            txbPassWord.Clear();
            txbUserName.Clear();
        }

        private void txbUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool EmailExit = false;
            var connectionString = "";
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select Email FROM Users Where Email = @Email";
                using (var cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@Email", txbUserName.Text);
                    int count = (int)cmd.ExecuteScalar();
                    if(count > 0)
                    {
                        EmailExit = true;
                    }
                }
            }
            if(EmailExit)
            {
                errorProvider1.SetError(txbUserName, "");
            }
            else
            {
                errorProvider1.SetError(txbUserName, "Bạn nhập sai Email hoặc tài khoản chưa được đăng ký");
            }
        }
    }
}