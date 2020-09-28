using AutomationFramework.Controls;
using EasyAutomation.AutomationFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Core
{
    public static class ControlElementExtensions
    {
        public static Button AsButton(this ControlElement root)
        {
            return new Button(root.RawElement);
        }
    }
}
