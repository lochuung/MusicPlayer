using System;
using System.Linq;
using System.Windows.Forms;
using MusicPlayer.Database;

namespace MusicPlayer.View
{
    public partial class SecurityCode : Form
    {
        private readonly string email;
        private ForgetPW forgetPW;

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
            var emailsdt = forgetPW.EmailorSdtText;
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
            var forget = new ForgetPW();
            forget.Show();
            Hide();
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbCode.Text))
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

                var newPW = new NewPW(email);
                newPW.Show();
                Hide();
            }
        }
    }
}