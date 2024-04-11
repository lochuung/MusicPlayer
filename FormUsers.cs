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
    public partial class FormUsers : Form
    {
        private string hoTen;

        public FormUsers()
        {
            InitializeComponent();
        }

        public FormUsers(string hoTen)
        {
            this.hoTen = hoTen;
        }
    }
}
