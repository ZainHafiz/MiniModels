using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tester
{
    public class FunctionTimer
    {
        public static O RunTimedFunction<I, O>(Func<I, O> f, I input , out double time)
        {
            Stopwatch sw = new();
            sw.Start();
            O ret = f(input);
            sw.Stop();
            time = sw.Elapsed.TotalSeconds;
            return ret;
        }
    }
}
