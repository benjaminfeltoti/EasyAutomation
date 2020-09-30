
namespace EasyAutomation.AutomationFramework.Core.Boxing
{
    internal class ElementInformation
    {
        internal ElementInformation(string name, string automationId, string localizedControlType)
        {
            Name = name;
            AutomationId = automationId;
            LocalizedControlType = localizedControlType;
        }

        internal string Name { get; }

        internal string AutomationId { get; }

        internal string LocalizedControlType { get; }
    }
}
