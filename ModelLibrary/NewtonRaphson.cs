using System;

namespace ModelLibrary
{
    public class NewtonRaphson
    {
        static readonly double tolerance = 0.001;
        static ulong count = 0;
        public static (double, ulong) Solve(double guess, Func<double,double> f, Func<double, double> f_Deriv)
        {
            if (Math.Abs(f(guess)) <= tolerance)
            {
                var tempCount = count;
                count = 0;
                return (guess, tempCount);
            }
            double newGuess = guess - (f(guess) / f_Deriv(guess));
            count++;
            return Solve(newGuess, f, f_Deriv);
            
        }
    }
}
