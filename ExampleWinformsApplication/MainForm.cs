using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ExampleWinformsApplication
{
    public partial class ExamleApplication : Form
    {
        private List<string> databaseListBoxItems = new List<string>();

        private int indexOfSelection = -1;

        public ExamleApplication()
        {
            InitializeComponent();

            ViewSelectionComboBox.SelectedIndex = 0;
            LanguageComboBox.SelectedIndex = 0;
            DataBaseFile.Path = "database.txt";
            EditLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void OnLostFocusOnTextBoxes(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(ValidatorTextBox))
            {
                var senderTextBox = sender as TextBox;
                senderTextBox.BackColor = string.IsNullOrEmpty(senderTextBox.Text) ? Color.PaleVioletRed : Color.White;
            }            

            SubmitButton.Enabled = !string.IsNullOrEmpty(FirstNameTextBox.Text) &&
                !string.IsNullOrEmpty(LastNameTextBox.Text) && EMailAdressTextBox.IsValid;

            EditSubmitButton.Enabled = !string.IsNullOrEmpty(EditFirstNameTextBox.Text) &&
                !string.IsNullOrEmpty(EditLastNameTextBox.Text) && EditEMailAdressTextBox.IsValid;
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
                SubmitButton.Enabled = false;
            }
        }

        

        private void UploadToDatabase()
        {
            using (StreamWriter streamWriter = new StreamWriter(DataBaseFile.Path, true))
            {
                streamWriter.Write($"\n{ FirstNameTextBox.Text } { LastNameTextBox.Text } { (MaleRadioButton.Checked ? "Male" : "Female") } { EMailAdressTextBox.Text } { LanguageComboBox.SelectedItem } { SubscribeNewsletterCheckBox.Checked }");
            }
        }

        private void RefreshDataBase()
        {
            DataBaseListBox.Items.Clear();
            databaseListBoxItems = new List<string>();

            if (File.Exists(DataBaseFile.Path))
            {
                using (StreamReader streamReader = new StreamReader(DataBaseFile.Path, true))
                {
                    while (!streamReader.EndOfStream)
                    {
                        databaseListBoxItems.Add(streamReader.ReadLine());
                    }
                }
            }

            DataBaseListBox.Items.AddRange(databaseListBoxItems.ToArray());
            SetEditFormToDefault();
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
            Thread.Sleep(r.Next(4000, 6000));

            waitDialog.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ShowWaitDialog("Downloading data...");
            RefreshDataBase();
        }

        private void ViewSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var senderComboBox = sender as ComboBox;

            if (senderComboBox.SelectedItem == "Registration form")
            {
                RegistrationForm.Visible = true;
                EditForm.Visible = false;
            }
            else if(senderComboBox.SelectedItem == "Edit form")
            {
                RegistrationForm.Visible = false;
                EditForm.Visible = true;
            }
        }

        private void DataBaseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = DataBaseListBox.SelectedItem.ToString();

            indexOfSelection = DataBaseListBox.Items.IndexOf(selectedItem);
            EditForm.Enabled = true;
            var data = selectedItem.Split(' ');

            EditFormLoadData(data);
        }

        #region Edit Groupbox

        private void SetEditFormToDefault()
        {
            EditFirstNameTextBox.Text = "";
            EditLastNameTextBox.Text = "";
            EditMaleRadioButton.Select();
            EditEMailAdressTextBox.Text = "";
            EditLanguageComboBox.SelectedItem = "Hungarian";
            EditSubscribeNewsletterCheckBox.Checked = true;
            EditSubmitButton.Enabled = false;
            EditForm.Enabled = false;
        }

        private void EditFormLoadData(string[] data)
        {
            EditFirstNameTextBox.Text = data[0];
            EditLastNameTextBox.Text = data[1];
            
            if (data[2] == "Male")
            {
                EditMaleRadioButton.Select();
            }
            else
            {
                EditFemaleRadioButton.Select();
            }

            EditEMailAdressTextBox.Text = data[3];
            EditLanguageComboBox.SelectedItem = data[4];
            EditSubscribeNewsletterCheckBox.Checked = bool.Parse(data[5]);
            EditSubmitButton.Enabled = true;            
        }

        private void EditSubmitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Is your data correct? " +
                $"\n Name : { EditFirstNameTextBox.Text } { EditLastNameTextBox.Text } " +
                $"\n E-mail adress : { EditEMailAdressTextBox.Text }", "Submit", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ShowWaitDialog("Editing data...");
                EditDatabase();
                SetEditFormToDefault();
                MessageBox.Show("Editing was successfull!");
            }
        }

        private void EditDatabase()
        {
            string[] lines = File.ReadAllLines(DataBaseFile.Path);

            lines[indexOfSelection] = ReadDataFromEditForm();

            using (StreamWriter streamWriter = new StreamWriter(DataBaseFile.Path, false))
            {
                foreach (var line in lines)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }

        private string ReadDataFromEditForm()
        {
            return $"{ EditFirstNameTextBox.Text } { EditLastNameTextBox.Text } { (EditMaleRadioButton.Checked ? "Male" : "Female") } { EditEMailAdressTextBox.Text } { EditLanguageComboBox.SelectedItem } { SubscribeNewsletterCheckBox.Checked }";
        }

        #endregion

    }
}
