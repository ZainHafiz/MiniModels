using System;
using ModelLibrary;

namespace SquareRootSolver
{
    public enum Method
    {
        Bisection,
        NewtonRaphson
    }
    public class SquareRootSolver
    {
        static readonly double tolerance = 0.0001;
        public static (double, ulong) Solve(double x, Method method)
        {
            if (x == 1.0 || x == 0.0)
                return (x, 1);
            else if (x < 0.0)
            {
                Console.WriteLine("Number can't be negative");
                return (-1, 1);
            }
            else
            {
                switch (method)
                {
                    case Method.Bisection:
                        return SolveBisectionMethod(x);
                    case Method.NewtonRaphson:
                        return SolveNewtonRaphsonMethod(x);
                    default:
                        throw new Exception();
                }
            }
        }


        static (double, ulong) SolveBisectionMethod(double x)
        {
            ulong count = 1;
            double lB = 0;
            double uB = Math.Max(1, x);
            double guess = (lB + uB) / 2;
            while (Math.Abs(guess*guess-x) > tolerance)
            {
                if (guess * guess > x)
                    uB = guess;
                else
                    lB = guess;
                guess = (uB + lB) / 2;
                count++;
            }
            return (guess,count);
            
        }
        static (double, ulong) SolveNewtonRaphsonMethod(double x)
        {
            double seed = x > 1 ? x/2 : 0.5;
            Func<double, double> f = (S => S * S - x);
            Func<double, double> f_Deriv = (S => 2 * S);
            return NewtonRaphson.Solve(seed, f, f_Deriv);
        }
    }
}
