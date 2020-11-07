using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAutomation.ExampleTests.ExampleWinformsApp.Views
{
    public class RegistrationFormView
    {
        private ControlElement m_Root;

        public RegistrationFormView(ControlElement exampleAppWindowElement)
        {
            m_Root = exampleAppWindowElement;
        }

        public ControlElement RootWindow => m_Root ?? (m_Root = Desktop.Root.FindChildByAutomationId("ExamleApplication"));

        #region RegistrationForm

        public Button SubmitButton(uint timeout = 5000) => RootWindow.FindDescendantByName("SubmitButton", timeout).AsButton();

        public TextBox FirstNameTextBox(uint timeout = 5000) => RootWindow.FindDescendantByName("FirstNameTextBox", timeout).AsTextBox();

        public TextBox LastNameTextBox(uint timeout = 5000) => RootWindow.FindDescendantByName("LastNameTextBox", timeout).AsTextBox();

        public TextBox EmailTextBox(uint timeout = 5000) => RootWindow.FindDescendantByName("EMailAdressTextBox", timeout).AsTextBox();

        public RadioButton MaleRadioButton(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("MaleRadioButton", timeout).AsRadioButton();

        public RadioButton FemaleRadioButton(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("FemaleRadioButton", timeout).AsRadioButton();

        public ComboBox LanguageComboBox(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("LanguageComboBox", timeout).AsComboBox();

        public CheckBox NewsLetterCheckBox(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("SubscribeNewsletterCheckBox", timeout).AsCheckBox();

        public CustomLabelWithPattern CustomLabel(uint timeout = 5000) => RootWindow.FindDescendantByName("LastNameLabel", timeout).AsCustomLabelWithPattern();

        #endregion
    }
}
