using EasyAutomation.AutomationFramework.Logging;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core.Controls
{
    public class ListItem : ControlElement
    {
        public ListItem(AutomationElement root) : base(root)
        { 
        }

        #region ScrollItemPattern

        public void ScrollToElement(uint timeLimit = 5000)
        {
            Log.Write("Scrolling to list item...", TextType.ActStarted);
            var pattern = Arrange<ScrollItemPattern>.GetPattern(RawElement, ScrollItemPattern.Pattern, timeLimit);
            Act.Fire(() => pattern.ScrollIntoView(), this, false, timeLimit);
        }

        #endregion

        #region SelectionItemPattern

        public bool IsSelected(uint timeLimit = 5000)
        {
            return Arrange<bool>.GetProperty(RawElement, SelectionItemPattern.IsSelectedProperty, timeLimit);
        }

        public void Select(uint timeLimit = 5000)
        {
            Log.Write("Selecting list item...", TextType.ActStarted);
            var pattern = Arrange<SelectionItemPattern>.GetPattern(RawElement, SelectionItemPattern.Pattern, timeLimit);

            if (IsOffScreen(timeLimit))
            {
                ScrollToElement(timeLimit);
            }

            Act.Fire(() => pattern.Select(), this, true, timeLimit);
        }

        #endregion

    }
}
