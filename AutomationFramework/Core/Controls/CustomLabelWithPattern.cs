using AutomationFrameworkCustomPattern;
using EasyAutomation.AutomationFramework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core.Controls
{
    public class CustomLabelWithPattern : ControlElement
    {
        private static readonly bool exampleAppPatternIsRegistered = PatternRegistrar.RegisterExampleAppPattern();

        public CustomLabelWithPattern(AutomationElement root) : base(root)
        {
        }

        public void SetDatabaseConnectionPath(string newFileName,bool waitEnables = true, uint timeLimit = 5000, int checkInterval = 300)
        {
            Log.Write("Invoking button...", TextType.ActStarted);
            object pat = m_Root.NativeElement.GetCurrentPattern(PatternRegistrar.RegisteredExampleAppPatternId);
            var pattern = pat as IExampleAppPattern;
            Act.Fire(() => pattern.SetInputPath(newFileName), this, waitEnables, timeLimit, checkInterval);
        }
    }
}
