using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyAutomation.AutomationFramework.Core
{
    internal static class Arrange<T>
    {
        public static T Get(Func<T> predicate, uint timeLimit = 5000)
        {
            var limit = TimeSpan.FromMilliseconds(timeLimit);

            var taskCancellationToken = new CancellationTokenSource();

            var task = Task.Factory.StartNew(() =>
            {
                try
                {
                    var predicateResult = predicate.Invoke();
                    return predicateResult;
                }
                catch (Exception e)
                {
                    //LogMessage
                    Console.WriteLine(e.Message);
                    throw;
                }

            }, taskCancellationToken.Token);

            var result = task.Result;
            bool taskIsSuccessfull = task.Wait(limit);

            taskCancellationToken.Cancel();
            taskCancellationToken.Dispose();
            task.Dispose();

            if (taskIsSuccessfull)
            {
                //LogMessage
                return result;
            }

            //Logmessage
            throw null;
        }
    }
}
