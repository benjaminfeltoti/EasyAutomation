using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace AutomationFramework.Controls
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
