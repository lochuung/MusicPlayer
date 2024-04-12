using System;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class FormAdmin : Form
    {
        private string hoTen;

        public FormAdmin()
        {
            InitializeComponent();
        }

        public FormAdmin(string hoTen)
        {
            InitializeComponent();
            this.hoTen = hoTen;
            lblUserName.Text = hoTen;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            uc_AddUser1.Visible = false;
            uc_ViewUser1.Visible = false;
            uc_Profile1.Visible = false;
            /* string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tuong\OneDrive\Documents\LapTrinhWinProJect\ManagerMusic\ViewUserFM.mdf;Integrated Security=True;Connect Timeout=30";
             using (SqlConnection con = new SqlConnection(connectionString))
             {
                 con.Open();
                 string query = "select HoTen from users where Email = @Email and MatKhau = @MatKhau";
                 using (SqlCommand cmd = new SqlCommand(query,con))
                 {
                     using(SqlDataReader reader = cmd.ExecuteReader())
                     {
                         */ /*cmd.Parameters.AddWithValue("@Email", )
                         if(reader.Read)*/ /*
                     }
                 }
             }*/
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uc_AddUser1.Visible = true;
            uc_AddUser1.BringToFront();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            uc_ViewUser1.Visible = true;
            uc_ViewUser1.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uc_Profile1.Visible = true;
            uc_Profile1.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
        }
    }
}