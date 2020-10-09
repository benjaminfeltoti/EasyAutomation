using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Logging;
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
            var pattern = GetPattern<InvokePattern>(InvokePattern.Pattern);
            Act.Fire(() => pattern.Invoke(), this, waitEnables, timeLimit, checkInterval);

            Log.Write($"{GetControlInfo(timeLimit)} button was Invoked!", TextType.SuccessfulAct);
        }
    }
}
