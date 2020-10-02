using EasyAutomation.AutomationFramework.Core.Boxing;
using EasyAutomation.AutomationFramework.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    internal static class Arrange<T>
    {
        const int applicationResponseTimePingingInterval = 200;

        internal static T GetProperty(AutomationElement automationElement, AutomationProperty automationProperty, uint timeLimit = 5000)
        {
            var limit = (int)timeLimit;

            var taskCancellationToken = new CancellationTokenSource();

            var task = Task.Factory.StartNew(() =>
            {
                string name = "???";
                string automationId = "???";
                string localizedControlType = "???";

                Process[] p = Process.GetProcessesByName("ExampleWinformsApplication");

                while (p.Length > 0 && !taskCancellationToken.IsCancellationRequested)
                {
                    if (p[0].Responding)
                    {
                        try
                        {
                            var resultProperty = (T)automationElement.GetCurrentPropertyValue(automationProperty);
                            name = (string)automationElement.GetCurrentPropertyValue(AutomationElement.NameProperty, false);
                            automationId = (string)automationElement.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty, false);
                            localizedControlType = (string)automationElement.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty, false);

                            return new Tuple<T, ElementInformation>(resultProperty, new ElementInformation(name, automationId, localizedControlType));
                        }
                        catch (Exception e)
                        {
                            string errorMessage = $"ERROR : Could not get property: { automationProperty.ProgrammaticName } on element:" +
                                $" Name: {name} AutomationId: {automationId} ControlType: {localizedControlType} ; {e.Message}";

                            Log.Write(errorMessage, TextType.FatalError);
                            throw new Exception(errorMessage);
                        }
                    }

                    Thread.Sleep(applicationResponseTimePingingInterval);
                }

                return new Tuple<T, ElementInformation>(default, new ElementInformation(name, automationId, localizedControlType));

            }, taskCancellationToken.Token);

            bool taskIsSuccessfull = task.Wait(limit);

            taskCancellationToken.Cancel();

            var result = task.Result;

            CleanUpTask(task, taskCancellationToken);

            if (taskIsSuccessfull)
            {
                Log.Write($"Successful Arrangement : Load property: { automationProperty.ProgrammaticName } on element:" +
                        $" Name: {result.Item2.Name} AutomationId: {result.Item2.AutomationId} ControlType: {result.Item2.LocalizedControlType}", TextType.SuccessfulArrangement);
                return result.Item1;
            }

            string errorMessageResult = $"ERROR : Application was not responding for more than {timeLimit} seconds while triing to arrange property : { automationProperty.ProgrammaticName } on element:" +
                $" Name: {result?.Item2?.Name} AutomationId: {result?.Item2?.AutomationId} ControlType: {result?.Item2?.LocalizedControlType}";

            Log.Write(errorMessageResult, TextType.FatalError);
            throw new Exception(errorMessageResult);
        }

        private static void CleanUpTask(Task task, CancellationTokenSource taskCancellationToken)
        {
            taskCancellationToken.Dispose();

            if (task.IsCompleted)
            {
                task.Dispose();
            }
        }

        //Get with retry times for stability?
    }
}
