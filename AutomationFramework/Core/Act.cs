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
        /// <param name="waitEnables">Wait with the fire and forget action until the control is Enabled and IsOffscreen == False</param>
        /// <param name="timeLimit"></param>
        /// <param name="checkInterval"></param>
        /// <returns></returns>
        internal static void Fire(Action actionToExecute, ControlElement control, bool waitEnables = true, uint timeLimit = 5000, int checkInterval = 300)
        {
            Log.Write($"Act : Waiting enables ...", TextType.SuccessfulAct);

            var startTime = DateTime.Now;
            var timeoutLimit = (double)timeLimit;

            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeoutLimit)
            {
                var properties = Arrange<List<KeyValuePair<AutomationProperty, object>>>.GetProperties(
                    control.RawElement, new AutomationProperty[2] {
                        AutomationElement.IsEnabledProperty, AutomationElement.IsOffscreenProperty }, timeLimit);

                bool isEnabled = waitEnables ? (bool)properties.Find(kp => kp.Key == AutomationElement.IsEnabledProperty).Value : false;
                bool isOffScreen = waitEnables ? (bool)properties.Find(kp => kp.Key == AutomationElement.IsOffscreenProperty).Value : true;

                if ((!waitEnables || isEnabled && !isOffScreen) && TestApplication.GetCurrentRunningProcess.Responding)
                {
                    try
                    {
                        Log.Write($"Act : Enables were ready, act was fired!", TextType.SuccessfulAct);
                        Task.Factory.StartNew(actionToExecute); // This still does not sole the issue with on invokeing a dialog.
                    }
                    catch (Exception e)
                    {
                        var errorMessage = $"ERROR: Act has thrown an exception! : {e.Message}";
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
