using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using MusicPlayer.Database;

namespace MusicPlayer.View
{
    public partial class SecurityCode : Form
    {
        private ForgetPW forgetPW;
        private string email;

        public SecurityCode(string email)
        {
            InitializeComponent();
            this.email = email;
            lblEmail.Text = email;
        }
        public SecurityCode(ForgetPW forgetPW)
        {
            InitializeComponent();
            email = forgetPW.Email;
            string emailsdt = forgetPW.EmailorSdtText;
            lblEmail.Text = emailsdt;
            lblEmail.Visible = true;
            lblEmail.Show();

            /*this.Controls.Add(forgetPW);*/
        }

        private void SecurityCode_Load(object sender, EventArgs e)
        {
            /*string emailsdt = forgetPW.EmailorSdtText;
            lblEmail.Text = emailsdt;*/
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ForgetPW forget = new ForgetPW();
            forget.Show();
            this.Hide();
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txbCode.Text))
            {
                lblNhapMa.Visible = true;
                lblNhapMa.Show();
            }
            else
            {
                using (var context = new MusicDbContext())
                {
                    var verify = from v in context.Verifies
                                 where v.Code == txbCode.Text && v.User.Email == email
                                 select v;
                    if (verify.Count() == 0)
                    {
                        MessageBox.Show("Mã không hợp lệ!");
                        return;
                    }
                    if (verify.First().ExpiredDate < DateTime.Now)
                    {
                        MessageBox.Show("Mã đã hết hạn!");
                        return;
                    }
                    context.Verifies.Remove(verify.First());
                    context.SaveChanges();
                }
                NewPW newPW = new NewPW(email);
                newPW.Show();
                this.Hide();
            }
        }
    }
}
