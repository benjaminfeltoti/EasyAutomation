using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.AutomationFramework.Test;
using EasyAutomation.ExampleTests.CalculatorApp.Views;
using EasyAutomation.ExampleTests.ExampleWinformsApp.Views;
using System.IO;
using System.Text;

namespace EasyAutomation.ExampleTests.CalculatorApp.Tests
{
    public class ExampleWinformsAppTests : ITestClass
    {
        ExampleWinformsApplicationViews applicationView;

        RegistrationFormView RegistrationForm => applicationView.RegistrationForm;

        EditFormView EditForm => applicationView.EditForm;

        string pathOfCustomTxt = "D:\\+Szakdolgozat\\EasyAutomation\\EasyAutomation\\ExampleWinformsApplication\\bin\\x64\\Debug\\NEWPATH.txt";

        ITest[] ITestClass.Tests => new ITest[3]
        {
            new Test(TestSetup, ValidatorTextBoxTest, ValidatorTextBoxTestCleanUp),
            new Test(TestSetup, RegistrationFormTest, CleanUpFileAndView),
            new Test(TestSetup, EditAndValidateInput, CleanUpFileAndView)
        };

        public void TestSetup()
        {
            TestApplication.StartOrAttach(new TestApplicationInformation("ExampleWinformsApplication.exe", "ExampleWinformsApplication",
                "D:\\+Szakdolgozat\\EasyAutomation\\EasyAutomation\\ExampleWinformsApplication\\bin\\x64\\Debug"));

            applicationView = new ExampleWinformsApplicationViews();
        }

        public void CleanUpFileAndView()
        {
            applicationView = null;

            if (File.Exists(pathOfCustomTxt))
            {
                File.Delete(pathOfCustomTxt);
            }
        }

        public void ValidatorTextBoxTestCleanUp()
        {
            RegistrationForm.FirstNameTextBox().Write("");
            RegistrationForm.LastNameTextBox().Write("");
            RegistrationForm.EmailTextBox().Write("");

            applicationView = null;
        }

        #region RegistrationForm tests

        public void RegistrationFormTest()
        {
            applicationView.FormSelectorCombobox().Select("Registration form");
            RegistrationForm.CustomLabel().SetDatabaseConnectionPath("NEWPATH.txt");
            RegistrationForm.FirstNameTextBox().Write("Adél");
            RegistrationForm.LastNameTextBox().Write("Adrienn");
            RegistrationForm.FemaleRadioButton().Select();
            RegistrationForm.EmailTextBox().Write("adel.adrienn@ujmail.hu");
            RegistrationForm.LanguageComboBox().Select("German");
            RegistrationForm.NewsLetterCheckBox().UnCheck();
            RegistrationForm.SubmitButton().Click();

            Assert.Equal(applicationView.SubmitWindowText().Name, $"Is your data correct? \n Name : Adél Adrienn \n E-mail adress : adel.adrienn@ujmail.hu");

            applicationView.SubmitWindowYesButton().Click();
            applicationView.RootWindow.FindDescendantByName("OK", 25000).AsButton().Click();

            Assert.Equal(RegistrationForm.FirstNameTextBox().Value, "");
            Assert.Equal(RegistrationForm.LastNameTextBox().Value, "");
            Assert.Equal(RegistrationForm.EmailTextBox().Value, "");
            Assert.Equal(RegistrationForm.SubmitButton().IsEnabled, false);

            string ReadTxt()
            {
                StringBuilder stringBuilder = new StringBuilder();

                using (StreamReader sr = new StreamReader(pathOfCustomTxt))
                {
                    stringBuilder.Append(sr.ReadToEnd());
                }

                return stringBuilder.ToString();
            }

            string stringExpectedOutput = @"Adél;Adrienn;Female;adel.adrienn@ujmail.hu;German;False
";

            Assert.Equal(ReadTxt, stringExpectedOutput);
        }

