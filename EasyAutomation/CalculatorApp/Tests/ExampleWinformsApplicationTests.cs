using AutomationFramework.Test;
using EasyAutomation.ExampleTests.CalculatorApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAutomation.ExampleTests.CalculatorApp.Tests
{
    public class ExampleWinformsApplicationTests : IDisposable, ITestClass
    {
        public Action[] Tests => new Action[1] { () => ThisIsMyFirstTest() };

        public bool ThisIsMyFirstTest()
        {
            var view = new ExampleWinformsApplicationViews();

            for (int i = 0; i < 999; i++)
            {
                _ = view.FirstNameTextBox.AutomationId();
                _ = view.FirstNameTextBox.Name();
                _ = view.FirstNameTextBox.ClassName();
                _ = view.FirstNameTextBox.HelpText();
                _ = view.FirstNameTextBox.BoundingRectangle();
                _ = view.FirstNameTextBox.LocalizedControlType();
                _ = view.FirstNameTextBox.IsEnabled();
                _ = view.FirstNameTextBox.IsOffScreen();
            }

            return true;
        }

        public void CleanupClass()
        {
        }

        public void CleanupTest()
        {
        }

        public void Dispose()
        {
        }

        public void SetupClass()
        {
        }

        public void SetupTest()
        {

        }
    }
}
