using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ExampleWinformsApplication
{
    public partial class ExamleApplication : Form
    {
        private List<string> databaseListBoxItems = new List<string>();

        public ExamleApplication()
        {
            InitializeComponent();
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
                $"\n E-mail adress : { EMailAdressTextBox.Text }", "Submit", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ShowWaitDialog("Uploading data...");
                UploadToDatabase();
                ResetTextboxTexts();
                MessageBox.Show("Upload was successfull!");
            }
        }

        private void UploadToDatabase()
        {
            using (StreamWriter streamWriter = new StreamWriter("database.txt", true))
            {
                streamWriter.Write($"\n{ FirstNameTextBox.Text } { LastNameTextBox.Text } { EMailAdressTextBox.Text }");
            }
        }

        private void RefreshDataBase()
        {
            DataBaseListBox.Items.Clear();
            databaseListBoxItems = new List<string>();

            if (File.Exists("database.txt"))
            {
                using (StreamReader streamReader = new StreamReader("database.txt", true))
                {
                    while (!streamReader.EndOfStream)
                    {
                        databaseListBoxItems.Add(streamReader.ReadLine());
                    }
                }
            }

            databaseListBoxItems.ForEach(data => DataBaseListBox.Items.Add(data));
        }

        private void ResetTextboxTexts()
        {
            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            EMailAdressTextBox.Text = string.Empty;
        }

        private void OnKeyUpFocusNextControl(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void ShowWaitDialog(string message)
        {
            var waitDialog = new WaitDialog(message);
            waitDialog.TopMost = true;
            waitDialog.StartPosition = FormStartPosition.CenterScreen;
            waitDialog.Show();
            waitDialog.Refresh();

            Random r = new Random();
            Thread.Sleep(r.Next(10000, 15000));

            waitDialog.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ShowWaitDialog("Downloading data...");
            RefreshDataBase();
        }
    }
}
