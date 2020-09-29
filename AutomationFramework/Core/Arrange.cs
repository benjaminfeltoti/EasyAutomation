using EasyAutomation.AutomationFramework.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    internal class ElementInformation
    {
        internal string Name { get; }

        internal string AutomationId { get; }

        internal string LocalizedControlType { get; }

        internal ElementInformation(string name, string automationId, string localizedControlType)
        {
            Name = name;
            AutomationId = automationId;
            LocalizedControlType = localizedControlType;
        }
    }

    internal static class Arrange<T>
    {
        internal static T GetProperty(AutomationElement automationElement, AutomationProperty automationProperty, uint timeLimit = 5000)
        {
            var limit = TimeSpan.FromMilliseconds(timeLimit);

            var task = Task.Factory.StartNew(() =>
            {
                string name = "???";
                string automationId = "???";
                string localizedControlType = "???";

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
            });

            bool taskIsSuccessfull = task.Wait(limit);
            var result = task.Result;

            if (task.IsCompleted)
            {
                task.Dispose();
            }

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

        //Get with retry times for stability?
    }
}
