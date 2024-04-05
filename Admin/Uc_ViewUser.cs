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
    
    public partial class Uc_ViewUser : UserControl
    {
        
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        String currentUser = "";

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Users ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            guna2DataGridView1.DataSource = table;
        }
        String userName;
        void deleteData()
        {
            if (connection != null)
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Users WHERE username = @UserName";
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.ExecuteNonQuery();
                }
            }
        }
        public Uc_ViewUser()
        {
            InitializeComponent();
        }

        private void Uc_ViewUser_Load(object sender, EventArgs e)
        {
            
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
        }

        private void btnTaiLaiVU_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnXoaVU_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xoá ?", "Xoá thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string emailToDelete = "abcdxyz"; 
                    string query = "DELETE FROM users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", emailToDelete);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đã xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không có người dùng nào được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void txbMatKhauAU_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                String query = @"Select * from users where Email like @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", txbTimKiemAU.Text + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        guna2DataGridView1.DataSource = dataTable;
                    }
                }
            }
        }
    }
}
