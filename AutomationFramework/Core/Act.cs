using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.AutomationFramework.Test;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    /// <summary>
    /// This class is responsible for UI interactions using UI Automation.
    /// </summary>
    internal static class Act
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="waitEnables">Wait until the control is Enabled and IsOffscreen is False then fire and forget the action.</param>
        /// <param name="timeLimit"></param>
        /// <param name="checkInterval"></param>
        /// <returns></returns>
        internal static void Fire(Action actionToExecute, ControlElement control, bool waitEnables = true, uint timeLimit = 5000, int checkInterval = 300)
        {
            Log.Write($"Act : Waiting enables ...", TextType.ActStarted);

            var startTime = DateTime.Now;
            var timeoutLimit = (double)timeLimit;

            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeoutLimit)
            {
                var properties = Arrange<List<KeyValuePair<AutomationProperty, object>>>.GetProperties(
                    control.RawElement, new AutomationProperty[5] {
                        AutomationElement.IsEnabledProperty, AutomationElement.IsOffscreenProperty, AutomationElement.NameProperty,
                        AutomationElement.AutomationIdProperty, AutomationElement.ControlTypeProperty }, timeLimit);

                bool isEnabled = waitEnables ? (bool)properties.Find(kp => kp.Key == AutomationElement.IsEnabledProperty).Value : false;
                bool isOffScreen = waitEnables ? (bool)properties.Find(kp => kp.Key == AutomationElement.IsOffscreenProperty).Value : true;

                if ((!waitEnables || isEnabled && !isOffScreen) && TestApplication.GetCurrentRunningProcess.Responding)
                {
                    var name = (string)properties.Find(kp => kp.Key == AutomationElement.NameProperty).Value;
                    var automationIdTemp = properties.Find(kp => kp.Key == AutomationElement.AutomationIdProperty).Value;
                    var automationId = automationIdTemp is string ? (string)automationIdTemp : "???";
                    var localizedControlType = (string)properties.Find(kp => kp.Key == AutomationElement.LocalizedControlTypeProperty).Value;
                    var elementInfo = $"Name: { name } AutomationId: { automationId } ControlType: { localizedControlType }";

                    try
                    {
                        Log.Write($"Act : Enables were ready, firing act on element : { elementInfo }", TextType.SuccessfulAct);
                        Task.Factory.StartNew(actionToExecute);
                        Log.Write("Successful Act : Action was invoked.", TextType.ActEnded);
                    }
                    catch (Exception e)
                    {
                        var errorMessage = $"ERROR: Act has thrown an exception on element: { elementInfo }  Exception Message : {e.Message}";
                        Log.Write(errorMessage, TextType.FatalError);
                        throw new Exception(errorMessage);
                    }

                    return;
                }

                Thread.Sleep(checkInterval);
            }

            var timeoutError = "ERROR : Act could not be executed within given time, because the application"
            + (waitEnables ? " or the enables" : "") + " was not ready.";
            Log.Write(timeoutError, TextType.FatalError);
            throw new Exception(timeoutError);
        }

    }
}
