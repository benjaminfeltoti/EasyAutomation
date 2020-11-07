using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace ExampleWinformsApplication
{
    internal class ValidatorTextBox : TextBox
    {
        internal string AccessibilityHelp;
        internal bool IsValid = true;

        public ValidatorTextBox() : base()
        {
            LostFocus += OnLostFocus;
        }

        protected override AccessibleObject CreateAccessibilityInstance()
        {
            var accessibleObject = new ValidatorTextBoxAccessibleObject(this);
            
            return accessibleObject;
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            Text = Text.Trim();

            if (!IsEmailValid(Text))
            {
                BackColor = Color.PaleVioletRed;
                AccessibilityHelp = "Value is not valid";
                IsValid = false;
            }
            else
            {
                BackColor = Color.White;
                AccessibilityHelp = "Value is valid";
                IsValid = true;
            }
        }

        private bool IsEmailValid(string text)
        {
            Regex emailValidatorExpression = new Regex(
                @"[a-zA-Z]*[a-zA-Z0-9]@[a-zA-Z0-9]*[a-zA-Z0-9]\.[a-zA-Z]*[a-zA-Z]$");

            return emailValidatorExpression.IsMatch(text.Trim());
        }
    }

    internal class ValidatorTextBoxAccessibleObject : ControlAccessibleObject
    {
        private ValidatorTextBox m_ValidatorTextBox;

        public ValidatorTextBoxAccessibleObject(Control ownerControl) : base(ownerControl)
        {
            m_ValidatorTextBox = ownerControl as ValidatorTextBox;
        }

        public override string Help
        {
            get => m_ValidatorTextBox.AccessibilityHelp;
        }
    }    
}
