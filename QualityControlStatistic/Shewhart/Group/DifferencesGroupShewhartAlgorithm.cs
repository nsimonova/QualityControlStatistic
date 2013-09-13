using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart.Group
{
    public class DifferencesGroupShewhartAlgorithm<TMark, TResult> : GroupShewhartAlgorithm<TMark, TResult>
    {
        public DifferencesGroupShewhartAlgorithm(IChartBuilder<TMark, TResult> chartBuilder) : base(chartBuilder)
        {
        }

        public override TResult Calculate(IEnumerable<IMeasurement<TMark, double[]>> groupValues, int groupSize)
        {
            double totalDifference = 0;
            int totalGroupsCount = 0;

            foreach (IMeasurement<TMark, double[]> measurementsInGroup in groupValues)
            {
                double groupDifference = StatisticFunctions.GetAbsoluteDifference(measurementsInGroup.Value);
                totalDifference += groupDifference;

                chartBuilder.AddMeasurement(measurementsInGroup.Mark, groupDifference);

                ++totalGroupsCount;
            }

            totalDifference /= totalGroupsCount;

            chartBuilder.CentralLine = totalDifference;
            chartBuilder.UpperControlLevel = coefficients.D3(groupSize) * totalDifference;
            chartBuilder.LowerControlLevel = coefficients.D4(groupSize) * totalDifference;

            return chartBuilder.Build();   
        }
    }
}