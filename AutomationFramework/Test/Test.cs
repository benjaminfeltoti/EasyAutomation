using System;

namespace EasyAutomation.AutomationFramework.Test
{
    public class Test : ITest
    {
        public Test(Action setup, Action test, Action cleanUp)
        {
            Setup = setup;
            Method = test;
            Cleanup = cleanUp;
        }

        public Action Setup { get; }

        public Action Cleanup { get; }

        public Action Method { get; }
    }
}
