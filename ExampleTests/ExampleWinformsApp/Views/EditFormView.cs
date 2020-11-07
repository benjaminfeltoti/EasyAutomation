using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Core.Controls;

namespace EasyAutomation.ExampleTests.ExampleWinformsApp.Views
{
    public class EditFormView
    {
        private ControlElement m_Root;

        public EditFormView(ControlElement exampleAppWindowElement)
        {
            m_Root = exampleAppWindowElement;
        }

        public ControlElement RootWindow => m_Root ?? (m_Root = Desktop.Root.FindChildByAutomationId("ExamleApplication"));

        #region EditForm

        public Button EditButton(uint timeout = 5000) => RootWindow.FindDescendantByName("EditSubmitButton", timeout).AsButton();

        public TextBox FirstNameTextBox(uint timeout = 5000) => RootWindow.FindDescendantByName("EditFirstNameTextBox", timeout).AsTextBox();

        public TextBox LastNameTextBox(uint timeout = 5000) => RootWindow.FindDescendantByName("EditLastNameTextBox", timeout).AsTextBox();

        public TextBox EmailTextBox(uint timeout = 5000) => RootWindow.FindDescendantByName("EditEMailAdressTextBox", timeout).AsTextBox();

        public RadioButton MaleRadioButton(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("EditMaleRadioButton", timeout).AsRadioButton();

        public RadioButton FemaleRadioButton(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("EditFemaleRadioButton", timeout).AsRadioButton();

        public ComboBox LanguageComboBox(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("EditLanguageComboBox", timeout).AsComboBox();

        public CheckBox NewsLetterCheckBox(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("EditSubscribeNewsletterCheckBox", timeout).AsCheckBox();

        public CustomLabelWithPattern CustomLabel(uint timeout = 5000) => RootWindow.FindDescendantByName("EditLastNameLabel", timeout).AsCustomLabelWithPattern();

        #endregion
    }
}
