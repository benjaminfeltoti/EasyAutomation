using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core.Controls
{
    public class TextBox : ControlElement
    {
        public TextBox(AutomationElement root) : base(root)
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

        public void Write(string value, uint timeLimit = 5000)
        {
            var pattern = Arrange<ValuePattern>.GetPattern(RawElement, ValuePattern.Pattern, timeLimit);
            Act.Fire(() => pattern.SetValue(value), this, true, timeLimit);
        }

        public void SetValue(string value, uint timeLimit = 5000)
        {
            Write(value, timeLimit);
        }

        #endregion
    }
}
