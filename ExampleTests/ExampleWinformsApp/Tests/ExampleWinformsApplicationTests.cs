using EasyAutomation.AutomationFramework.Core;
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

            view.CustomLabel().SetDatabaseConnectionPath("NEWPATH.txt");
            view.FirstNameTextBox().Write("Tamás");
            view.LastNameTextBox().Write("János");
            view.FemaleRadioButton().Select();
            view.EmailTextBox().Write("janos.tamas@aaa.hu");
            view.LanguageComboBox().Select("German");
            view.NewsLetterCheckBox().UnCheck();
            view.SubmitButton().Click();

            Assert.Equal(view.SubmitWindowText().Name, $"Is your data correct? \n Name : Tamás János \n E-mail adress : janos.tamas@aaa.hu");

            view.SubmitWindowYesButton().Click();

            view.RootWindow.FindDescendantByName("OK", 25000).AsButton().Click();

            Assert.Equal(view.FirstNameTextBox().Value, "");
            Assert.Equal(view.LastNameTextBox().Value, "");
            Assert.Equal(view.EmailTextBox().Value, "");
            Assert.Equal(view.SubmitButton().IsEnabled, false);
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
