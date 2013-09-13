using System;
using System.Linq;

namespace QualityControlStatistic
{
    public static class StatisticFunctions
    {
        public static double Median(double[] values)
        {
            if (1 == values.Length)
            {
                return values[0];
            }

            Array.Sort(values);
            int length = values.Length;

            if (0 == (length & 1))
            {
                return (values[length / 2] + values[length / 2 + 1]) / 2;
            }
            else
            {
                return values[length / 2 + 1];
            }
        }

        public static double ArithmeticAverage(double[] values)
        {
            double sum = values.Sum();

            return sum/values.Length;
        }

        public static double GetAbsoluteDifference(double[] values)
        {
            return Math.Abs(values.Max() - values.Min());
        }
    }
}
