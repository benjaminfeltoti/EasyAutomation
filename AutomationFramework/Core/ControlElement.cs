﻿using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.AutomationFramework.Utility;
using System;
using System.Windows;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    public class ControlElement
    {
        private AutomationElement m_Root;

        //internal?
        public ControlElement(AutomationElement root)
        {
            m_Root = root;
        }

        //internal?
        public AutomationElement RawElement => m_Root;

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

        public void SetFocus()
        {//FireAndForget on an other task
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

        public ControlElement FindChildByName(string name, uint timeout = 5000)
        {
            ControlElement element = ArrangeControl.GetElement(() => m_Root.FindFirst(TreeScope.Children, PropertyConditionFactory.GetConditionByName(name)), timeout);

            return element;
        }

        public ControlElement FindDescendantByName(string name, uint timeout = 5000)
        {//TODO : if null throw
            ControlElement element = ArrangeControl.GetElement(() => m_Root.FindFirst(TreeScope.Descendants, PropertyConditionFactory.GetConditionByName(name)), timeout);

            return element;
        }

        public ControlElement FindChildByAutomationId(string automationId, uint timeout = 5000)
        {
            ControlElement element = ArrangeControl.GetElement(() => m_Root.FindFirst(TreeScope.Children, PropertyConditionFactory.GetConditionByAutomationId(automationId)), timeout);

            return element;
        }

        //Click wait until enabled and onscreen
        //public void Click();
        // .As casting

        public ControlElement[] FindAllChildren()
        {
            AutomationElementCollection childrenRawCollection = m_Root.FindAll(
                TreeScope.Children, new NotCondition(PropertyConditionFactory.GetConditionByAutomationId(string.Empty)));

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

        /// <summary>
        /// Returns the core informations of this object.
        /// </summary>
        /// <returns>Returns Name, AutomationId, LocalizedControlType</returns>
        public string GetControlInfo(uint timeLimit = 5000)
        {
            // TODO : Get theese with get properties!
            return $"Name: {Name(timeLimit)} AutomationId: {AutomationId(timeLimit)} ControlType: {LocalizedControlType(timeLimit)}";
        }

        // Todo: Create it's own class.
        internal T GetPattern<T>(AutomationPattern automationPattern) where T : BasePattern
        {
            object patternObject;

            if (RawElement.TryGetCurrentPattern(automationPattern, out patternObject))
            {
                return patternObject as T;
            }

            string errorMessage = $"ERROR : It is not possible to get the {typeof(T)} pattern on the object: {this.ToString()}";

            Log.Write(errorMessage, TextType.FatalError);
            throw new Exception(errorMessage);
        }
    }
}
