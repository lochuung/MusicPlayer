using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace MusicPlayer.View
{
    public partial class NewPW : Form
    {
        Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[a-z]).{6,}$");
        public NewPW()
        {
            InitializeComponent();
        }

        private void btnThongTinPw_Click(object sender, EventArgs e)
        {
            ConstraintPW constraintPW = new ConstraintPW();
            constraintPW.ShowDialog();
        }

        private void txbMatKhauMoi_TextChanged(object sender, EventArgs e)
        {
            if (regex.IsMatch(txbMatKhauMoi.Text))
            {
                lblStrPw.Text = "Mật khẩu mạnh";
                lblStrPw.Visible = true;
                lblStrPw.Show();
            }
            else if(!string.IsNullOrWhiteSpace(txbMatKhauMoi.Text) && txbMatKhauMoi.Text.Replace(" ", "").Length >= 6)
            {
                char firstChar = txbMatKhauMoi.Text.FirstOrDefault();
                if (char.IsUpper(firstChar))
                {
                    lblStrPw.Text = "Mật khẩu trung bình";
                    lblStrPw.Visible = true;
                    lblStrPw.Show();
                }
            }
            else
            {
                lblStrPw.Text = "Mật khẩu yếu ";
                lblStrPw.Visible = true;
                lblStrPw.Show();
            }
        }
    }
}
