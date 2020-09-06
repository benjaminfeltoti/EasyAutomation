using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleWinformsApplication
{
    public partial class ExamleApplication : Form
    {
        public ExamleApplication()
        {
            InitializeComponent();
        }

        private void ExamleApplication_Load(object sender, EventArgs e)
        {

        }

        private void OnLostFocusOnTextBoxes(object sender, EventArgs e)
        {
            SubmitButton.Enabled = !string.IsNullOrEmpty(FirstNameTextBox.Text) &&
                !string.IsNullOrEmpty(LastNameTextBox.Text) && EMailAdressTextBox.IsValid;
        }

        private void OnMouseHoverOnSubmitButton(object sender, EventArgs e)
        {
            if (SubmitButton.Enabled)
            {
                SubmitButtonTooltip.Show("Submit", SubmitButton);
            }
        }

        private void OnEnabledChangedSubmitButton(object sender, EventArgs e)
        {
            WarningLabel.Visible = !SubmitButton.Enabled;
            WarningPicture.Visible = !SubmitButton.Enabled;
        }
    }
}
