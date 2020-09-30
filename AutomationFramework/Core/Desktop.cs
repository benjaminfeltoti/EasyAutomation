using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    public static class Desktop
    {
        public static ControlElement Root
        {
            get
            {
                return new ControlElement(AutomationElement.RootElement);
            }
        }
    }
}
