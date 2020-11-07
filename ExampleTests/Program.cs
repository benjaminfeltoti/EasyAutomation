using EasyAutomation.AutomationFramework.Test;
using EasyAutomation.ExampleTests.CalculatorApp.Tests;
using System;

namespace EasyAutomation
{
    class Program
    {
        public static void Main(string[] args)
        {
            TestRunner testRunner = new TestRunner();

            testRunner.RunTests(new ITestClass[1] { new ExampleWinformsAppTests() });

            Console.WriteLine("End");

            Console.ReadLine();
        }
    }
}