using EasyAutomation.AutomationFramework.Core.Controls;

namespace EasyAutomation.AutomationFramework.Core
{
    public static class ControlElementExtensions
    {
        // Check if cast is possible by checking patterns?
        public static Button AsButton(this ControlElement root)
        {
            return new Button(root.RawElement);
        }

        public static TextBox AsTextBox(this ControlElement root)
        {
            return new TextBox(root.RawElement);
        }
               
        public static RadioButton AsRadioButton(this ControlElement root)
        {
            return new RadioButton(root.RawElement);
        }

        public static CheckBox AsCheckBox(this ControlElement root)
        {
            return new CheckBox(root.RawElement);
        }

        public static ComboBox AsComboBox(this ControlElement root)
        {
            return new ComboBox(root.RawElement);
        }

        public static ListItem AsListItem(this ControlElement root)
        {
            return new ListItem(root.RawElement);
        }

        public static CustomLabelWithPattern AsCustomLabelWithPattern(this ControlElement root)
        {
            return new CustomLabelWithPattern(root.RawElement);
        }
    }
}
