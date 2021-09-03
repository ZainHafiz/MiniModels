using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public enum Types
    {
        Forward,
        Central,
        Backward
    }

    public class FiniteDifference
    {
        readonly double bumpSize = 0.01;
        public double Calculate(double x, Func<double, double> f, Types type)
        {
            switch (type)
            {
                case Types.Forward:
                    return ForwardCalculate(x, f);
                case Types.Central:
                    return CentralCalculate(x, f);
                case Types.Backward:
                    return BackwardCalculate(x, f);
                default:
                    throw new Exception();
            }
        }

        double ForwardCalculate(double x, Func<double, double> f)
        {
            return ((f(x + bumpSize) - f(x)) / bumpSize);
        }

        double CentralCalculate(double x, Func<double, double> f)
        {
            var result = ((f(x + bumpSize) - f(x - bumpSize)) / (2 * bumpSize));
            return result;
        }

        double BackwardCalculate(double x, Func<double, double> f)
        {
            return (f(x) - f(x - bumpSize) / bumpSize);
        }
    }
}
