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
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.WarningPicture = new System.Windows.Forms.PictureBox();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.EMailAdressTextBox = new ExampleWinformsApplication.ValidatorTextBox();
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
            this.Database = new System.Windows.Forms.GroupBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SubmitButtonTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ViewSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.EditForm = new System.Windows.Forms.GroupBox();
            this.EditLanguageLabel = new System.Windows.Forms.Label();
            this.EditLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.EditWarningPicture = new System.Windows.Forms.PictureBox();
            this.EditWarningLabel = new System.Windows.Forms.Label();
            this.EditEMailAdressTextBox = new ExampleWinformsApplication.ValidatorTextBox();
            this.EditEMailAddressLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EditMaleRadioButton = new System.Windows.Forms.RadioButton();
            this.EditFemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.EditGenderLabel = new System.Windows.Forms.Label();
            this.EditLastNameLabel = new System.Windows.Forms.Label();
            this.EditLastNameTextBox = new System.Windows.Forms.TextBox();
            this.EditFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.EditFirstNameLabel = new System.Windows.Forms.Label();
            this.EditSubscribeNewsletterCheckBox = new System.Windows.Forms.CheckBox();
            this.EditSubmitButton = new System.Windows.Forms.Button();
            this.RegistrationForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarningPicture)).BeginInit();
            this.RadiobuttonsPanel.SuspendLayout();
            this.Database.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.EditForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditWarningPicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegistrationForm
            // 
            this.RegistrationForm.AccessibleName = "RegistrationForm";
            this.RegistrationForm.Controls.Add(this.LanguageLabel);
            this.RegistrationForm.Controls.Add(this.LanguageComboBox);
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
            this.RegistrationForm.Location = new System.Drawing.Point(6, 16);
            this.RegistrationForm.Name = "RegistrationForm";
            this.RegistrationForm.Size = new System.Drawing.Size(275, 402);
            this.RegistrationForm.TabIndex = 0;
            this.RegistrationForm.TabStop = false;
            this.RegistrationForm.Text = "Registration Form";
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AccessibleName = "LanguageLabel";
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(8, 172);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(61, 13);
            this.LanguageLabel.TabIndex = 14;
            this.LanguageLabel.Text = "Language :";
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.AccessibleName = "LanguageComboBox";
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "Hungarian",
            "English",
            "German"});
            this.LanguageComboBox.Location = new System.Drawing.Point(95, 169);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(146, 21);
            this.LanguageComboBox.TabIndex = 11;
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
            this.SubscribeNewsletterCheckBox.Location = new System.Drawing.Point(11, 200);
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
            this.DataBaseListBox.Size = new System.Drawing.Size(263, 277);
            this.DataBaseListBox.TabIndex = 1;
            this.DataBaseListBox.SelectedIndexChanged += new System.EventHandler(this.DataBaseListBox_SelectedIndexChanged);
            // 
            // Database
            // 
            this.Database.Controls.Add(this.RefreshButton);
            this.Database.Controls.Add(this.DataBaseListBox);
            this.Database.Location = new System.Drawing.Point(287, 69);
            this.Database.Name = "Database";
            this.Database.Size = new System.Drawing.Size(275, 351);
            this.Database.TabIndex = 3;
            this.Database.TabStop = false;
            this.Database.Text = "Database";
            // 
            // RefreshButton
            // 
            this.RefreshButton.AccessibleName = "RefreshButton";
            this.RefreshButton.Location = new System.Drawing.Point(6, 305);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(263, 38);
            this.RefreshButton.TabIndex = 12;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ViewSelectionComboBox);
            this.groupBox1.Controls.Add(this.EditForm);
            this.groupBox1.Controls.Add(this.RegistrationForm);
            this.groupBox1.Controls.Add(this.Database);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(883, 426);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // ViewSelectionComboBox
            // 
            this.ViewSelectionComboBox.AccessibleName = "ViewSelectionComboBox";
            this.ViewSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ViewSelectionComboBox.Items.AddRange(new object[] {
            "Registration form",
            "Edit form"});
            this.ViewSelectionComboBox.Location = new System.Drawing.Point(287, 19);
            this.ViewSelectionComboBox.Name = "ViewSelectionComboBox";
            this.ViewSelectionComboBox.Size = new System.Drawing.Size(275, 21);
            this.ViewSelectionComboBox.TabIndex = 16;
            this.ViewSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.ViewSelectionComboBox_SelectedIndexChanged);
            // 
            // EditForm
            // 
            this.EditForm.AccessibleName = "EditForm";
            this.EditForm.Controls.Add(this.EditLanguageLabel);
            this.EditForm.Controls.Add(this.EditLanguageComboBox);
            this.EditForm.Controls.Add(this.EditWarningPicture);
            this.EditForm.Controls.Add(this.EditWarningLabel);
            this.EditForm.Controls.Add(this.EditEMailAdressTextBox);
            this.EditForm.Controls.Add(this.EditEMailAddressLabel);
            this.EditForm.Controls.Add(this.panel1);
            this.EditForm.Controls.Add(this.EditGenderLabel);
            this.EditForm.Controls.Add(this.EditLastNameLabel);
            this.EditForm.Controls.Add(this.EditLastNameTextBox);
            this.EditForm.Controls.Add(this.EditFirstNameTextBox);
            this.EditForm.Controls.Add(this.EditFirstNameLabel);
            this.EditForm.Controls.Add(this.EditSubscribeNewsletterCheckBox);
            this.EditForm.Controls.Add(this.EditSubmitButton);
            this.EditForm.Enabled = false;
            this.EditForm.Location = new System.Drawing.Point(568, 16);
            this.EditForm.Name = "EditForm";
            this.EditForm.Size = new System.Drawing.Size(275, 402);
            this.EditForm.TabIndex = 15;
            this.EditForm.TabStop = false;
            this.EditForm.Text = "Edit Form";
            this.EditForm.Visible = false;
            // 
            // EditLanguageLabel
            // 
            this.EditLanguageLabel.AccessibleName = "LanguageLabel";
            this.EditLanguageLabel.AutoSize = true;
            this.EditLanguageLabel.Location = new System.Drawing.Point(8, 172);
            this.EditLanguageLabel.Name = "EditLanguageLabel";
            this.EditLanguageLabel.Size = new System.Drawing.Size(61, 13);
            this.EditLanguageLabel.TabIndex = 14;
            this.EditLanguageLabel.Text = "Language :";
            // 
            // EditLanguageComboBox
            // 
            this.EditLanguageComboBox.AccessibleName = "EditLanguageComboBox";
            this.EditLanguageComboBox.FormattingEnabled = true;
            this.EditLanguageComboBox.Items.AddRange(new object[] {
            "Hungarian",
            "English",
            "German"});
            this.EditLanguageComboBox.Location = new System.Drawing.Point(95, 169);
            this.EditLanguageComboBox.Name = "EditLanguageComboBox";
            this.EditLanguageComboBox.Size = new System.Drawing.Size(146, 21);
            this.EditLanguageComboBox.TabIndex = 11;
            this.EditLanguageComboBox.Text = "Select Any";
            // 
            // EditWarningPicture
            // 
            this.EditWarningPicture.AccessibleName = "EditWarningPicture";
            this.EditWarningPicture.Location = new System.Drawing.Point(10, 326);
            this.EditWarningPicture.Name = "EditWarningPicture";
            this.EditWarningPicture.Size = new System.Drawing.Size(24, 26);
            this.EditWarningPicture.TabIndex = 13;
            this.EditWarningPicture.TabStop = false;
            this.EditWarningPicture.Visible = false;
            // 
            // EditWarningLabel
            // 
            this.EditWarningLabel.AccessibleName = "EditWarningLabel";
            this.EditWarningLabel.AutoSize = true;
            this.EditWarningLabel.Location = new System.Drawing.Point(33, 333);
            this.EditWarningLabel.Name = "EditWarningLabel";
            this.EditWarningLabel.Size = new System.Drawing.Size(156, 13);
            this.EditWarningLabel.TabIndex = 12;
            this.EditWarningLabel.Text = "Please fill out the form correctly!";
            this.EditWarningLabel.Visible = false;
            // 
            // EditEMailAdressTextBox
            // 
            this.EditEMailAdressTextBox.AccessibleName = "EditEMailAdressTextBox";
            this.EditEMailAdressTextBox.Location = new System.Drawing.Point(95, 140);
            this.EditEMailAdressTextBox.Name = "EditEMailAdressTextBox";
            this.EditEMailAdressTextBox.Size = new System.Drawing.Size(146, 20);
            this.EditEMailAdressTextBox.TabIndex = 11;
            this.EditEMailAdressTextBox.LostFocus += new System.EventHandler(this.OnLostFocusOnTextBoxes);
            // 
            // EditEMailAddressLabel
            // 
            this.EditEMailAddressLabel.AccessibleName = "EditEMailAddressLabel";
            this.EditEMailAddressLabel.AutoSize = true;
            this.EditEMailAddressLabel.Location = new System.Drawing.Point(8, 143);
            this.EditEMailAddressLabel.Name = "EditEMailAddressLabel";
            this.EditEMailAddressLabel.Size = new System.Drawing.Size(81, 13);
            this.EditEMailAddressLabel.TabIndex = 10;
            this.EditEMailAddressLabel.Text = "E-mail address :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.EditMaleRadioButton);
            this.panel1.Controls.Add(this.EditFemaleRadioButton);
            this.panel1.Location = new System.Drawing.Point(78, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 49);
            this.panel1.TabIndex = 9;
            // 
            // EditMaleRadioButton
            // 
            this.EditMaleRadioButton.AccessibleName = "MaleRadioButton";
            this.EditMaleRadioButton.AutoSize = true;
            this.EditMaleRadioButton.Checked = true;
            this.EditMaleRadioButton.Location = new System.Drawing.Point(3, 0);
            this.EditMaleRadioButton.Name = "EditMaleRadioButton";
            this.EditMaleRadioButton.Size = new System.Drawing.Size(48, 17);
            this.EditMaleRadioButton.TabIndex = 3;
            this.EditMaleRadioButton.TabStop = true;
            this.EditMaleRadioButton.Text = "Male";
            this.EditMaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // EditFemaleRadioButton
            // 
            this.EditFemaleRadioButton.AccessibleName = "FemaleRadioButton";
            this.EditFemaleRadioButton.AutoSize = true;
            this.EditFemaleRadioButton.Location = new System.Drawing.Point(3, 23);
            this.EditFemaleRadioButton.Name = "EditFemaleRadioButton";
            this.EditFemaleRadioButton.Size = new System.Drawing.Size(59, 17);
            this.EditFemaleRadioButton.TabIndex = 4;
            this.EditFemaleRadioButton.Text = "Female";
            this.EditFemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // EditGenderLabel
            // 
            this.EditGenderLabel.AccessibleName = "EditGenderLabel";
            this.EditGenderLabel.AutoSize = true;
            this.EditGenderLabel.Location = new System.Drawing.Point(7, 85);
            this.EditGenderLabel.Name = "EditGenderLabel";
            this.EditGenderLabel.Size = new System.Drawing.Size(48, 13);
            this.EditGenderLabel.TabIndex = 8;
            this.EditGenderLabel.Text = "Gender :";
            // 
            // EditLastNameLabel
            // 
            this.EditLastNameLabel.AccessibleName = "EditLastNameLabel";
            this.EditLastNameLabel.AutoSize = true;
            this.EditLastNameLabel.Location = new System.Drawing.Point(7, 56);
            this.EditLastNameLabel.Name = "EditLastNameLabel";
            this.EditLastNameLabel.Size = new System.Drawing.Size(64, 13);
            this.EditLastNameLabel.TabIndex = 7;
            this.EditLastNameLabel.Text = "Last Name :";
            // 
            // EditLastNameTextBox
            // 
            this.EditLastNameTextBox.AccessibleName = "EditLastNameTextBox";
            this.EditLastNameTextBox.Location = new System.Drawing.Point(78, 53);
            this.EditLastNameTextBox.Name = "EditLastNameTextBox";
            this.EditLastNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.EditLastNameTextBox.TabIndex = 6;
            this.EditLastNameTextBox.LostFocus += new System.EventHandler(this.OnLostFocusOnTextBoxes);
            // 
            // EditFirstNameTextBox
            // 
            this.EditFirstNameTextBox.AccessibleName = "EditFirstNameTextBox";
            this.EditFirstNameTextBox.Location = new System.Drawing.Point(78, 27);
            this.EditFirstNameTextBox.Name = "EditFirstNameTextBox";
            this.EditFirstNameTextBox.Size = new System.Drawing.Size(163, 20);
            this.EditFirstNameTextBox.TabIndex = 5;
            this.EditFirstNameTextBox.LostFocus += new System.EventHandler(this.OnLostFocusOnTextBoxes);
            // 
            // EditFirstNameLabel
            // 
            this.EditFirstNameLabel.AccessibleName = "EditFirstNameLabel";
            this.EditFirstNameLabel.AutoSize = true;
            this.EditFirstNameLabel.Location = new System.Drawing.Point(7, 30);
            this.EditFirstNameLabel.Name = "EditFirstNameLabel";
            this.EditFirstNameLabel.Size = new System.Drawing.Size(63, 13);
            this.EditFirstNameLabel.TabIndex = 2;
            this.EditFirstNameLabel.Text = "First Name :";
            // 
            // EditSubscribeNewsletterCheckBox
            // 
            this.EditSubscribeNewsletterCheckBox.AccessibleName = "EditSubscribeNewsletterCheckBox";
            this.EditSubscribeNewsletterCheckBox.AutoSize = true;
            this.EditSubscribeNewsletterCheckBox.Checked = true;
            this.EditSubscribeNewsletterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EditSubscribeNewsletterCheckBox.Location = new System.Drawing.Point(11, 200);
            this.EditSubscribeNewsletterCheckBox.Name = "EditSubscribeNewsletterCheckBox";
            this.EditSubscribeNewsletterCheckBox.Size = new System.Drawing.Size(124, 17);
            this.EditSubscribeNewsletterCheckBox.TabIndex = 1;
            this.EditSubscribeNewsletterCheckBox.Text = "Subscribe newsletter";
            this.EditSubscribeNewsletterCheckBox.UseVisualStyleBackColor = true;
            // 
            // EditSubmitButton
            // 
            this.EditSubmitButton.AccessibleName = "EditSubmitButton";
            this.EditSubmitButton.Enabled = false;
            this.EditSubmitButton.Location = new System.Drawing.Point(6, 358);
            this.EditSubmitButton.Name = "EditSubmitButton";
            this.EditSubmitButton.Size = new System.Drawing.Size(263, 38);
            this.EditSubmitButton.TabIndex = 0;
            this.EditSubmitButton.Text = "Edit";
            this.EditSubmitButton.UseVisualStyleBackColor = true;
            this.EditSubmitButton.Click += new System.EventHandler(this.EditSubmitButton_Click);
            // 
            // ExamleApplication
            // 
            this.AccessibleName = "ExamleApplication";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 452);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExamleApplication";
            this.Text = "ExamleApplication";
            this.RegistrationForm.ResumeLayout(false);
            this.RegistrationForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarningPicture)).EndInit();
            this.RadiobuttonsPanel.ResumeLayout(false);
            this.RadiobuttonsPanel.PerformLayout();
            this.Database.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.EditForm.ResumeLayout(false);
            this.EditForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditWarningPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel RadiobuttonsPanel;
        private System.Windows.Forms.Label EMailAddressLabel;
        private ValidatorTextBox EMailAdressTextBox;
        private System.Windows.Forms.GroupBox Database;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ToolTip SubmitButtonTooltip;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.PictureBox WarningPicture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.GroupBox EditForm;
        private System.Windows.Forms.Label EditLanguageLabel;
        private System.Windows.Forms.ComboBox EditLanguageComboBox;
        private System.Windows.Forms.PictureBox EditWarningPicture;
        private System.Windows.Forms.Label EditWarningLabel;
        private ValidatorTextBox EditEMailAdressTextBox;
        private System.Windows.Forms.Label EditEMailAddressLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton EditMaleRadioButton;
        private System.Windows.Forms.RadioButton EditFemaleRadioButton;
        private System.Windows.Forms.Label EditGenderLabel;
        private System.Windows.Forms.Label EditLastNameLabel;
        private System.Windows.Forms.TextBox EditLastNameTextBox;
        private System.Windows.Forms.TextBox EditFirstNameTextBox;
        private System.Windows.Forms.Label EditFirstNameLabel;
        private System.Windows.Forms.CheckBox EditSubscribeNewsletterCheckBox;
        private System.Windows.Forms.Button EditSubmitButton;
        private System.Windows.Forms.ComboBox ViewSelectionComboBox;
    }
}

