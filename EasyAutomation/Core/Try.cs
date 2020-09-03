using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyAutomation.Core
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
                    }
                    catch (Exception)
                    {
                        //LogMessage
                        throw;
                    }

                    Thread.Sleep(checkInterval);
                }

                return predicateResult;

            }, taskCancellationToken.Token);

            bool taskIsSuccessfull = task.Wait(limit);
            
            taskCancellationToken.Cancel();
            taskCancellationToken.Dispose();
            task.Dispose();

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
