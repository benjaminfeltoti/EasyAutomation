﻿
using EasyAutomation.AutomationFramework.Core;
using EasyAutomation.AutomationFramework.Utility;
using EasyAutomation.ExampleTests.CalculatorApp.Views;
using System;
using System.Threading;
using System.Globalization;
using System.Diagnostics;

namespace EasyAutomation.ExampleTests.CalculatorApp.Tests
{
    public class StandardCalculatorTests
    {
        Process application;
        private StandardCalculatorView standardCalculatorView;
        private string applicationName;

        public StandardCalculatorTests()
        {
            Setup();

            try
            {
                TestThatStandardCalculatorViewButtonsCanBeClicked();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CleanUp();
            }
        }

        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            application = Process.Start("C:\\Windows\\System32\\calc.exe");
            application.Refresh();
            applicationName = application.ProcessName;
            application.WaitForInputIdle();

            standardCalculatorView = new StandardCalculatorView();
        }

        public void CleanUp()
        {
            Console.WriteLine("Cleanup");

            //standardCalculatorView.Close();           
        }

        public void TestThatStandardCalculatorViewButtonsCanBeClicked()
        {/*
            //Has to be in standard calc mode

            // Press 1
            MouseActions.SetCursorPos((int)standardCalculatorView.OneButton.Current.BoundingRectangle.X + 15,
                (int)standardCalculatorView.OneButton.Current.BoundingRectangle.Y + 15);
            
            MouseActions.DoMouseClick((uint)standardCalculatorView.OneButton.Current.BoundingRectangle.X,
                (uint)standardCalculatorView.OneButton.Current.BoundingRectangle.Y);

            //Assert if it is 1.

            if (Try.Until(() => standardCalculatorView.CalculatorResults.Current.Name == "Display is 1"))
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Failed.");
            }   */         
        }
    }
}

