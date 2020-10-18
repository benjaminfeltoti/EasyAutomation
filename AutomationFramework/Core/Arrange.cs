using EasyAutomation.AutomationFramework.Core.Boxing;
using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.AutomationFramework.Test;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    internal static class Arrange<T>
    {
        internal static T GetProperty(AutomationElement automationElement, AutomationProperty automationProperty, uint timeLimit = 5000)
        {
            var limit = (int)timeLimit;

            var taskCancellationToken = new CancellationTokenSource(limit);

            var task = Task.Factory.StartNew(() =>
            {
                string name = "???";
                string automationId = "???";
                string localizedControlType = "???";
                var asyncResult = default(Tuple<T, ElementInformation>);

                while (!taskCancellationToken.IsCancellationRequested)
                {

                    if (TestApplication.GetCurrentRunningProcess.Responding && asyncResult == default(Tuple<T, ElementInformation>))
                    {
                        try
                        {
                            Task.Run(() =>
                            {
                                var resultProperty = (T)automationElement.GetCurrentPropertyValue(automationProperty);
                                name = (string)automationElement.GetCurrentPropertyValue(AutomationElement.NameProperty, false);
                                automationId = (string)automationElement.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty, false);
                                localizedControlType = (string)automationElement.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty, false);

                                asyncResult = new Tuple<T, ElementInformation>(resultProperty, new ElementInformation(name, automationId, localizedControlType));
                            }, new CancellationTokenSource(SettingsConstants.ApplicationResponseTimePingingIntervalForProperties).Token);
                        }
                        catch (Exception e)
                        {
                            string errorMessage = $"ERROR : Could not get property: { automationProperty.ProgrammaticName } on element:" +
                                $" Name: {name} AutomationId: {automationId} ControlType: {localizedControlType} ; {e.Message}";

                            Log.Write(errorMessage, TextType.FatalError);
                            throw new Exception(errorMessage);
                        }
                    }

                    Thread.Sleep(SettingsConstants.ApplicationResponseTimePingingIntervalForProperties);

                    if (asyncResult != default(Tuple<T, ElementInformation>))
                    {
                        return asyncResult;
                    }
                }

                return null;

            }, taskCancellationToken.Token);

            bool taskIsSuccessfull = task.Wait(limit);

            taskCancellationToken.Cancel();

            var result = task.Result;

            CleanUpTask(task, taskCancellationToken);

            if (taskIsSuccessfull)
            {
                Log.Write($"Successful Arrangement : Load property: { automationProperty.ProgrammaticName } = {result.Item1} on element:" +
                        $" Name: {result.Item2.Name} AutomationId: {result.Item2.AutomationId} ControlType: {result.Item2.LocalizedControlType}", TextType.SuccessfulArrangement, true);
                return result.Item1;
            }

            string errorMessageResult = $"ERROR : Application was not responding for more than {timeLimit} seconds while triing to arrange property : { automationProperty.ProgrammaticName } on element:" +
                $" Name: {result?.Item2?.Name} AutomationId: {result?.Item2?.AutomationId} ControlType: {result?.Item2?.LocalizedControlType}";

            Log.Write(errorMessageResult, TextType.FatalError);
            throw new Exception(errorMessageResult);
        }

        internal static List<KeyValuePair<AutomationProperty, object>> GetProperties(AutomationElement automationElement, AutomationProperty[] automationProperties, uint timeLimit = 5000)
        {
            var limit = (int)timeLimit;

            var taskCancellationToken = new CancellationTokenSource();

            var task = Task.Factory.StartNew(() =>
            {
                string name = "???";
                string automationId = "???";
                string localizedControlType = "???";
                List<KeyValuePair<AutomationProperty, object>> results = new List<KeyValuePair<AutomationProperty, object>>();
                var asyncResult = default(Tuple<List<KeyValuePair<AutomationProperty, object>>, ElementInformation>);

                while (!taskCancellationToken.IsCancellationRequested)
                {
                    if (TestApplication.GetCurrentRunningProcess.Responding)
                    {
                        try
                        {
                            Task.Run(() =>
                            {
                                foreach (var automationProperty in automationProperties)
                                {
                                    results.Add(new KeyValuePair<AutomationProperty, object>(
                                        automationProperty, automationElement.GetCurrentPropertyValue(automationProperty, true)));
                                }

                                name = GetPropertyFromList(results, automationElement, AutomationElement.NameProperty);
                                automationId = GetPropertyFromList(results, automationElement, AutomationElement.AutomationIdProperty);
                                localizedControlType = GetPropertyFromList(results, automationElement, AutomationElement.LocalizedControlTypeProperty);

                                asyncResult = new Tuple<List<KeyValuePair<AutomationProperty, object>>, ElementInformation>(
                                    results, new ElementInformation(name, automationId, localizedControlType));

                            }, new CancellationTokenSource(SettingsConstants.ApplicationResponseTimePingingIntervalForProperties).Token);
                        }
                        catch (Exception e)
                        {
                            string errorMessage = $"ERROR : Could not get properties: { GetPropertyNames(automationProperties) } on element:" +
                                $" Name: {name} AutomationId: {automationId} ControlType: {localizedControlType} ; {e.Message}";

                            Log.Write(errorMessage, TextType.FatalError);
                            throw new Exception(errorMessage);
                        }
                    }

                    Thread.Sleep(SettingsConstants.ApplicationResponseTimePingingIntervalForProperties);

                    if (asyncResult != default(Tuple<List<KeyValuePair<AutomationProperty, object>>, ElementInformation>))
                    {
                        return asyncResult;
                    }
                }

                return null;

            }, taskCancellationToken.Token);

            bool taskIsSuccessfull = task.Wait(limit);

            taskCancellationToken.Cancel();

            var result = task.Result;

            CleanUpTask(task, taskCancellationToken);

            if (taskIsSuccessfull)
            {
                Log.Write($"Successful Arrangement : Load property: { GetPropertyNamesWithValues(result.Item1) } on element:" +
                        $" Name: {result.Item2.Name} AutomationId: {result.Item2.AutomationId} ControlType: {result.Item2.LocalizedControlType}", TextType.SuccessfulArrangement, true);
                return result.Item1;
            }

            string errorMessageResult = $"ERROR : Application was not responding for more than {timeLimit} seconds while triing to arrange property Array on element:" +
                $" Name: {result?.Item2?.Name} AutomationId: {result?.Item2?.AutomationId} ControlType: {result?.Item2?.LocalizedControlType}";

            Log.Write(errorMessageResult, TextType.FatalError);
            throw new Exception(errorMessageResult);
        }

        internal static T GetPattern(AutomationElement automationElement, AutomationPattern pattern, uint timeLimit = 5000)
        {
            var limit = (int)timeLimit;

            var taskCancellationToken = new CancellationTokenSource(limit);

            var task = Task.Factory.StartNew(() =>
            {
                string name = "???";
                string automationId = "???";
                string localizedControlType = "???";
                var asyncResult = default(Tuple<T, ElementInformation>);

                while (!taskCancellationToken.IsCancellationRequested)
                {

                    if (TestApplication.GetCurrentRunningProcess.Responding && asyncResult == default(Tuple<T, ElementInformation>))
                    {
                        try
                        {
                            Task.Run(() =>
                            {
                                var resultProperty = (T)automationElement.GetCurrentPattern(pattern);
                                name = (string)automationElement.GetCurrentPropertyValue(AutomationElement.NameProperty, false);
                                automationId = (string)automationElement.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty, false);
                                localizedControlType = (string)automationElement.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty, false);

                                asyncResult = new Tuple<T, ElementInformation>(resultProperty, new ElementInformation(name, automationId, localizedControlType));
                            }, new CancellationTokenSource(SettingsConstants.ApplicationResponseTimePingingIntervalForProperties).Token);
                        }
                        catch (Exception e)
                        {
                            string errorMessage = $"ERROR : Could not get pattern: { pattern.ProgrammaticName } on element:" +
                                $" Name: {name} AutomationId: {automationId} ControlType: {localizedControlType} ; {e.Message}";

                            Log.Write(errorMessage, TextType.FatalError);
                            throw new Exception(errorMessage);
                        }
                    }

                    Thread.Sleep(SettingsConstants.ApplicationResponseTimePingingIntervalForProperties);

                    if (asyncResult != default(Tuple<T, ElementInformation>))
                    {
                        return asyncResult;
                    }
                }

                return null;

            }, taskCancellationToken.Token);

            bool taskIsSuccessfull = task.Wait(limit);

            taskCancellationToken.Cancel();

            var result = task.Result;

            CleanUpTask(task, taskCancellationToken);

            if (taskIsSuccessfull)
            {
                Log.Write($"Successful Arrangement : Load pattern: { pattern.ProgrammaticName } = {result.Item1} on element:" +
                        $" Name: {result.Item2.Name} AutomationId: {result.Item2.AutomationId} ControlType: {result.Item2.LocalizedControlType}", TextType.SuccessfulArrangement, true);
                return result.Item1;
            }

            string errorMessageResult = $"ERROR : Application was not responding for more than {timeLimit} seconds while triing to arrange property : { pattern.ProgrammaticName } on element:" +
                $" Name: {result?.Item2?.Name} AutomationId: {result?.Item2?.AutomationId} ControlType: {result?.Item2?.LocalizedControlType}";

            Log.Write(errorMessageResult, TextType.FatalError);
            throw new Exception(errorMessageResult);
        }

        private static string GetPropertyNames(AutomationProperty[] automationProperties)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var automationProperty in automationProperties)
            {
                stringBuilder.Append(automationProperty.ProgrammaticName);
                stringBuilder.Append(" ");
            }

            return stringBuilder.ToString();
        }

        private static string GetPropertyNamesWithValues(List<KeyValuePair<AutomationProperty, object>> keyValuePairs)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var keyValuePair in keyValuePairs)
            {
                stringBuilder.Append(keyValuePair.Key.ProgrammaticName);
                stringBuilder.Append(" = ");
                stringBuilder.Append(keyValuePair.Value.ToString());
                stringBuilder.Append(" ; ");
            }

            return stringBuilder.ToString();
        }

        private static string GetPropertyFromList(List<KeyValuePair<AutomationProperty, object>> results, AutomationElement automationElement, AutomationProperty property)
        {
            return (string)(results.Exists(k => k.Key == property)
                                ? results.Find(k => k.Key == property).Value
                                : automationElement.GetCurrentPropertyValue(property, true));
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
