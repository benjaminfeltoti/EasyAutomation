using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.AutomationFramework.Test;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    internal static class ArrangeControl
    {
        internal static ControlElement GetElement(Func<AutomationElement> predicate, uint timeLimit = 5000)
        {
            var limit = (int)timeLimit;

            var taskCancellationToken = new CancellationTokenSource(limit);

            var task = Task.Factory.StartNew(() =>
            {
                AutomationElement automationElement = null;

                while (!taskCancellationToken.IsCancellationRequested && automationElement == null)
                {
                    if (TestApplication.GetCurrentRunningProcess.Responding)
                    {
                        try
                        {
                            Task.Run(
                                () =>
                                {
                                    try
                                    {
                                        automationElement = predicate.Invoke();
                                    }
                                    catch (COMException)
                                    { }
                                    catch (UnauthorizedAccessException)
                                    { }
                                }
                                , new CancellationTokenSource(SettingsConstants.ApplicationResponseTimePingingIntervalForElementSearch).Token);
                        }
                        catch (Exception e)
                        {
                            string errorMessage = $"ERROR : Could not arrange ControlElement ; {e.Message}";

                            Log.Write(errorMessage, TextType.FatalError);
                            throw new Exception(errorMessage);
                        }
                    }

                    Thread.Sleep(SettingsConstants.ApplicationResponseTimePingingIntervalForElementSearch);
                }

                return automationElement;

            }, taskCancellationToken.Token);

            bool taskIsSuccessfull = task.Wait(limit);
            taskCancellationToken.Cancel();

            var result = task.Result;
            CleanUpTask(task, taskCancellationToken);

            if (taskIsSuccessfull)
            {
                // Read data from result automation element, so log can be written.
                var automationElementInfos = Arrange<List<KeyValuePair<AutomationProperty, object>>>.GetProperties(
                    result, new AutomationProperty[3] { AutomationElement.NameProperty, AutomationElement.AutomationIdProperty,
                        AutomationElement.ControlTypeProperty }, timeLimit);

                var name = GetPropertyFromList(automationElementInfos, AutomationElement.NameProperty);
                var automationId = GetPropertyFromList(automationElementInfos, AutomationElement.AutomationIdProperty);
                var localizedControlType = GetPropertyFromList(automationElementInfos, AutomationElement.LocalizedControlTypeProperty);

                Log.Write($"Successful Arrangement : Successful arrangement of new ControlElement :" +
                        $" Name: {name} AutomationId: {automationId} ControlType: {localizedControlType}", TextType.SuccessfulArrangement, true);
                return new ControlElement(result);
            }

            string errorMessageResult = $"ERROR : Application was not responding for more than {timeLimit} seconds while triing to arrange new ControlElement";

            Log.Write(errorMessageResult, TextType.FatalError);
            throw new Exception(errorMessageResult);
        }

        internal static string GetPropertyFromList(List<KeyValuePair<AutomationProperty, object>> results, AutomationProperty property)
        {
            var value = results.Exists(k => k.Key == property) ? results.Find(k => k.Key == property).Value : "";

            return value is string ? (string)value : "???";
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
