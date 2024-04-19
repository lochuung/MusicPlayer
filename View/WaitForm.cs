using System.Drawing;
using System.Windows.Forms;

namespace WaitFormExample
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        public WaitForm(Form parent)
        {
            InitializeComponent();
            if (parent != null)
            {
                StartPosition = FormStartPosition.CenterParent;
                Location = new Point(parent.Location.X + parent.Width / 2 - Width / 2,
                    parent.Location.Y + parent.Height / 2 - Height / 2);
            }
            else
            {
                StartPosition = FormStartPosition.CenterParent;
            }
        }

        public void CloseWaitForm()
        {
            DialogResult = DialogResult.OK;
            Close();
            if (label1.Image != null) label1.Image.Dispose();
        }
    }
}