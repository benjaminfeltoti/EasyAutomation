using EasyAutomation.AutomationFramework.Core;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Controls
{
    public class Button : ControlElement
    {
        public Button(AutomationElement root) : base(root)
        {
        }

        public void Invoke(bool waitEnables = true, uint timeLimit = 5000, int checkInterval = 300)
        {
            var pattern = Arrange<InvokePattern>.GetPattern(RawElement, InvokePattern.Pattern, timeLimit);
            Act.Fire(() => pattern.Invoke(), this, waitEnables, timeLimit, checkInterval);
        }
    }
}
