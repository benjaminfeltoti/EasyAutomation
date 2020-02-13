using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Input;

namespace EasyAutomation
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Create Concept for compiling
            //https://docs.microsoft.com/en-us/archive/msdn-magazine/2018/november/net-create-your-own-script-language-with-symbolic-delegates
            var keywords = new Dictionary<string, Func<string, string>>
            {
                ["capitalize"] = (input) =>
                {
                    return input.Replace("e", "EE");
                },
                ["replace"] = (input) =>
                {
                    return input.Replace("o", "0");
                }
            };
            string code = "capitalize replace";
            var tokens = code.Split(' ');
            var chain = new Chain<string>();
            chain.AddRange(tokens.Select(ix => keywords[ix]));
            var result = chain.Evaluate("join the revolution, capitalize and replace");
            Console.WriteLine(result);

            //TestRunner testRunner = new TestRunner();
            //Console.ReadLine();
        }        
    }

    public class Chain<T> : List<Func<T, T>>
    {
        public T Evaluate(T input)
        {
            foreach (var ix in this)
            {
                input = ix(input);
            }
            return input;
        }
    }

}