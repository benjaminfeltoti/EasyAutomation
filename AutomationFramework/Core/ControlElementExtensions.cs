using EasyAutomation.AutomationFramework.Core.Controls;

namespace EasyAutomation.AutomationFramework.Core
{
    public static class ControlElementExtensions
    {
        public static Button AsButton(this ControlElement root)
        {
            return new Button(root.RawElement);
        }

        public static TextBox AsTextBox(this ControlElement root)
        {
            return new TextBox(root.RawElement);
        }
    }
}
