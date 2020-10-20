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
            
            if (!IsChecked(timeLimit))
            {
                Toggle(timeLimit);
            }

            Log.Write("Checking checkbox has been done!", TextType.ActEnded);
        }

        public void UnCheck(uint timeLimit = 5000)
        {
            Log.Write("Unchecking checkbox...", TextType.ActStarted);
            
            if (IsChecked(timeLimit))
            {
                Toggle(timeLimit);
            }

            Log.Write("Unchecking checkbox has been done!", TextType.ActEnded);
        }

        private void Toggle(uint timeLimit)
        {
            SetFocus();
            var pattern = Arrange<TogglePattern>.GetPattern(RawElement, TogglePattern.Pattern, timeLimit);
            Act.Fire(() => pattern.Toggle(), this, true, timeLimit);
        }

        #endregion

    }
}
