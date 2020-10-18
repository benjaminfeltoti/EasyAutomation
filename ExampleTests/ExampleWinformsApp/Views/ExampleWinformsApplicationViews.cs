﻿using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Core.Controls;

namespace EasyAutomation.ExampleTests.CalculatorApp.Views
{
    public class ExampleWinformsApplicationViews
    {
        private ControlElement m_Root;

        private Button m_Button;

        public ControlElement RootWindow => m_Root ?? (m_Root = Desktop.Root.FindChildByAutomationId("ExamleApplication"));

        public Button SubmitButton(uint timeout = 5000) => m_Button ?? (m_Button = RootWindow.FindDescendantByName("SubmitButton", timeout).AsButton());

        public TextBox FirstNameTextBox(uint timeout = 5000) => RootWindow.FindDescendantByName("FirstNameTextBox", timeout).AsTextBox();

        public ControlElement LastNameTextBox(uint timeout = 5000) => (RootWindow.FindDescendantByName("LastNameTextBox", timeout));
    }
}
