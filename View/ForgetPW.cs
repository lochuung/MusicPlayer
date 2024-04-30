﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
namespace MusicPlayer.View
{
    public partial class ForgetPW : Form
    {
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
            var connectionString = "";
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "Select Email from Users where Email = @Email";
                    using (var cmd = new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@Email", txbEmailOrSdt.Text);
                        var count = (int)cmd.ExecuteScalar();
                        if(count > 0)
                        {
                            var title = "FineMuSic";
                            var body = "Mã code: .....";
                            SendMail(title, body);
                            SecurityCode securityCode = new SecurityCode();
                            securityCode.Show();
                            this.Hide();
                            
                        }
                        else
                        {
                            dem++;
                            MessageBox.Show("Vui lòng nhập đúng Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void SendMail(string title, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("manhtuong24.2004@gmail.com");
                message.To.Add(new MailAddress(txbEmailOrSdt.Text));
                message.Subject = title;
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("manhtuong24.2004@gmail.com", "manhtuongne2004");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Err: " + ex.Message);
            }
        }

    }
}
