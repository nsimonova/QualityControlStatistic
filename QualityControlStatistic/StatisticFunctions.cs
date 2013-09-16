using System;
using System.Linq;

namespace QualityControlStatistic
{
    public static class StatisticFunctions
    {
        public static double Median(double[] values)
        {
            ValidateArraySize(values);
            double[] sorted = values.ToArray();

            Array.Sort(sorted);
            int length = sorted.Length;

            if (0 == (length & 1))
            {
                return (sorted[length / 2 - 1] + sorted[length / 2]) / 2;
            }
            else
            {
                return sorted[length / 2];
            }
        }

        public static double ArithmeticAverage(double[] values)
        {
            ValidateArraySize(values);
            double sum = values.Sum();

            return sum/values.Length;
        }

        public static double GetDifference(double[] values)
        {
            ValidateArraySize(values);

            return values.Max() - values.Min();
        }

        private static void ValidateArraySize(double[] values)
        {
            if (0 == values.Length)
            {
                throw new ArgumentException("Values must have non-zero lenght");
            }
        }
    }
}
