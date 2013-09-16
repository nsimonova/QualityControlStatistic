using System.Collections.Generic;
using System.IO;

namespace QualityControlStatistic.Shewhart.Group
{
    public class AverageValuesGroupShewhartAlgorithm<TMark> : GroupShewhartAlgorithm<TMark>
    {
        public override void Calculate(IEnumerable<IMeasurement<TMark, double[]>> groupValues, int groupSize, IChartBuilder<TMark> chartBuilder)
        {
            double totalDifference = 0;
            double totalAverage = 0;

            int totalGroupsCount = 0;

            foreach (var measurementsInGroup in groupValues)
            {
                ValidateSize(measurementsInGroup, groupSize, totalGroupsCount);

                double groupAverage = StatisticFunctions.ArithmeticAverage(measurementsInGroup.Value);
                totalAverage += groupAverage;

                double groupDifference = StatisticFunctions.GetDifference(measurementsInGroup.Value);
                totalDifference += groupDifference;

                chartBuilder.AddMeasurement(measurementsInGroup.Mark, groupAverage);

                ++totalGroupsCount;
            }

            totalAverage /= totalGroupsCount;
            totalDifference /= totalGroupsCount;

            chartBuilder.CentralLine = totalAverage;
            chartBuilder.UpperControlLevel = totalAverage + coefficients.A2(groupSize)*totalDifference;
            chartBuilder.LowerControlLevel = totalAverage - coefficients.A2(groupSize)*totalDifference;

        }
    }
}