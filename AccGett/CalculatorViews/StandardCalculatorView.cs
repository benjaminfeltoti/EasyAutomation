using EasyAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace EasyAutomation.CalculatorViews
{
    public class StandardCalculatorView
    {
        private AutomationElement m_RootWindow;

        public StandardCalculatorView()
        {

        }

        public AutomationElement rootWindow => m_RootWindow ?? AutomationElement.RootElement.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Calculator"));

        public AutomationElement CalculatorResults => rootWindow.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByAutomationId("CalculatorResults"));

        public AutomationElement DisplayControls => rootWindow.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Display controls"));

        public AutomationElement PercentButton => DisplayControls.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Percent"));

        public AutomationElement ClearEntryButton => DisplayControls.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Clear entry"));

        public AutomationElement BackspaceButton => DisplayControls.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Backspace"));

        public AutomationElement ClearButton => DisplayControls.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Clear"));

        public AutomationElement NumberPad => rootWindow.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Number pad"));

        public AutomationElement OneButton => NumberPad.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("One"));

        public AutomationElement TwoButton => NumberPad.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Two"));

        public AutomationElement ThreeButton => NumberPad.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Three"));

        public AutomationElement FourButton => NumberPad.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Four"));

        public AutomationElement FiveButton => NumberPad.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Five"));

        public AutomationElement SixButton => NumberPad.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Six"));

        public AutomationElement SevenButton => NumberPad.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Seven"));

        public AutomationElement EightButton => NumberPad.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Eight"));

        public AutomationElement NineButton => NumberPad.FindFirst(
            TreeScope.Descendants, SearchHelper.GetConditionByName("Nine"));
    }
}
