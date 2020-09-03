using System;
using EasyAutomation.Utility;
using EasyAutomation.CalculatorViews;
using System.Threading;
using EasyAutomation.Core;
using System.Globalization;

namespace EasyAutomation.Tests
{
    public class StandartCalculatorTests
    {
        private StandardCalculatorView standardCalculatorView;

        public StandartCalculatorTests()
        {
            Setup();

            try
            {
                TestThatStandardCalculatorViewButtonsCanBeClicked();
            }
            catch (Exception)
            {
                throw;
            }

            CleanUp();
        }

        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            System.Diagnostics.Process p = System.Diagnostics.Process.Start("C:\\Windows\\System32\\calc.exe");
            
            p.WaitForInputIdle();

            standardCalculatorView = new StandardCalculatorView();
        }

        public void CleanUp()
        {

        }

        public void TestThatStandardCalculatorViewButtonsCanBeClicked()
        {
            //Has to be in standard calc mode

            // Press 1
            Thread.Sleep(500);
            MouseActions.SetCursorPos((int)standardCalculatorView.OneButton.Current.BoundingRectangle.X + 15,
                (int)standardCalculatorView.OneButton.Current.BoundingRectangle.Y + 15);
            MouseActions.DoMouseClick((uint)standardCalculatorView.OneButton.Current.BoundingRectangle.X,
                (uint)standardCalculatorView.OneButton.Current.BoundingRectangle.Y);

            //Assert if it is 1.
            Thread.Sleep(500);

            /*
            if (standardCalculatorView.CalculatorResults.Current.Name == "Display is 1")
            {
                Console.WriteLine("Brafó");
            }  */

            if (Try.Until(() => standardCalculatorView.CalculatorResults.Current.Name == "Display is 1"))
            {
                Console.WriteLine("Brafó");
            }
        }
    }
}

