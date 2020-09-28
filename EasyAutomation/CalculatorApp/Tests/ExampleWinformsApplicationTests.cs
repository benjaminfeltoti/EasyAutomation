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
            new ExampleWinformsApplicationViews().SubmitButton.Invoke();

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
