using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAutomation.AutomationFramework.Test
{
    public interface ITestClass
    {
        Action[] Tests { get; }

        void SetupClass();

        void CleanupClass();

        void SetupTest();

        void CleanupTest();
    }
}
