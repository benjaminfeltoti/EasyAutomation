using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.AutomationFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core.Controls
{
    public class ComboBox : ControlElement
    {
        public ComboBox(AutomationElement root) : base(root)
        {
        }

        #region ValuePattern

        public string Value(uint timeLimit = 5000)
        {
            return Arrange<string>.GetProperty(RawElement, ValuePattern.ValueProperty, timeLimit);
        }

        public bool IsReadOnly(uint timeLimit = 5000)
        {
            return Arrange<bool>.GetProperty(RawElement, ValuePattern.IsReadOnlyProperty, timeLimit);
        }

        #endregion

        #region ExpandCollapsePattern

        public bool IsExpanded(uint timeLimit = 5000)
        {
            var state = Arrange<ExpandCollapseState>.GetProperty(
                RawElement, ExpandCollapsePattern.ExpandCollapseStateProperty, timeLimit);

            return state != ExpandCollapseState.Collapsed ? true : false;
        }

        private void Expand(uint timeLimit = 5000)
        {
            var pattern = Arrange<ExpandCollapsePattern>.GetPattern(RawElement, ExpandCollapsePattern.Pattern, timeLimit);
            Act.Fire(() => pattern.Expand(), this, true, timeLimit);
        }

        #endregion

        public void Select(string target, uint timeLimit = 5000)
        {
            Log.Write($"Selecting {target} on combobox...", TextType.ActStarted);
            Expand(timeLimit);
            var list = ArrangeControl.GetElement(
                () => m_Root.FindFirst(
                TreeScope.Children, new AndCondition(
                    PropertyConditionFactory.GetConditionByName(this.Name(timeLimit)),
                    PropertyConditionFactory.GetConditionByControlType(System.Windows.Automation.ControlType.List))), timeLimit);

            Log.Write($"Selection dialog on combobox was found! Looking for {target} item to select...", TextType.SuccessfulArrangement);
            var targetItem = ArrangeControl.GetElement(() => list.RawElement.FindFirst(TreeScope.Children, PropertyConditionFactory.GetConditionByName(target)), timeLimit).AsListItem();

            Act.Fire(() => targetItem.Select(timeLimit), targetItem, false, timeLimit);
        }

    }
}
