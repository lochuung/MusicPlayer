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
    public partial class LoadFormUsers : Form
    {
        public LoadFormUsers()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(guna2CircleProgressBar1.Value == 100 )
            {
                timer1.Stop();

            }
            else
            {
                guna2CircleProgressBar1.Value += 1;
                lbValue.Text = (Convert.ToInt32(lbValue.Text) + 1).ToString();
            }
        }

        private void LoadFormUsers_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
        }


    }
}
