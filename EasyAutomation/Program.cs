using AutomationFramework.Core;
using AutomationFramework.Test;
using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.ExampleTests;
using EasyAutomation.ExampleTests.CalculatorApp.Tests;
using System;

namespace EasyAutomation
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
            ControlElement control = Desktop.Root.FindDescendantByName("FirstNameTextBox");

            Log.Write(control.Name(), TextType.FatalError);
            Log.Write(control.ClassName(), TextType.Error);
            Log.Write(control.AutomationId(), TextType.SuccessfulAct);
            Log.Write(control.HelpText(), TextType.SuccessfulAssertion);
            Log.Write(control.ControlType().ToString());
            Log.Write(control.LocalizedControlType());
            Log.Write(control.BoundingRectangle().Width.ToString());
            Log.Write(control.IsEnabled().ToString());
            Log.Write(control.IsOffScreen().ToString());
            */
            TestRunner testRunner = new TestRunner();
            testRunner.RunTests(new ITestClass[1] { new ExampleWinformsApplicationTests() });

            Console.WriteLine("End");

            Console.ReadLine();
        }        
    }
}