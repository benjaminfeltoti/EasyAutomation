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
            Log.Write("Scrollint to list item was done!", TextType.ActEnded);
        }

        #endregion

        #region SelectionItemPattern

        public bool IsSelected(uint timeout = 5000)
        {
            Log.Write("Getting IsSelected value...", TextType.ActStarted);
            return Arrange<bool>.GetProperty(RawElement, SelectionItemPattern.IsSelectedProperty, timeout);
        }

        public void Select(uint timeout = 5000)
        {
            SetFocus(timeout);

            Log.Write("Selecting list item...", TextType.ActStarted);
            var pattern = Arrange<SelectionItemPattern>.GetPattern(RawElement, SelectionItemPattern.Pattern, timeout);

            if (IsOffScreen(timeout))
            {
                ScrollToElement(timeout);
            }

            Act.Fire(() => pattern.Select(), this, true, timeout);
            Log.Write("Selecting list item was done!", TextType.ActEnded);
        }

        #endregion

    }
}