        public void ValidatorTextBoxTest()
        {
            applicationView.FormSelectorCombobox().Select("Registration form");
            RegistrationForm.FirstNameTextBox().Write("Adél");
            RegistrationForm.LastNameTextBox().Write("Adrienn");
            RegistrationForm.EmailTextBox().Write("adel.adrienn@ujmailhu");
            RegistrationForm.FemaleRadioButton().Select();

            Assert.Equal(RegistrationForm.EmailTextBox().HelpText, "Value is not valid");
            Assert.IsFalse(RegistrationForm.SubmitButton().IsEnabled);

            RegistrationForm.EmailTextBox().Write("adel.adrienn@ujmail.hu");
            RegistrationForm.FirstNameTextBox().SetFocus();

            Assert.Equal(RegistrationForm.EmailTextBox().HelpText, "Value is valid");
            Assert.IsTrue(RegistrationForm.SubmitButton().IsEnabled);
        }

        #endregion

        #region EditForm tests

        public void EditAndValidateInput()
        {
            applicationView.FormSelectorCombobox().Select("Edit form");

            Log.Write("Writing custom data to custom text...", TextType.ActStarted);
            using (StreamWriter sw = new StreamWriter(pathOfCustomTxt))
            {
                sw.WriteLine(@"Anna;Teszt;Female;Teszt.elek@ujmail.hu;German;False
Elek;Teszt;Male;teszt.elek@mail.hu;German;True");
            }

            EditForm.CustomLabel().SetDatabaseConnectionPath("NEWPATH.txt");
            applicationView.RefreshButton().Click();

            Assert.IsFalse(EditForm.EditButton(10000).IsEnabled, 10000, 1000);
            Assert.IsFalse(EditForm.FirstNameTextBox().IsEnabled);
            Assert.IsFalse(EditForm.LastNameTextBox().IsEnabled);
            Assert.IsFalse(EditForm.MaleRadioButton().IsEnabled);
            Assert.IsFalse(EditForm.FemaleRadioButton().IsEnabled);
            Assert.IsFalse(EditForm.EmailTextBox().IsEnabled);
            Assert.IsFalse(EditForm.NewsLetterCheckBox().IsEnabled);

            applicationView.AnnaTesztListItem().Click();

            Assert.IsTrue(EditForm.EditButton().IsEnabled);
            Assert.IsTrue(EditForm.FirstNameTextBox().IsEnabled);
            Assert.IsTrue(EditForm.LastNameTextBox().IsEnabled);
            Assert.IsTrue(EditForm.MaleRadioButton().IsEnabled);
            Assert.IsTrue(EditForm.FemaleRadioButton().IsEnabled);
            Assert.IsTrue(EditForm.EmailTextBox().IsEnabled);
            Assert.IsTrue(EditForm.NewsLetterCheckBox().IsEnabled);

            Assert.Equal(EditForm.FirstNameTextBox().Value, "Anna");
            Assert.Equal(EditForm.LastNameTextBox().Value, "Teszt");
            Assert.Equal(EditForm.FemaleRadioButton().IsSelected, true);
            Assert.Equal(EditForm.EmailTextBox().Value, "Teszt.elek@ujmail.hu");
            Assert.Equal(EditForm.LanguageComboBox().Value, "German");
            Assert.Equal(EditForm.NewsLetterCheckBox().IsChecked, false);

            EditForm.FirstNameTextBox().SetValue("Benjamin");
            EditForm.LastNameTextBox().SetValue("Feltoti");
            EditForm.MaleRadioButton().Select();
            EditForm.EmailTextBox().SetValue("benjamin.feltoti@gmail.com");
            EditForm.LanguageComboBox().Select("Hungarian");
            EditForm.NewsLetterCheckBox().Check();
            EditForm.EditButton().Click();

            applicationView.SubmitWindowYesButton().Click();
            applicationView.RootWindow.FindDescendantByName("OK", 25000).AsButton().Click();

            string ReadTxt()
            {
                StringBuilder stringBuilder = new StringBuilder();

                using (StreamReader sr = new StreamReader(pathOfCustomTxt))
                {
                    stringBuilder.Append(sr.ReadToEnd());
                }

                return stringBuilder.ToString();
            }

            string stringExpectedOutput = @"Benjamin;Feltoti;Male;benjamin.feltoti@gmail.com;Hungarian;True
Elek;Teszt;Male;teszt.elek@mail.hu;German;True
";
            //Verify file
            Assert.Equal(ReadTxt, stringExpectedOutput);

            //Verify on UI
            applicationView.RefreshButton().Click();
            Assert.Equal(applicationView.BenjaminListItem(10000).Name, "Benjamin;Feltoti;Male;benjamin.feltoti@gmail.com;Hungarian;True", 10000);
        }

        #endregion

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
