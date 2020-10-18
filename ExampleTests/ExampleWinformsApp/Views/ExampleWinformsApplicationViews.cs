using EasyAutomation.AutomationFramework.Controls;
using EasyAutomation.AutomationFramework.Core;

namespace EasyAutomation.ExampleTests.CalculatorApp.Views
{
    public class ExampleWinformsApplicationViews
    {
        private ControlElement m_Root;

        private Button m_Button;

        public ControlElement RootWindow => m_Root ?? (m_Root = Desktop.Root.FindChildByAutomationId("ExamleApplication"));

        public Button SubmitButton(uint timeout = 5000) => m_Button ?? (m_Button = RootWindow.FindDescendantByName("SubmitButton", timeout).AsButton());

        public ControlElement FirstNameTextBox(uint timeout = 5000) => RootWindow.FindDescendantByName("FirstNameTextBox", timeout);

        public ControlElement LastNameTextBox(uint timeout = 5000) => (RootWindow.FindDescendantByName("LastNameTextBox", timeout));
    }
}
