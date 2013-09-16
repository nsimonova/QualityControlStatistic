using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart.Group
{
    public class DifferencesGroupShewhartAlgorithm<TMark> : GroupShewhartAlgorithm<TMark>
    {
        public override void Calculate(IEnumerable<IMeasurement<TMark, double[]>> groupValues, int groupSize, IChartBuilder<TMark> chartBuilder)
        {
            double totalDifference = 0;
            int totalGroupsCount = 0;

            foreach (IMeasurement<TMark, double[]> measurementsInGroup in groupValues)
            {
                ValidateSize(measurementsInGroup, groupSize, totalGroupsCount);

                double groupDifference = StatisticFunctions.GetDifference(measurementsInGroup.Value);
                totalDifference += groupDifference;

                chartBuilder.AddMeasurement(measurementsInGroup.Mark, groupDifference);

                ++totalGroupsCount;
            }

            totalDifference /= totalGroupsCount;

            chartBuilder.CentralLine = totalDifference;
            chartBuilder.UpperControlLevel = coefficients.D4(groupSize) * totalDifference;
            chartBuilder.LowerControlLevel = coefficients.D3(groupSize) * totalDifference;
        }
    }
}