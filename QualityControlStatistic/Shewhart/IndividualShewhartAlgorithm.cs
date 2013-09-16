using System;
using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart
{
    public abstract class IndividualShewhartAlgorithm<TMark> : ShewhartAlgorithm<TMark>
    {
        public abstract void Calculate(IEnumerable<IMeasurement<TMark, double>> individualValues, IChartBuilder<TMark> chartBuilder);

        public double[] GetSlideDifferences(double[] individualValues)
        {
            double[] result = new double[individualValues.Length - 1];
            int current = 0;
            double previousValue = 0;
            bool isFirstIteration = true;
            foreach (double value in individualValues)
            {
                if (isFirstIteration)
                {
                    previousValue = value;
                    isFirstIteration = false;
                    continue;
                }

                result[current] = Math.Abs(value - previousValue);
                ++current;
            }

            return result;
        }
    }
}