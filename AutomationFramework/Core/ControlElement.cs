using EasyAutomation.AutomationFramework.Utility;
using System.Windows;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
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

        public ControlType ControlType => m_Root.Current.ControlType;

        public string LocalizedControlType => m_Root.Current.LocalizedControlType;

        public Rect BoundingRectangle => m_Root.Current.BoundingRectangle;

        public bool IsEnabled => m_Root.Current.IsEnabled;

        public bool IsOffScreen => m_Root.Current.IsOffscreen;

        public AutomationElement RawElement => m_Root;

        public void SetFocus()
        {
            m_Root.SetFocus();
        }

        public bool TryGetClickablePoint(out Point point)
        {
            point = new Point();

            return m_Root.TryGetClickablePoint(out point);
        }

        public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
        {
            patternObject = null;

            return m_Root.TryGetCurrentPattern(pattern, out patternObject);
        }

        public ControlElement FindChildByName(string name) // try get timeout 5000?
        {
            var automationElement = new ControlElement(m_Root.FindFirst(TreeScope.Children, SearchHelper.GetConditionByName(name)));

            return automationElement;
        }

        public ControlElement FindChildByAutomationId(string name)
        {
            var automationElement = new ControlElement(m_Root.FindFirst(TreeScope.Children, SearchHelper.GetConditionByAutomationId(name)));

            return automationElement;
        }


        //Click wait until enabled and onscreen

        // .As casting

        public ControlElement[] FindAllChildren()
        {
            AutomationElementCollection childrenRawCollection = m_Root.FindAll(
                TreeScope.Children, new NotCondition(SearchHelper.GetConditionByAutomationId(string.Empty)));

            int childrenCount = childrenRawCollection.Count;

            ControlElement[] controlElements = new ControlElement[childrenCount];

            if (childrenCount > 0)
            {                                
                for (int i = 0; i < childrenCount; i++)
                {
                    controlElements[i] = new ControlElement(childrenRawCollection[i]);
                }

                return controlElements;
            }

            return null;
        }
    }
}
