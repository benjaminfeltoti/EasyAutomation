using AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.ExampleTests;
using System;

namespace EasyAutomation
{
    class Program
    {
        public static void Main(string[] args)
        {
            ControlElement control = Desktop.Root.FindDescendantByName("FirstNameTextBox");

            Console.WriteLine(control.Name());
            Console.WriteLine(control.ClassName());
            Console.WriteLine(control.AutomationId());
            Console.WriteLine(control.HelpText());
            Console.WriteLine(control.ControlType());
            Console.WriteLine(control.LocalizedControlType());
            Console.WriteLine(control.BoundingRectangle().Width);
            Console.WriteLine(control.IsEnabled());
            Console.WriteLine(control.IsOffScreen());


            //TestRunner testRunner = new TestRunner();

            Console.ReadLine();
        }        
    }
}