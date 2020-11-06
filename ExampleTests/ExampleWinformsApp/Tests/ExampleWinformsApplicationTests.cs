using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Test;
using EasyAutomation.ExampleTests.CalculatorApp.Views;

namespace EasyAutomation.ExampleTests.CalculatorApp.Tests
{
    public class ExampleWinformsApplicationTests : ITestClass
    {
        ExampleWinformsApplicationViews view;

        ITest[] ITestClass.Tests => new ITest[1] { new Test(RegistrationFormTestSetup, RegistrationFormTest, CleanUp) };

        public void RegistrationFormTestSetup()
        {
            view = new ExampleWinformsApplicationViews();
            view.FormSelectorCombobox().Select("Registration form");
        }

        public void CleanUp()
        {
            view = null;
        }

        public void RegistrationFormTest()
        {
            view.CustomLabel().SetDatabaseConnectionPath("NEWPATH.txt");
            view.FirstNameTextBox().Write("Adél");
            view.LastNameTextBox().Write("Adrienn");
            view.FemaleRadioButton().Select();
            view.EmailTextBox().Write("adel.adrienn@ujmail.hu");
            view.LanguageComboBox().Select("German");
            view.NewsLetterCheckBox().UnCheck();
            view.SubmitButton().Click();

            Assert.Equal(view.SubmitWindowText().Name, $"Is your data correct? \n Name : Adél Adrienn \n E-mail adress : adel.adrienn@ujmail.hu");

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
                "D:\\+Szakdolgozat\\EasyAutomation\\EasyAutomation\\ExampleWinformsApplication\\bin\\x64\\Debug"));
        }
    }
}
