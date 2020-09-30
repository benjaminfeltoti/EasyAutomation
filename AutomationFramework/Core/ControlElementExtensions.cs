using EasyAutomation.AutomationFramework.Controls;

namespace EasyAutomation.AutomationFramework.Core
{
    public static class ControlElementExtensions
    {
        public static Button AsButton(this ControlElement root)
        {
            return new Button(root.RawElement);
        }
    }
}
