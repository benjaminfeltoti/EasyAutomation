namespace ExampleWinformsApplication
{
    partial class ExamleApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RegistrationForm = new System.Windows.Forms.GroupBox();
            this.WarningPicture = new System.Windows.Forms.PictureBox();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.EMailAddressLabel = new System.Windows.Forms.Label();
            this.RadiobuttonsPanel = new System.Windows.Forms.Panel();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.SubscribeNewsletterCheckBox = new System.Windows.Forms.CheckBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.DataBaseListBox = new System.Windows.Forms.ListBox();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.Database = new System.Windows.Forms.GroupBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SubmitButtonTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.EMailAdressTextBox = new ExampleWinformsApplication.ValidatorTextBox();
            this.RegistrationForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarningPicture)).BeginInit();
            this.RadiobuttonsPanel.SuspendLayout();
            this.Database.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegistrationForm
            // 
            this.RegistrationForm.AccessibleName = "RegistrationForm";
            this.RegistrationForm.Controls.Add(this.WarningPicture);
            this.RegistrationForm.Controls.Add(this.WarningLabel);
            this.RegistrationForm.Controls.Add(this.EMailAdressTextBox);
            this.RegistrationForm.Controls.Add(this.EMailAddressLabel);
            this.RegistrationForm.Controls.Add(this.RadiobuttonsPanel);
            this.RegistrationForm.Controls.Add(this.GenderLabel);
            this.RegistrationForm.Controls.Add(this.LastNameLabel);
            this.RegistrationForm.Controls.Add(this.LastNameTextBox);
            this.RegistrationForm.Controls.Add(this.FirstNameTextBox);
            this.RegistrationForm.Controls.Add(this.FirstNameLabel);
            this.RegistrationForm.Controls.Add(this.SubscribeNewsletterCheckBox);
            this.RegistrationForm.Controls.Add(this.SubmitButton);
            this.RegistrationForm.Location = new System.Drawing.Point(23, 25);
            this.RegistrationForm.Name = "RegistrationForm";
            this.RegistrationForm.Size = new System.Drawing.Size(275, 402);
            this.RegistrationForm.TabIndex = 0;
            this.RegistrationForm.TabStop = false;
            this.RegistrationForm.Text = "Registration Form";
            // 
            // WarningPicture
            // 
            this.WarningPicture.AccessibleName = "WarningPicture";
            this.WarningPicture.Location = new System.Drawing.Point(10, 326);
            this.WarningPicture.Name = "WarningPicture";
            this.WarningPicture.Size = new System.Drawing.Size(24, 26);
            this.WarningPicture.TabIndex = 13;
            this.WarningPicture.TabStop = false;
            this.WarningPicture.Visible = false;
            // 
            // WarningLabel
            // 
            this.WarningLabel.AccessibleName = "WarningLabel";
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.Location = new System.Drawing.Point(33, 333);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(156, 13);
            this.WarningLabel.TabIndex = 12;
            this.WarningLabel.Text = "Please fill out the form correctly!";
            this.WarningLabel.Visible = false;
            // 
            // EMailAddressLabel
            // 
            this.EMailAddressLabel.AccessibleName = "EMailAddressLabel";
            this.EMailAddressLabel.AutoSize = true;
            this.EMailAddressLabel.Location = new System.Drawing.Point(8, 143);
            this.EMailAddressLabel.Name = "EMailAddressLabel";
            this.EMailAddressLabel.Size = new System.Drawing.Size(81, 13);
            this.EMailAddressLabel.TabIndex = 10;
            this.EMailAddressLabel.Text = "E-mail address :";
            // 
            // RadiobuttonsPanel
            // 
            this.RadiobuttonsPanel.Controls.Add(this.MaleRadioButton);
            this.RadiobuttonsPanel.Controls.Add(this.FemaleRadioButton);
            this.RadiobuttonsPanel.Location = new System.Drawing.Point(78, 85);
            this.RadiobuttonsPanel.Name = "RadiobuttonsPanel";
            this.RadiobuttonsPanel.Size = new System.Drawing.Size(163, 49);
            this.RadiobuttonsPanel.TabIndex = 9;
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AccessibleName = "MaleRadioButton";
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Checked = true;
            this.MaleRadioButton.Location = new System.Drawing.Point(3, 0);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(48, 17);
            this.MaleRadioButton.TabIndex = 3;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AccessibleName = "FemaleRadioButton";
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Location = new System.Drawing.Point(3, 23);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(59, 17);
            this.FemaleRadioButton.TabIndex = 4;
            this.FemaleRadioButton.Text = "Female";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // GenderLabel
            // 
            this.GenderLabel.AccessibleName = "GenderLabel";
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(7, 85);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(48, 13);
            this.GenderLabel.TabIndex = 8;
            this.GenderLabel.Text = "Gender :";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AccessibleName = "LastNameLabel";
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(7, 56);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(64, 13);
            this.LastNameLabel.TabIndex = 7;
            this.LastNameLabel.Text = "Last Name :";
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.AccessibleName = "LastNameTextBox";
            this.LastNameTextBox.Location = new System.Drawing.Point(78, 53);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.LastNameTextBox.TabIndex = 6;
            this.LastNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpFocusNextControl);
            this.LastNameTextBox.LostFocus += new System.EventHandler(this.OnLostFocusOnTextBoxes);
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.AccessibleName = "FirstNameTextBox";
            this.FirstNameTextBox.Location = new System.Drawing.Point(78, 27);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.FirstNameTextBox.TabIndex = 5;
            this.FirstNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpFocusNextControl);
            this.FirstNameTextBox.LostFocus += new System.EventHandler(this.OnLostFocusOnTextBoxes);
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AccessibleName = "FirstNameLabel";
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(7, 30);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(63, 13);
            this.FirstNameLabel.TabIndex = 2;
            this.FirstNameLabel.Text = "First Name :";
            // 
            // SubscribeNewsletterCheckBox
            // 
            this.SubscribeNewsletterCheckBox.AccessibleName = "SubscribeNewsletterCheckBox";
            this.SubscribeNewsletterCheckBox.AutoSize = true;
            this.SubscribeNewsletterCheckBox.Checked = true;
            this.SubscribeNewsletterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SubscribeNewsletterCheckBox.Location = new System.Drawing.Point(10, 187);
            this.SubscribeNewsletterCheckBox.Name = "SubscribeNewsletterCheckBox";
            this.SubscribeNewsletterCheckBox.Size = new System.Drawing.Size(124, 17);
            this.SubscribeNewsletterCheckBox.TabIndex = 1;
            this.SubscribeNewsletterCheckBox.Text = "Subscribe newsletter";
            this.SubscribeNewsletterCheckBox.UseVisualStyleBackColor = true;
            // 
            // SubmitButton
            // 
            this.SubmitButton.AccessibleName = "SubmitButton";
            this.SubmitButton.Enabled = false;
            this.SubmitButton.Location = new System.Drawing.Point(6, 358);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(263, 38);
            this.SubmitButton.TabIndex = 0;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.EnabledChanged += new System.EventHandler(this.OnEnabledChangedSubmitButton);
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            this.SubmitButton.MouseHover += new System.EventHandler(this.OnMouseHoverOnSubmitButton);
            // 
            // DataBaseListBox
            // 
            this.DataBaseListBox.AccessibleName = "DataBaseListBox";
            this.DataBaseListBox.FormattingEnabled = true;
            this.DataBaseListBox.Location = new System.Drawing.Point(6, 15);
            this.DataBaseListBox.Name = "DataBaseListBox";
            this.DataBaseListBox.Size = new System.Drawing.Size(263, 147);
            this.DataBaseListBox.TabIndex = 1;
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.AccessibleName = "LanguageComboBox";
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "English",
            "Hungarian"});
            this.LanguageComboBox.Location = new System.Drawing.Point(679, 1);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(121, 21);
            this.LanguageComboBox.TabIndex = 2;
            // 
            // Database
            // 
            this.Database.Controls.Add(this.RefreshButton);
            this.Database.Controls.Add(this.DataBaseListBox);
            this.Database.Location = new System.Drawing.Point(318, 27);
            this.Database.Name = "Database";
            this.Database.Size = new System.Drawing.Size(275, 215);
            this.Database.TabIndex = 3;
            this.Database.TabStop = false;
            this.Database.Text = "Database";
            // 
            // RefreshButton
            // 
            this.RefreshButton.AccessibleName = "RefreshButton";
            this.RefreshButton.Location = new System.Drawing.Point(6, 167);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(263, 38);
            this.RefreshButton.TabIndex = 12;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // EMailAdressTextBox
            // 
            this.EMailAdressTextBox.AccessibleName = "EMailAdressTextBox";
            this.EMailAdressTextBox.Location = new System.Drawing.Point(95, 140);
            this.EMailAdressTextBox.Name = "EMailAdressTextBox";
            this.EMailAdressTextBox.Size = new System.Drawing.Size(146, 20);
            this.EMailAdressTextBox.TabIndex = 11;
            this.EMailAdressTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUpFocusNextControl);
            this.EMailAdressTextBox.LostFocus += new System.EventHandler(this.OnLostFocusOnTextBoxes);
            // 
            // ExamleApplication
            // 
            this.AccessibleName = "ExamleApplication";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Database);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.RegistrationForm);
            this.Name = "ExamleApplication";
            this.Text = "ExamleApplication";
            this.RegistrationForm.ResumeLayout(false);
            this.RegistrationForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarningPicture)).EndInit();
            this.RadiobuttonsPanel.ResumeLayout(false);
            this.RadiobuttonsPanel.PerformLayout();
            this.Database.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RegistrationForm;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.CheckBox SubscribeNewsletterCheckBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.ListBox DataBaseListBox;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Panel RadiobuttonsPanel;
        private System.Windows.Forms.Label EMailAddressLabel;
        private ValidatorTextBox EMailAdressTextBox;
        private System.Windows.Forms.GroupBox Database;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ToolTip SubmitButtonTooltip;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.PictureBox WarningPicture;
    }
}

