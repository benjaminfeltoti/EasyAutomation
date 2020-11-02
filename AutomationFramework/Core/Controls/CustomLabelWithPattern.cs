using AutomationFrameworkCustomPattern;
using EasyAutomation.AutomationFramework.Logging;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core.Controls
{
    public class CustomLabelWithPattern : ControlElement
    {
        private static readonly bool exampleAppPatternIsRegistered = PatternRegistrar.RegisterExampleAppPattern();

        public CustomLabelWithPattern(AutomationElement root) : base(root)
        {
        }

        public void SetDatabaseConnectionPath(string newFileName, uint timeLimit = 5000)
        {
            Log.Write($"Calling SetDataBaseConnectionPath through custom pattern to { newFileName } ...", TextType.ActStarted);
            object customPattern = m_Root.NativeElement.GetCurrentPattern(PatternRegistrar.RegisteredExampleAppPatternId);
            var pattern = customPattern as IExampleAppPattern;
            Act.Fire(() => pattern.SetInputPath(newFileName), this, false, timeLimit);
            Log.Write($"Calling SetDataBaseConnectionPath through custom pattern was done!", TextType.ActEnded);
        }
    }
}
