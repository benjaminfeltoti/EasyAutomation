using AccGett.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccGett
{
    public class TestRunner
    {
        public TestRunner()
        {
            StandartCalculatorTests standardCalcTests = new StandartCalculatorTests();
            //Activator.CreateInstance("AccGett.Tests.StandartCalculatorTests", "StandartCalculatorTests");            
        }
    }
}
