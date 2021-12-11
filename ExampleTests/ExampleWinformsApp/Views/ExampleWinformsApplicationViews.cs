using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Core.Controls;
using EasyAutomation.ExampleTests.ExampleWinformsApp.Views;
using System.Globalization;
using System.Windows.Automation;

namespace EasyAutomation.ExampleTests.CalculatorApp.Views
{
    public class ExampleWinformsApplicationViews
    {
        private ControlElement root;

        private RegistrationFormView registrationFormView;

        private EditFormView editFormView;

        public ControlElement RootWindow => root ?? (root = Desktop.Root.FindChildByAutomationId("ExamleApplication"));

        public ComboBox FormSelectorCombobox(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("ViewSelectionComboBox", timeout).AsComboBox();

        public RegistrationFormView RegistrationForm => registrationFormView ?? (registrationFormView = new RegistrationFormView(RootWindow));

        public EditFormView EditForm => editFormView ?? (editFormView = new EditFormView(RootWindow));

        public Button RefreshButton(uint timeout = 5000) => RootWindow.FindDescendantByAutomationId("RefreshButton", timeout).AsButton();

        public ListItem AnnaTesztListItem(uint timeout = 5000) => RootWindow.FindDescendantByName("Anna;Teszt;Female;Teszt.elek@ujmail.hu;German;False", timeout).AsListItem();

        public ListItem BenjaminListItem(uint timeout = 5000) => RootWindow.FindDescendantByName("Benjamin;Feltoti;Male;benjamin.feltoti@gmail.com;Hungarian;True", timeout).AsListItem();

        public ControlElement SubmitWindow(uint timeout = 5000) => RootWindow.FindChildByControlType(ControlType.Window, timeout);

        public ControlElement SubmitWindowText(uint timeout = 5000) => SubmitWindow(timeout).FindChildByControlType(ControlType.Text, timeout);

        public Button SubmitWindowYesButton(uint timeout = 5000) => CultureInfo.CurrentUICulture.Name == "hu-HU" ? 
            SubmitWindow(timeout).FindChildByName("Igen", timeout).AsButton():
            SubmitWindow(timeout).FindChildByName("Yes", timeout).AsButton();
    }
}
