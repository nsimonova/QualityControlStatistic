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
                if (isFirst)
                {
                    previousValue = measurement.Value;
                    isFirst = false;
                    continue;
                }

                totalAverage += measurement.Value;

                double groupDifference = measurement.Value - previousValue;
                totalDifference += groupDifference;

                chartBuilder.AddMeasurement(measurement.Mark, measurement.Value);

                ++totalGroupsCount;
            }

            totalAverage /= totalGroupsCount;
            totalDifference /= totalGroupsCount;

            chartBuilder.CentralLine = totalAverage;
            chartBuilder.UpperControlLevel = totalAverage + (3 / coefficients.d2(2)) * totalDifference;
            chartBuilder.LowerControlLevel = totalAverage - (3 / coefficients.d2(2)) * totalDifference;
        }
    }
}