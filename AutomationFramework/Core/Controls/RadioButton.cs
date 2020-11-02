using EasyAutomation.AutomationFramework.Logging;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core.Controls
{
    public class RadioButton : ControlElement
    {
        public RadioButton(AutomationElement root) : base(root)
        {
        }

        #region SelectionItemPattern

        public bool IsSelected(uint timeLimit = 5000)
        {
            Log.Write("Getting IsSelected value from RadioButton...", TextType.SuccessfulArrangement);
            return Arrange<bool>.GetProperty(RawElement, SelectionItemPattern.IsSelectedProperty, timeLimit);
        }

        public void Select(uint timeLimit = 5000)
        {
            Log.Write("Selecting radiobutton...", TextType.ActStarted);
            var pattern = Arrange<SelectionItemPattern>.GetPattern(RawElement, SelectionItemPattern.Pattern, timeLimit);
            Act.Fire(() => pattern.Select(), this, true, timeLimit);
            Log.Write("Selection of radiobutton was done!", TextType.ActEnded);
        }

        #endregion
    }
}
