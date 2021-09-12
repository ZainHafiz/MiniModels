using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    public class CompareAlgos
    {
        public static void Compare<I, O>((Func<I, O>, string, I)[] funcs)
        {
            foreach ((var func, var name, var input) in funcs)
            {
                O value = FunctionTimer.RunTimedFunction<I, O>(func, input, out double time);
                Console.WriteLine($"Return value is {value}");
                Console.WriteLine($"{name} took {time} seconds");
            }
        }
    }
}
