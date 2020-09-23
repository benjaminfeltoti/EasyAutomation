using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.AutomationFramework.Core
{
    public static class Try
    {
        public static bool Until(Func<bool> predicate, uint timeLimit = 5000, int checkInterval = 300)
        {
            var limit = TimeSpan.FromMilliseconds(timeLimit);

            var taskCancellationToken = new CancellationTokenSource();

            var task = Task.Factory.StartNew<bool>(() =>
            {
                bool predicateResult = false;
                
                while (!predicateResult && !taskCancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        predicateResult = predicate.Invoke();
                        Console.WriteLine(predicateResult);
                    }
                    catch (Exception e)
                    {
                        //LogMessage
                        Console.WriteLine(e.Message);
                        throw;
                    }

                    Thread.Sleep(checkInterval);
                }

                return predicateResult;

            }, taskCancellationToken.Token);

            bool taskIsSuccessfull = task.Wait(limit);
            
            taskCancellationToken.Cancel();
            taskCancellationToken.Dispose();

            if (task.IsCompleted)
            {
                task.Dispose();
            }

            if (taskIsSuccessfull)
            {
                //LogMessage
                return true;
            }

            //Logmessage
            return false;
        }

        public static ControlElement TryGet(Func<AutomationElement> predicate, uint timeLimit = 5000, int checkInterval = 300)
        {
            var limit = TimeSpan.FromMilliseconds(timeLimit);

            var taskCancellationToken = new CancellationTokenSource();

            var task = Task.Factory.StartNew<AutomationElement>(() =>
            {
                AutomationElement predicateResult = null;

                while (predicateResult == null && !taskCancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        predicateResult = predicate.Invoke();
                        Console.WriteLine(predicateResult);
                    }
                    catch (Exception e)
                    {
                        //LogMessage
                        Console.WriteLine(e.Message);
                        throw;
                    }

                    Thread.Sleep(checkInterval);
                }

                return predicateResult;

            }, taskCancellationToken.Token);

            AutomationElement automationElement = task.Result;
            bool taskIsSuccessfull = task.Wait(limit);

            taskCancellationToken.Cancel();
            taskCancellationToken.Dispose();
            task.Dispose();

            if (taskIsSuccessfull)
            {
                //LogMessage
                return new ControlElement(automationElement);
            }

            //Logmessage
            return new ControlElement(null);
        }

    }
}
