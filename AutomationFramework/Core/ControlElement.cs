using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.AutomationFramework.Utility;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    public class ControlElement
    {
        protected AutomationElement m_Root;

        public ControlElement(AutomationElement root)
        {
            m_Root = root;
        }

        internal AutomationElement RawElement => m_Root;

        public string Name(uint timeout = 5000) => Arrange<string>.GetProperty(RawElement, AutomationElement.NameProperty, timeout);

        public string ClassName(uint timeout = 5000) => Arrange<string>.GetProperty(RawElement, AutomationElement.ClassNameProperty, timeout);

        public string AutomationId(uint timeout = 5000) => Arrange<string>.GetProperty(RawElement, AutomationElement.AutomationIdProperty, timeout);

        public string HelpText(uint timeout = 5000) => Arrange<string>.GetProperty(RawElement, AutomationElement.HelpTextProperty, timeout);

        public ControlType ControlType(uint timeout = 5000) => Arrange<ControlType>.GetProperty(RawElement, AutomationElement.ControlTypeProperty, timeout);

        public string LocalizedControlType(uint timeout = 5000) => Arrange<string>.GetProperty(RawElement, AutomationElement.LocalizedControlTypeProperty, timeout);

        public Rect BoundingRectangle(uint timeout = 5000) => Arrange<Rect>.GetProperty(RawElement, AutomationElement.BoundingRectangleProperty, timeout);

        public double Width(uint timeout = 5000) => BoundingRectangle(timeout).Width;

        public double Height(uint timeout = 5000) => BoundingRectangle(timeout).Height;

        public double PositionOnScreenX(uint timeout = 5000) => BoundingRectangle(timeout).X;

        public double PositionOnScreenY(uint timeout = 5000) => BoundingRectangle(timeout).Y;

        public bool IsEnabled(uint timeout = 5000) => Arrange<bool>.GetProperty(RawElement, AutomationElement.IsEnabledProperty, timeout);

        public bool IsOffScreen(uint timeout = 5000) => Arrange<bool>.GetProperty(RawElement, AutomationElement.IsOffscreenProperty, timeout);

        public void SetFocus(uint timeout = 5000)
        {
            Log.Write("Setting focus...", TextType.ActStarted);
            Act.Fire(() => m_Root.SetFocus(), this, false, timeout);
            Log.Write("Setting focus has been done!", TextType.ActEnded);
        }

        public void Click(bool waitEnables = true, uint timeout = 5000)
        {
            Log.Write("Clicking on element...", TextType.ActStarted);
            SetFocus();
            var rectangle = BoundingRectangle(timeout);            
            Act.Fire(() => Mouse.Click((uint)(rectangle.Left + rectangle.Width / 2), (uint)(rectangle.Top + rectangle.Height / 2)), this, waitEnables, timeout);
            Log.Write("Click on element was done!", TextType.ActEnded);
        }
       
        public ControlElement FindChildByName(string name, uint timeout = 5000)
        {
            Log.Write($"Searching for child, given name: { name }", TextType.ActStarted);
            return ArrangeControl.GetElement(() => m_Root.FindFirst(TreeScope.Children, PropertyConditionFactory.GetConditionByName(name)), timeout);            
        }

        public ControlElement FindDescendantByName(string name, uint timeout = 5000)
        {
            Log.Write($"Searching for descendant, given name: { name }", TextType.ActStarted);
            return ArrangeControl.GetElement(() => m_Root.FindFirst(TreeScope.Descendants, PropertyConditionFactory.GetConditionByName(name)), timeout);            
        }

        public ControlElement FindChildByAutomationId(string automationId, uint timeout = 5000)
        {
            Log.Write($"Searching for child, given AutomationId: { automationId }", TextType.ActStarted);
            return ArrangeControl.GetElement(() => m_Root.FindFirst(TreeScope.Children, PropertyConditionFactory.GetConditionByAutomationId(automationId)), timeout);
        }

        public ControlElement FindDescendantByAutomationId(string automationId, uint timeout = 5000)
        {
            Log.Write($"Searching for descendant, given AutomationId: { automationId }", TextType.ActStarted);
            return ArrangeControl.GetElement(() => m_Root.FindFirst(TreeScope.Descendants, PropertyConditionFactory.GetConditionByAutomationId(automationId)), timeout);
        }

        public ControlElement FindChildByControlType(ControlType controlType, uint timeout = 5000)
        {
            Log.Write($"Searching for child, given ControlType: { controlType.ProgrammaticName }", TextType.ActStarted);
            return ArrangeControl.GetElement(() => m_Root.FindFirst(TreeScope.Children, PropertyConditionFactory.GetConditionByControlType(controlType)), timeout);
        }
                
        /* Not supported
        public ControlElement[] FindAllChildren()
        {
            AutomationElementCollection childrenRawCollection = m_Root.FindAll(
                TreeScope.Children, new OrCondition(
                    new NotCondition(PropertyConditionFactory.GetConditionByAutomationId(string.Empty)),
                    new NotCondition(PropertyConditionFactory.GetConditionByName(string.Empty))
                ));

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
        }*/

        /// <summary>
        /// Returns the core informations of this object.
        /// </summary>
        /// <returns>Returns Name, AutomationId, LocalizedControlType</returns>
        public string GetControlInfo(uint timeLimit = 5000)
        {
            Log.Write("Getting information from current element...", TextType.ActStarted);
            var automationElementInfos = Arrange<List<KeyValuePair<AutomationProperty, object>>>.GetProperties(
                    this.RawElement, new AutomationProperty[3] { AutomationElement.NameProperty, AutomationElement.AutomationIdProperty,
                        AutomationElement.ControlTypeProperty }, timeLimit);

            var name = ArrangeControl.GetPropertyFromList(automationElementInfos, AutomationElement.NameProperty);
            var automationId = ArrangeControl.GetPropertyFromList(automationElementInfos, AutomationElement.AutomationIdProperty);
            var localizedControlType = ArrangeControl.GetPropertyFromList(automationElementInfos, AutomationElement.LocalizedControlTypeProperty);

            return $"Name: {name} AutomationId: {automationId} ControlType: {localizedControlType}";
        }
    }
}
