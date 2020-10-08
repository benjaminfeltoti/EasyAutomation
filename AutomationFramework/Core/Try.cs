using System;
using System.Threading;
using System.Threading.Tasks;

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
    }
}
