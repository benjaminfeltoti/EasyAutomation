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
                Log.Write("Starting test execution...", TextType.TestName);
                Log.Write("Executing SetupClass()...", TextType.TestName);
                testClasses[0].SetupClass();

                foreach (var test in testClasses[0].Tests)
                {
                    bool testResult = true;
                    
                    try
                    {
                        Log.Write("Executing SetupTest()...", TextType.TestName);
                        testClasses[0].SetupTest();
                        test.Invoke(); // TODO: Handle if true or false the result.
                    }
                    catch(Exception e)
                    {
                        // Count result
                        testResult = false;
                        Log.Write($"Stack trace : {e.StackTrace}", TextType.Error);
                    }
                    finally
                    {
                        if (testResult)
                        {
                            Log.Write($"TEST SUCCEEDED : {GetMethodName(test)}", TextType.Passed);
                        }
                        else
                        {
                            Log.Write($"TEST FAILED : {GetMethodName(test)}", TextType.Failed);
                        };

                        Log.Write("Executing CleanupTest()...", TextType.TestName);
                        testClasses[0].CleanupTest();
                    }
                }
            }
            finally
            {
                Log.Write("Executing CleanupClass()...", TextType.TestName);
                testClasses[0].CleanupClass();
            }
            //Log a summary
        }

        private string GetMethodName(Action action)
        {
            return action.Method.Name;
        }
    }
}
