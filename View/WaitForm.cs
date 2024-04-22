using System.Drawing;
using System.Windows.Forms;

namespace WaitFormExample
{
    public partial class WaitForm : Form
    {
        Form parentForm;
        public WaitForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public WaitForm(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void Show()
        {
            // show the wait form
            base.Show();
            // disable the parent form
            parentForm.Enabled = false;
        }
        
        public void Hide()
        {
            // enable the parent form
            parentForm.Enabled = true;
            // hide the wait form
            base.Hide();
        }
    }
}