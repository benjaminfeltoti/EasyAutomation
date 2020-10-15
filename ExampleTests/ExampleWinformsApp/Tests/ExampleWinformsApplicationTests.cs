using EasyAutomation.AutomationFramework.Test;
using EasyAutomation.ExampleTests.CalculatorApp.Views;

namespace EasyAutomation.ExampleTests.CalculatorApp.Tests
{
    public class ExampleWinformsApplicationTests : ITestClass
    {
        ITest[] ITestClass.Tests => new ITest[1] { new Test(Setup, ThisIsMyFirstTest, CleanUp) };

        public void Setup()
        { }

        public void CleanUp()
        { }

        public void ThisIsMyFirstTest()
        {            
            var view = new ExampleWinformsApplicationViews();

            view.SubmitButton().Invoke(timeLimit: 15000);

            Assert.IsFalse(view.SubmitButton(20000).IsEnabled, 15000);
            //Assert.Equal(view.FirstNameTextBox.IsEnabled, view.LastNameTextBox.IsEnabled, 15000);
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

        public void SetupClass()
        {
            TestApplication.StartOrAttach(new TestApplicationInformation("ExampleWinformsApplication.exe", "ExampleWinformsApplication",
                "D:\\+Szakdolgozat\\EasyAutomation\\EasyAutomation\\ExampleWinformsApplication\\bin\\Debug"));
        }
    }
}
