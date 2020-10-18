using EasyAutomation.AutomationFramework.Logging;
using System;
using System.Threading;

namespace EasyAutomation.AutomationFramework.Test
{
    public static class Assert
    {
        public static void IsTrue(Func<uint, bool> method, uint timeout = 5000, uint checkInterval = 300)
        {
            bool actionResult = false;
            var startTime = DateTime.Now;
            var timeoutLimit = (double)timeout;

            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeoutLimit && actionResult == false)
            {
                actionResult = method.Invoke(timeout);
                Thread.Sleep((int)checkInterval);
            }

            if (actionResult)
            {
                Log.Write("Successful Assertion : IsTrue : Successfully asserted that arranged value was true!", TextType.SuccessfulAssertion);
                return;
            }

            Log.Write("ERROR : AssertionFailed : IsTrue : Asserting that arranged value was true failed!", TextType.Failed);
            throw new Exception("ERROR : AssertionFailed : IsTrue : Asserting that arranged value was true failed!");
        }

        public static void IsFalse(Func<uint, bool> method, uint timeout = 5000, uint checkInterval = 300)
        {
            bool actionResult = true;
            var startTime = DateTime.Now;
            var timeoutLimit = (double)timeout;

            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeoutLimit && actionResult == true)
            {
                actionResult = method.Invoke(timeout);
                Thread.Sleep((int)checkInterval);
            }

            if (!actionResult)
            {
                Log.Write("Successful Assertion : IsFalse : Successfully asserted that arranged value was false!", TextType.SuccessfulAssertion);
                return;
            }

            Log.Write("ERROR : AssertionFailed : IsFalse : Asserting that arranged value was false failed!", TextType.Failed);
            throw new Exception("ERROR : AssertionFailed : IsFalse : Asserting that arranged value was false failed!");
        }

        public static void Equal<T>(Func<uint, T> method1, Func<uint, T> method2, uint timeout = 5000, uint checkInterval = 300)
        {
            bool methodsAreEqual = false;
            var startTime = DateTime.Now;
            var timeoutLimit = (double)timeout;

            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeoutLimit && methodsAreEqual == false)
            {
                var result1 = method1.Invoke(timeout);
                var result2 = method2.Invoke(timeout);

                methodsAreEqual = result1.Equals(result2);
                Thread.Sleep((int)checkInterval);
            }

            if (methodsAreEqual)
            {
                Log.Write("Successful Assertion : Equal : Successfully asserted that arranged values are equal!", TextType.SuccessfulAssertion);
                return;
            }

            Log.Write("ERROR : AssertionFailed : Equal : Asserting that arranged values are equal has failed!", TextType.Failed);
            throw new Exception("ERROR : AssertionFailed : Equal : Asserting that arranged values are equal has failed!");
        }

        public static void Equal<T>(Func<uint, T> predicate, T value, uint timeout = 5000, uint checkInterval = 300)
        {
            bool predicateEqualsValue = false;
            var startTime = DateTime.Now;
            var timeoutLimit = (double)timeout;

            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeoutLimit && predicateEqualsValue == false)
            {
                var result1 = predicate.Invoke(timeout);

                predicateEqualsValue = result1.Equals(value);
                Thread.Sleep((int)checkInterval);
            }

            if (predicateEqualsValue)
            {
                Log.Write($"Successful Assertion : Equal : Successfully asserted that predicate equals {value.ToString()}!", TextType.SuccessfulAssertion);
                return;
            }

            Log.Write("ERROR : AssertionFailed : Equal : Asserting that arranged values are equal has failed!", TextType.Failed);
            throw new Exception("ERROR : AssertionFailed : Equal : Asserting that arranged values are equal has failed!");
        }
    }
}
