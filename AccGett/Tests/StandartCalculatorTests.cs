using System;
using AccGett.Utility;
using AccGett.CalculatorViews;
using System.Threading;

namespace AccGett.Tests
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
            if (standardCalculatorView.CalculatorResults.Current.Name == "Display is 1")
            {
                Console.WriteLine("Brafó");
            }            
        }
    }
}

