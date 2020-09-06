using System.Windows.Forms;

namespace ExampleWinformsApplication
{
    public partial class WaitDialog : Form
    {
        public WaitDialog(string message)
        {
            InitializeComponent();
            label1.Text = label1.Text + message;
        }
    }
}
