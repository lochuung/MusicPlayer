using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MusicPlayer.Admin
{
    public partial class Uc_ViewUser : UserControl
    {
        private readonly SqlDataAdapter adapter = new SqlDataAdapter();
        private readonly string str = @"Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
        private readonly DataTable table = new DataTable();
        private SqlCommand command;

        private SqlConnection connection;

        public Uc_ViewUser()
        {
            InitializeComponent();
        }


        private void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Users ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            guna2DataGridView1.DataSource = table;
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
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa các dòng được chọn?", "Xóa thông tin",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";

                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();

                    foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                        if (!row.IsNewRow)
                        {
                            var emailToDelete = row.Cells["Email"].Value.ToString();

                            var query = "DELETE FROM users WHERE Email = @Email";

                            using (var cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@Email", emailToDelete);
                                cmd.ExecuteNonQuery();
                            }

                            guna2DataGridView1.Rows.Remove(row);
                        }

                    MessageBox.Show("Đã xóa thành công !", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }


        private void txbMatKhauAU_TextChanged(object sender, EventArgs e)
        {
            var connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=MuSicFM;Integrated Security=True";
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = @"Select * from users where Email like @Email";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", txbTimKiemAU.Text + "%");
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        guna2DataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}