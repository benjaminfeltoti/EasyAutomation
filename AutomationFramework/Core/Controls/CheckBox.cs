using EasyAutomation.AutomationFramework.Logging;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core.Controls
{
    public class CheckBox : ControlElement
    {
        public CheckBox(AutomationElement root) : base(root) 
        {                
        }

        #region TogglePattern

        public bool IsChecked(uint timeLimit = 5000)
        { 
            var toggleState = Arrange<ToggleState>.GetProperty(RawElement, TogglePattern.ToggleStateProperty, timeLimit);

            return toggleState == ToggleState.On;
        }

        public void Check(uint timeLimit = 5000)
        {
            Log.Write("Checking checkbox...", TextType.ActStarted);
            var pattern = Arrange<TogglePattern>.GetPattern(RawElement, TogglePattern.Pattern, timeLimit);

            if (!IsChecked(timeLimit))
            {
                Act.Fire(() => pattern.Toggle(), this, true, timeLimit);
            }
        }

        public void UnCheck(uint timeLimit = 5000)
        {
            Log.Write("Unchecking checkbox...", TextType.ActStarted);
            var pattern = Arrange<TogglePattern>.GetPattern(RawElement, TogglePattern.Pattern, timeLimit);

            if (IsChecked(timeLimit))
            {
                Act.Fire(() => pattern.Toggle(), this, true, timeLimit);
            }
        }

        #endregion

    }
}
