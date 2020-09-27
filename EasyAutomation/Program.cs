using AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Logging;
using EasyAutomation.ExampleTests;
using System;

namespace EasyAutomation
{
    class Program
    {
        public static void Main(string[] args)
        {
            ControlElement control = Desktop.Root.FindDescendantByName("FirstNameTextBox");

            Log.Write(control.Name(), TextType.FatalError, 1);
            Log.Write(control.ClassName(), TextType.Error, 4);
            Log.Write(control.AutomationId(), TextType.Header, 3);
            Log.Write(control.HelpText(), TextType.Success, 2);
            Log.Write(control.ControlType().ToString());
            Log.Write(control.LocalizedControlType());
            Log.Write(control.BoundingRectangle().Width.ToString());
            Log.Write(control.IsEnabled().ToString());
            Log.Write(control.IsOffScreen().ToString());

            //TestRunner testRunner = new TestRunner();

            Console.ReadLine();
        }        
    }
}