﻿using AutomationFramework.Controls;
using EasyAutomation.AutomationFramework.Logging;
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

        public ControlElement FindChildByName(string name, uint timeout = 5000)
        {
            ControlElement element = Try.TryGet(() => m_Root.FindFirst(TreeScope.Children, SearchHelper.GetConditionByName(name)), timeout);

            return element;
        }

        public ControlElement FindDescendantByName(string name, uint timeout = 5000)
        {//TODO : if null throw
            ControlElement element = Try.TryGet(() => m_Root.FindFirst(TreeScope.Descendants, SearchHelper.GetConditionByName(name)), timeout);

            return element;
        }

        public ControlElement FindChildByAutomationId(string automationId, uint timeout = 5000)
        {
            ControlElement element = Try.TryGet(() => m_Root.FindFirst(TreeScope.Children, SearchHelper.GetConditionByAutomationId(automationId)), timeout);

            return element;
        }

        //Click wait until enabled and onscreen
        //public void Click();
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

        /// <summary>
        /// Returns the core informations of this object.
        /// </summary>
        /// <returns>Returns Name, AutomationId, LocalizedControlType</returns>
        public override string ToString()
        {
            return $"Name: {Name()} AutomationId: {AutomationId()} ControlType: {LocalizedControlType()}";
        }

        // Todo: Create it's own class.
        internal T GetPattern<T>(AutomationPattern automationPattern) where T : BasePattern
        {
            object patternObject;

            if (RawElement.TryGetCurrentPattern(automationPattern, out patternObject))
            {

                return patternObject as T;
            }

            string errorMessage = $"It is not possible to get the {typeof(T)} pattern on the object: {this.ToString()}";

            Log.Write(errorMessage, TextType.FatalError);
            throw new Exception(errorMessage);
        }
    }
}
