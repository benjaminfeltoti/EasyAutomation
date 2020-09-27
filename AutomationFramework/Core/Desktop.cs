using EasyAutomation.AutomationFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace AutomationFramework.Core
{
    public static class Desktop
    {
        public static ControlElement Root
        {
            get
            {
                return new ControlElement(AutomationElement.RootElement);
            }
        }
    }
}
