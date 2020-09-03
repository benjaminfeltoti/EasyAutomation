using System.Windows.Automation;

namespace EasyAutomation.Utility
{
    public static class SearchHelper
    {        
        public static PropertyCondition GetConditionByHelpText(string value)
        {
            return new PropertyCondition(AutomationElement.HelpTextProperty, value, PropertyConditionFlags.IgnoreCase);
        }

        public static PropertyCondition GetConditionByAutomationId(string value)
        {
            return new PropertyCondition(AutomationElement.AutomationIdProperty, value, PropertyConditionFlags.IgnoreCase);
        }

        public static PropertyCondition GetConditionByClassName(string value)
        {
            return new PropertyCondition(AutomationElement.ClassNameProperty, value, PropertyConditionFlags.IgnoreCase);
        }

        public static PropertyCondition GetConditionByName(string value)
        {
            return new PropertyCondition(AutomationElement.NameProperty, value, PropertyConditionFlags.IgnoreCase);
        }

        public static PropertyCondition GetConditionByLocalizedControlType(string value)
        {
            return new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, value, PropertyConditionFlags.IgnoreCase);
        }

        public static PropertyCondition GetConditionByIsEnabled(bool value)
        {
            return new PropertyCondition(AutomationElement.IsEnabledProperty, value, PropertyConditionFlags.IgnoreCase);
        }

        public static PropertyCondition GetConditionByIsOffScreen(bool value)
        {
            return new PropertyCondition(AutomationElement.IsOffscreenProperty, value, PropertyConditionFlags.IgnoreCase);
        }

        public static PropertyCondition GetConditionByBoundingRectangle(bool value)
        {
            return new PropertyCondition(AutomationElement.BoundingRectangleProperty, value, PropertyConditionFlags.IgnoreCase);
        }        
    }
}
