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
        private List<string> databaseObjects = new List<string> {
            "Sörös József sorosjozsef@gmail.hu",
            "Emília Edina emiliaedina@freemail.hu",
            "Kódor Tibor kodorti88@citromail.hu"};

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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Is your data correct? " +
                $"\n Name : { FirstNameTextBox.Text } { LastNameTextBox.Text } " +
                $"\n E-mail adress : { EMailAdressTextBox.Text }" , "Submit", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ShowWaitDialog("Uploading data...");
                ResetTextboxTexts();
                UploadToDatabase();
            }
        }

        private void UploadToDatabase()
        {
            RefreshDataBase();
            databaseObjects.Add($"{ FirstNameTextBox.Text } { LastNameTextBox.Text } { EMailAdressTextBox.Text }");
        }

        private void RefreshDataBase()
        {
            DataBaseListBox.Items.Clear();
            databaseObjects.ForEach(data => DataBaseListBox.Items.Add(data));
        }

        private void ResetTextboxTexts()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            EMailAdressTextBox.Text = "";
        }

        private void ShowWaitDialog(string message)
        {
            var waitDialog = new WaitDialog(message);
            waitDialog.TopMost = true;
            waitDialog.StartPosition = FormStartPosition.CenterScreen;
            waitDialog.Show();
            waitDialog.Refresh();

            System.Threading.Thread.Sleep(2000);
            waitDialog.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ShowWaitDialog("Downloading data...");
            RefreshDataBase();
        }
    }
}
