using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using MusicPlayer.Database;
using MusicPlayer.Database.Entity;

namespace MusicPlayer.View
{
    public partial class ForgetPW : Form
    {
        public ForgetPW()
        {
            InitializeComponent();
        }

        public string Email { get; private set; }

        public string EmailorSdtText => txbEmailOrSdt.Text;

        private void btnExit_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            Hide();
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

                Email = txbEmailOrSdt.Text;
                var code = Guid.NewGuid().ToString();
                SendMail("FineMusic - Mã đặt lại mật khẩu", code);
                var verify = new Verify
                {
                    Code = code,
                    UserId = user.First().UserId
                };
                context.Verifies.Add(verify);
                context.SaveChanges();

                var securityCode = new SecurityCode(this);
                securityCode.Show();
                Hide();
            }
        }

        private void SendMail(string title, string code)
        {
            try
            {
                var message = new MailMessage();
                var smtp = new SmtpClient();

                message.From = new MailAddress("Hotel.HL.BB@gmail.com");
                message.To.Add(new MailAddress(Email));
                message.Subject = title;
                // html body
                message.IsBodyHtml = true;
                message.Body = "<h1> FineMusic </h1>" +
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
        private string GenerateRandomCode()
        {
            Random random = new Random();
            int code = random.Next(10000, 99999);
            return code.ToString();
        }
    }
}