using System;
using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart.Group
{
    public class MedianGroupShewhartAlgorithm<TMark> : GroupShewhartAlgorithm<TMark>
    {
        public override void Calculate(IEnumerable<IMeasurement<TMark, double[]>> groupValues, int groupSize, IChartBuilder<TMark> chartBuilder)
        {
            double totalDifference = 0;
            double totalMedian = 0;
            int totalGroupsCount = 0;

            foreach (IMeasurement<TMark, double[]> measurementsInGroup in groupValues)
            {
                ValidateSize(measurementsInGroup, groupSize, totalGroupsCount);

                double groupMedian = StatisticFunctions.Median(measurementsInGroup.Value);
                totalMedian += groupMedian;

                double groupDifference = StatisticFunctions.GetDifference(measurementsInGroup.Value);
                totalDifference += groupDifference;

                chartBuilder.AddMeasurement(measurementsInGroup.Mark, groupMedian);

                ++totalGroupsCount;
            }

            totalMedian /= totalGroupsCount;
            totalDifference /= totalGroupsCount;

            chartBuilder.CentralLine = totalMedian;
            chartBuilder.UpperControlLevel = totalMedian + coefficients.A4(groupSize) * totalDifference;
            chartBuilder.LowerControlLevel = totalMedian - coefficients.A4(groupSize) * totalDifference;
        }
    }
}