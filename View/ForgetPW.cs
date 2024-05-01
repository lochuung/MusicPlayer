using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
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
            int dem = 0;
            var connectionString = "Data Source=LAPTOP-3N644IDG;Initial Catalog=UserFM;Integrated Security=True";
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "Select Count(*) from Users where Email = @Email";
                    using (var cmd = new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@Email", txbEmailOrSdt.Text);
                        var count = (int)cmd.ExecuteScalar();
                        if(count > 0)
                        {
                            email = txbEmailOrSdt.Text;
                            var title = "FineMuSic";
                            var body = "Mã code: .....";
                            SendMail(title, body);
                            SecurityCode securityCode = new SecurityCode(email);
                            securityCode.Show();
                            this.Hide();
                            
                        }
                        else
                        {
                            dem++;
                            MessageBox.Show("Vui lòng nhập đúng Email", "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        if(dem >= 3)
                        {
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                message.Body = $"< html >< body >< h1 > FineMusic </ h1 >" +
                               $"< span ><b> ${code}</b> là mã đặt lại mật khẩu FineMusic của bạn </ p ></ body ></ html > ";

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
           /* try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("tuongporo9x2004@gmail.com");
                message.To.Add(new MailAddress("manhtuong24.2004@gmail.com"));
                message.Subject = title;
                message.Body = body;
                message.IsBodyHtml = true;
                message.Body = "< html >< body >< h1 > FineMusic </ h1 >< p > MaCode là mã đặt lại mật khẩu FineMusic của bạn </ p ></ body ></ html > ";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new NetworkCredential("tuongporo9x2004@gmail.com", "strongwall2004");

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: " + ex.Message);
            }*/
        }

    }
}
