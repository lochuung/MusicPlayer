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
using System.Data;
namespace MusicPlayer.Admin
{
    public partial class Uc_ViewUser : UserControl
    {
        
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-3N644IDG;Initial Catalog=UsersMusicManagement;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        String currentUser = "";
        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThongTinUsers ";
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
                    command.CommandText = "DELETE FROM ThongTinUsers WHERE username = @UserName";
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
  
                if (!string.IsNullOrEmpty(currentUser) && !string.IsNullOrEmpty(userName))
                {
                    if (currentUser != userName)
                    {
                        connection = new SqlConnection(str);
                        connection.Open();
                        deleteData();
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng xoá lại \n Hồ sơ sửa bạn!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xoá vì thông tin người dùng không hợp lệ!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
