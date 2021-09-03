using System;
using SquareRootSolver;

namespace SquareRootSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Method method = Method.NewtonRaphson;
                Console.WriteLine("What solver do you want to use?");
                if (Console.ReadLine().ToLower().Contains("b"))
                    method = Method.Bisection;
                Console.WriteLine($"What number do you want to square root (using the {method} method)?");
                double number;
                if (Double.TryParse(Console.ReadLine(), out number))
                {
                    
                    var result = SquareRootSolver.Solve(number, method);
                    Console.WriteLine($"The Square Root is {result.Item1} and it took {result.Item2} iteration(s)");
                }
            }
            
        }
    }
}
