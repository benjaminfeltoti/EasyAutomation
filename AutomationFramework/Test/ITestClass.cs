using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAutomation.AutomationFramework.Test
{
    public interface ITestClass
    {
        /// <summary>
        /// TestMethods to run. IMPORTANT! Add testmethods only as methods, not as delegates!!!
        /// </summary>
        Action[] Tests { get; }

        void SetupClass();

        void CleanupClass();

        void SetupTest();

        void CleanupTest();
    }
}
