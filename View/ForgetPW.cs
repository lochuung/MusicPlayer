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
                
                User firstUser = user.First();
                string code;
                do
                {
                    code = GenerateRandomCode();
                } while (context.Verifies.Any(v => v.Code == code && v.UserId == firstUser.UserId));
                var verify = new Verify
                {
                    Code = code,
                    UserId = firstUser.UserId
                };
                context.Verifies.Add(verify);
                context.SaveChanges();
                
                SendMail("FineMusic - Mã đặt lại mật khẩu", code);

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
                message.Body =
                   $"<p><h1>{code}</h1> là mã đặt lại mật khẩu FineMusic của bạn</p>";

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
            var random = new Random();
            var code = "";
            for (var i = 0; i < 6; i++)
            {
                code += random.Next(0, 9).ToString();
            }

            return code;
        }
    }
}