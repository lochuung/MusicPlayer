using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class FormAdmin : Form
    {
        String user = "";

        public FormAdmin()
        {
            InitializeComponent();
        }
      /* public string Email
        {
            get { return user.ToString(); }
        }
        public FormAdmin(String userName)
        {
            InitializeComponent();
            lblUserName.Text = userName;
            user = userName;
            uc_Profile1.Email = Email;
        }*/
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            uc_AddUser1.Visible = false;
            uc_ViewUser1.Visible = false;
            uc_Profile1.Visible = false;
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uc_AddUser1.Visible = true;
            uc_AddUser1.BringToFront();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
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
    }
}
