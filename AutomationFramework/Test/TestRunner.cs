using EasyAutomation.AutomationFramework.Logging;
using System;

namespace EasyAutomation.AutomationFramework.Test
{
    public class TestRunner
    {
        public void RunTests(ITestClass[] testClasses)
        {
            foreach (var currentTestClass in testClasses)
            {
                Log.OpenLog(currentTestClass.GetType().Name);
                Log.Write("Starting test execution...", TextType.TestName);
                RunTestClass(currentTestClass);
                Log.CloseLog();
            }
        }

        private void RunTestClass(ITestClass testClass)
        {
            ushort successfulTests = 0;
            ushort failedTests = 0;

            try
            {
                Log.Write($"Starting test class {testClass.GetType().Name} execution...", TextType.TestName);
                Log.Write("Executing SetupClass()...", TextType.TestName);
                testClass.SetupClass();

                foreach (var test in testClass.Tests)
                {
                    bool testResult = true;

                    try
                    {
                        Log.Write("Executing SetupTest()...", TextType.TestName);
                        test.Setup();
                        test.Method();
                    }
                    catch (Exception e)
                    {
                        testResult = false;
                        Log.Write($"Stack trace : {e.StackTrace}", TextType.Error);
                    }
                    finally
                    {
                        if (testResult)
                        {
                            successfulTests++;
                            Log.Write($"TEST SUCCEEDED : {GetMethodName(test.Method)}", TextType.Passed);
                        }
                        else
                        {
                            failedTests++;
                            Log.Write($"TEST FAILED : {GetMethodName(test.Method)}", TextType.Failed);
                        };

                        Log.Write("Executing CleanupTest()...", TextType.TestName);
                        test.Cleanup();
                    }
                }
            }
            finally
            {
                Log.Write("Executing CleanupClass()...", TextType.TestName);
                testClass.CleanupClass();
                Log.Write("\n TestClass execution has ended! \n", TextType.TestName);
            }

            WriteSummary(testClass.GetType().Name, successfulTests, failedTests);
        }


        private void WriteSummary(string testClassName, ushort numberOfSuccessfulTests, ushort numberOfFailedTests)
        {
            Log.Write($"Summary : {testClassName}: ", TextType.TestName);
            Log.Write($"Successful tests: {numberOfSuccessfulTests}", TextType.SuccessfulAssertion);
            Log.Write($"Failed tests: {numberOfFailedTests}", TextType.FatalError);
        }

        private string GetMethodName(Action action)
        {
            return action.Method.Name;
        }
    }
}
