using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace MusicPlayer.View
{
    public partial class ForgetPW : Form
    {
        public ForgetPW()
        {
            InitializeComponent();
        }
        public string EmailorSdtText
        {
            get { return txbEmailOrSdt.Text; }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int dem = 0;
            var connectionString = "";
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "Select Email from Users where Email = @Email";
                    using (var cmd = new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@Email", txbEmailOrSdt.Text);
                        var count = (int)cmd.ExecuteScalar();
                        if(count > 0)
                        {
                            SecurityCode securityCode = new SecurityCode();
                            securityCode.Show();
                            this.Hide();
                        }
                        else
                        {
                            dem++;
                            MessageBox.Show("Vui lòng nhập đúng Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if(dem >= 3)
                        {
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
