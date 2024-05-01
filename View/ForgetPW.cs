using System;
using System.Linq;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using MusicPlayer.Database;
using MusicPlayer.Database.Entity;

namespace MusicPlayer.View
{
    public partial class ForgetPW : Form
    {
        private string email;

        public string Email
        {
            get { return email; }
        }
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
            if (string.IsNullOrEmpty(txbEmailOrSdt.Text))
            {
                MessageBox.Show("Vui lòng nhập email!");
                return;
            }

            using (var context = new MusicDbContext())
            {
                var user = from u in context.Users
                           where u.Email == txbEmailOrSdt.Text
                           select u;
                if (user.Count() == 0)
                {
                    MessageBox.Show("Email không tồn tại!");
                    return;
                }
                email = txbEmailOrSdt.Text;
                string code = Guid.NewGuid().ToString();
                SendMail("FineMusic - Mã đặt lại mật khẩu", code);
                MessageBox.Show("Mã đặt lại mật khẩu đã được gửi đến email của bạn!");
                Verify verify = new Verify
                {
                    Code = code,
                    UserId = user.First().UserId
                };
                context.Verifies.Add(verify);
                context.SaveChanges();
                
                SecurityCode securityCode = new SecurityCode(this);
                securityCode.Show();
                this.Hide();
            }
        }
        private void SendMail(string title, string code)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("Hotel.HL.BB@gmail.com");
                message.To.Add(new MailAddress(email));
                message.Subject = title;
                // html body
                message.IsBodyHtml = true;
                message.Body = $"<h1> FineMusic </h1>" +
                               $"<span><b>{code}</b> là mã đặt lại mật khẩu FineMusic của bạn </p>";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("Hotel.HL.BB@gmail.com", "ucfocygvvxbawius");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }

    }
}
