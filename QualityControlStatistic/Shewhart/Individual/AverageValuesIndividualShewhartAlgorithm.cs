using System;
using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart.Individual
{
    public class AverageValuesIndividualShewhartAlgorithm<TMark> : IndividualShewhartAlgorithm<TMark>
    {
        public override void Calculate(IEnumerable<IMeasurement<TMark, double>> individualValues, IChartBuilder<TMark> chartBuilder)
        {
            double totalDifference = 0;
            double totalAverage = 0;
            double previousValue = 0;

            int totalGroupsCount = 0;

            bool isFirst = true;

            foreach (IMeasurement<TMark, double> measurement in individualValues)
            {
                chartBuilder.AddMeasurement(measurement.Mark, measurement.Value);
                totalAverage += measurement.Value;

                ++totalGroupsCount;
                if (isFirst)
                {
                    previousValue = measurement.Value;
                    isFirst = false;
                    continue;
                }

                double groupDifference = Math.Abs(measurement.Value - previousValue);
                totalDifference += groupDifference;
                previousValue = measurement.Value;
            }

            totalAverage /= totalGroupsCount;
            totalDifference /= (totalGroupsCount - 1);

            chartBuilder.CentralLine = totalAverage;
            chartBuilder.UpperControlLevel = totalAverage + (3 / coefficients.d2(2)) * totalDifference;
            chartBuilder.LowerControlLevel = totalAverage - (3 / coefficients.d2(2)) * totalDifference;
        }
    }
}