using AutomationFramework.Controls;
using AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
