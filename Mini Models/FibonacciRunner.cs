using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;

namespace Tester
{
    class FibonacciRunner
    {

        static void Main()
        {
            int n = 45;
            (Func<int, int>, string, int)[] fibs = new (Func<int, int>, string, int)[3];
            fibs[0] = (Fibonacci.FibRec, "FibRec", n);
            fibs[1] = (Fibonacci.FibRecMemoized, "FibRecMemoized", n);
            fibs[2] = (Fibonacci.FibLinearIter, "FibLinearIter", n);
            CompareAlgos.Compare<int, int>(fibs);
            Console.ReadKey();
        }
    }
}
