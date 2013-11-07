using System;
using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart.Individual
{
    public class DifferencesIndividualShewhartAlgorithm<TMark> : IndividualShewhartAlgorithm<TMark>
    {
        public override void Calculate(IEnumerable<IMeasurement<TMark, double>> individualValues, IChartBuilder<TMark> chartBuilder)
        {
            double totalDifference = 0;
            double previousValue = 0;

            int totalGroupsCount = 0;

            bool isFirst = true;

            foreach (IMeasurement<TMark, double> measurement in individualValues)
            {
                ++totalGroupsCount;
                if (isFirst)
                {
                    previousValue = measurement.Value;
                    isFirst = false;
                    continue;
                }

                double currentDifference = Math.Abs(measurement.Value - previousValue);
                totalDifference += currentDifference;
                previousValue = measurement.Value;

                chartBuilder.AddMeasurement(measurement.Mark, currentDifference);
            }

            totalDifference /= (totalGroupsCount - 1);

            chartBuilder.CentralLine = totalDifference;
            chartBuilder.UpperControlLevel = coefficients.D4(2) * totalDifference;
            chartBuilder.LowerControlLevel = coefficients.D3(2) * totalDifference;
        }
    }
}
