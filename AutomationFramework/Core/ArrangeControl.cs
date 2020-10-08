using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.AutomationFramework.Test;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    internal static class ArrangeControl
    {
        internal static ControlElement GetElement(Func<AutomationElement> predicate, uint timeLimit = 5000, int checkInterval = 300)
        {
            var limit = (int)timeLimit;

            var taskCancellationToken = new CancellationTokenSource();

            var task = Task.Factory.StartNew(() =>
            {
                AutomationElement automationElement = null;

                while (!taskCancellationToken.IsCancellationRequested && automationElement == null)
                {
                    if (TestApplication.GetCurrentRunningProcess.Responding)
                    {
                        try
                        {
                            automationElement = predicate.Invoke();
                        }
                        catch (Exception e)
                        {
                            string errorMessage = $"ERROR : Could not arrange ControlElement ; {e.Message}";

                            Log.Write(errorMessage, TextType.FatalError);
                            throw new Exception(errorMessage);
                        }
                    }
                    
                    Thread.Sleep(checkInterval);
                }

                return automationElement;

            }, taskCancellationToken.Token);

            bool taskIsSuccessfull = task.Wait(limit);
            taskCancellationToken.Cancel();

            var result = task.Result;
            CleanUpTask(task, taskCancellationToken);

            if (taskIsSuccessfull)
            {
                var name = (string)result.GetCurrentPropertyValue(AutomationElement.NameProperty, false);
                var automationId = (string)result.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty, false);
                var localizedControlType = (string)result.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty, false);

                Log.Write($"Successful Arrangement : Successful arrangement of new ControlElement :" +
                        $" Name: {name} AutomationId: {automationId} ControlType: {localizedControlType}", TextType.SuccessfulArrangement, true);
                return new ControlElement(result);
            }

            string errorMessageResult = $"ERROR : Application was not responding for more than {timeLimit} seconds while triing to arrange new ControlElement";

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
    }
}
