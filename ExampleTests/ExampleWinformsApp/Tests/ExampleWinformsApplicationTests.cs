using EasyAutomation.AutomationFramework.Test;
using EasyAutomation.ExampleTests.CalculatorApp.Views;
using System;

namespace EasyAutomation.ExampleTests.CalculatorApp.Tests
{
    public class ExampleWinformsApplicationTests : IDisposable, ITestClass
    {
        public Action[] Tests => new Action[1] { ThisIsMyFirstTest };

        public void ThisIsMyFirstTest()
        {            
            var view = new ExampleWinformsApplicationViews();

            Assert.Equal(view.FirstNameTextBox.IsEnabled, view.LastNameTextBox.IsEnabled, 15000);
            /*
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
            */
        }

        public void CleanupClass()
        {            
            TestApplication.KillCurrentApplication();
        }

        public void CleanupTest()
        {
        }

        public void Dispose()
        {
        }

        public void SetupClass()
        {
            TestApplication.Start(new TestApplicationInformation("ExampleWinformsApplication.exe", "D:\\+Szakdolgozat\\EasyAutomation\\EasyAutomation\\ExampleWinformsApplication\\bin\\Debug"));
        }

        public void SetupTest()
        {

        }
    }
}
