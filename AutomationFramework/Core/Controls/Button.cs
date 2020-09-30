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

        public void Invoke()
        {
            //Todo : Invoke only if the element is ready and enabled, with fire and forget on an other thread.
            GetPattern<InvokePattern>(InvokePattern.Pattern).Invoke();
            Log.Write($"{this.ToString()} button was Invoked!", TextType.SuccessfulAct);
        }
    }
}
