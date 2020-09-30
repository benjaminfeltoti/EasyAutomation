using EasyAutomation.AutomationFramework.Controls;
using EasyAutomation.AutomationFramework.Core;

namespace EasyAutomation.ExampleTests.CalculatorApp.Views
{
    public class ExampleWinformsApplicationViews
    {
        ControlElement m_FirstNameTextBox;

        public ControlElement RootWindow => Desktop.Root.FindChildByAutomationId("ExamleApplication");

        public Button SubmitButton => RootWindow.FindDescendantByName("SubmitButton").AsButton();

        public ControlElement FirstNameTextBox => m_FirstNameTextBox ?? (m_FirstNameTextBox = RootWindow.FindDescendantByName("FirstNameTextBox"));
    }
}
