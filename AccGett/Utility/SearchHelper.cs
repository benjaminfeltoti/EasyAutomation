using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace AccGett.Utility
{
    public static class SearchHelper
    {
        public static PropertyCondition GetConditionByName(string name)
        {
           return new PropertyCondition(AutomationElement.NameProperty, name, PropertyConditionFlags.IgnoreCase);
        }

        public static PropertyCondition GetConditionByAutomationId(string id)
        {
            return new PropertyCondition(AutomationElement.AutomationIdProperty, id, PropertyConditionFlags.IgnoreCase);
        }

        // params obj? 
    }
}
