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

        public AutomationElement RawElement => m_Root;

        public string Name(uint timeout = 5000) => Arrange<string>.Get(() => current(timeout).Name, timeout);

        public string ClassName(uint timeout = 5000) => Arrange<string>.Get(() => current(timeout).ClassName, timeout);

        public string AutomationId(uint timeout = 5000) => Arrange<string>.Get(() => current(timeout).AutomationId, timeout);

        public string HelpText(uint timeout = 5000) => Arrange<string>.Get(() => current(timeout).HelpText, timeout);

        public ControlType ControlType(uint timeout = 5000) => Arrange<ControlType>.Get(() => current(timeout).ControlType, timeout);

        public string LocalizedControlType(uint timeout = 5000) => Arrange<string>.Get(() => current(timeout).LocalizedControlType, timeout);

        public Rect BoundingRectangle(uint timeout = 5000) => Arrange<Rect>.Get(() => current(timeout).BoundingRectangle, timeout);

        public bool IsEnabled(uint timeout = 5000) => Arrange<bool>.Get(() => current(timeout).IsEnabled, timeout);

        public bool IsOffScreen(uint timeout = 5000) => Arrange<bool>.Get(() => current(timeout).IsOffscreen, timeout);

        private AutomationElement.AutomationElementInformation current(uint timeout = 5000) =>
            Arrange<AutomationElement.AutomationElementInformation>.Get(() => m_Root.Current, timeout);

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

        public ControlElement FindDescendantByName(string name) // try get timeout 5000?
        {//if null throw
            var automationElement = new ControlElement(m_Root.FindFirst(TreeScope.Descendants, SearchHelper.GetConditionByName(name)));

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
