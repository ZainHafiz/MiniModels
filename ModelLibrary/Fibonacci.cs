using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Fibonacci
    {
        // f(0) = 0, f(1) = 1
        // f(n) = f(n-1) + f(n-2)

        // O(n) ~ 2^n (actually phi^n)
        public static int FibRec(int n)
        {
            if (n == 1 || n == 0)
                return n;
            return (FibRec(n - 1) + FibRec(n - 2));
        }

        // O(n) = n
        static Dictionary<int, int> cache;
        static Fibonacci()
        {
            cache = new();
            cache.Add(0, 0);
            cache.Add(1, 1);
        }
        public static int FibRecMemoized(int n)
        {
            if (cache.ContainsKey(n))
                return cache[n];
            int value = FibRecMemoized(n - 1) + FibRecMemoized(n - 2);
            cache.Add(n, value);
            return value;
        }



        // O(n) = n
        public static int FibLinearIter(int n)
        {
            n++;
            int f_iMinus2 = 0;
            int f_iMinus1 = 1;
            int f_i = 0;
            for (int i = 2; i < n; i++)
            {
                f_i = f_iMinus1 + f_iMinus2;
                f_iMinus2 = f_iMinus1;
                f_iMinus1 = f_i;
            }
            return f_i;

        }
        // O(n) = n
        private static int FibLinearRecInner(int n, int f_iMinus1, int f_iMinus2)
        {
            n++;
            if (n == 1)
            {
                return f_iMinus1;
            }
            int f_i = f_iMinus1 + f_iMinus2;
            return FibLinearRecInner(n-1, f_i, f_iMinus1);
        }

        public static int FibLinearRec(int n)
        {
            return FibLinearRecInner(n, 0, 1);
        }


    }
}
