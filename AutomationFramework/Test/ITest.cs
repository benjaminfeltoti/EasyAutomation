using System;

namespace EasyAutomation.AutomationFramework.Test
{
    public interface ITest
    {
        Action Setup { get; }

        Action Method { get; }

        Action Cleanup { get; }
    }
}
