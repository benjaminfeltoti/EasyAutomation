using EasyAutomation.AutomationFramework.Logging;
using System;

namespace EasyAutomation.AutomationFramework.Test
{
    public class TestRunner
    {
        // LoadTestsThatImplementITest(string namespace)

        public TestRunner()
        {

        }

        public void RunTests(ITestClass[] testClasses) // return testresults.
        {
            try
            {
                testClasses[0].SetupClass();

                foreach (var test in testClasses[0].Tests)
                {
                    bool testResult = true;
                    
                    try
                    {
                        testClasses[0].SetupTest();
                        test.Invoke(); // TODO: Handle if true or false the result.
                    }
                    catch
                    {
                        // Count result
                        testResult = false;
                    }
                    finally
                    {
                        if (testResult)
                        {
                            Log.Write($"TEST SUCCEEDED : {MethodName(test)}", TextType.Passed);
                        }
                        else
                        {
                            Log.Write($"TEST FAILED : {MethodName(test)}", TextType.Failed);
                        };

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

        private string MethodName(Action action)
        {
            return action.Method.Name;
        }
    }
}
