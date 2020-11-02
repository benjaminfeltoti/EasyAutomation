using EasyAutomation.AutomationFramework.Logging;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core.Controls
{
    /// <summary>
    /// Use ControlElement as Button. Adds Invoke funcionality.
    /// </summary>
    public class Button : ControlElement
    {
        public Button(AutomationElement root) : base(root)
        {
        }

        /// <summary>
        /// Invokes the button. IMPORTANT! Do not invoke upcoming dialog with it, it causes deadlock!
        /// </summary>
        /// <param name="waitEnables">Wait until IsOffScreen is false and Enabled.</param>
        /// <param name="timeLimit">Time until you wait.</param>
        /// <param name="checkInterval">Interval of checking the next enables if program has to wait.</param>
        public void Invoke(bool waitEnables = true, uint timeLimit = 5000, int checkInterval = 300)
        {
            Log.Write("Invoking button...", TextType.ActStarted);
            var pattern = Arrange<InvokePattern>.GetPattern(RawElement, InvokePattern.Pattern, timeLimit);
            Act.Fire(() => pattern.Invoke(), this, waitEnables, timeLimit, checkInterval);
            Log.Write("Invoking button was done!", TextType.ActEnded);
        }
    }
}
