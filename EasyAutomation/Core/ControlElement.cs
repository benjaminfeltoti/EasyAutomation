using EasyAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.Core
{
    public class ControlElement
    {
        private AutomationElement m_Root;

        public ControlElement(AutomationElement root)
        {
            m_Root = root;
        }

        public string Name => m_Root.Current.Name;

        public string ClassName => m_Root.Current.ClassName;

        public string AutomationId => m_Root.Current.AutomationId;

        public string HelpText => m_Root.Current.HelpText;

        public AutomationElement FindChildByName(string name) // try get timeout 5000?
        {
            var automationElement = m_Root.FindFirst(TreeScope.Children, SearchHelper.GetConditionByName(name));

            return automationElement;
        }

        public AutomationElement FindChildByAutomationId(string name)
        {
            var automationElement = m_Root.FindFirst(TreeScope.Children, SearchHelper.GetConditionByAutomationId(name));

            return automationElement;
        }

        //NameContains

        //public T As(): where T ControlElement
        //{
        //    return null;
        //}
    }
}
