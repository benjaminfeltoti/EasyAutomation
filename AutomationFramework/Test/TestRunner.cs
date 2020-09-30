using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAutomation.AutomationFramework.Test
{
    public class TestRunner
    {
        // LoadTestsThatImplementITest(string namespace)

        public void RunTests(ITestClass[] testClasses) // return testresults.
        {
            try
            {
                testClasses[0].SetupClass();

                foreach (var test in testClasses[0].Tests)
                {
                    try
                    {
                        testClasses[0].SetupTest();
                        test.Invoke(); // TODO: Handle if true or false the result.
                    }
                    catch 
                    { 
                        // Log
                    }
                    finally
                    {
                        testClasses[0].CleanupTest();
                    }

                }
            }
            finally
            {
                testClasses[0].CleanupClass();
            }
            //Log a summary
        }
    }
}
