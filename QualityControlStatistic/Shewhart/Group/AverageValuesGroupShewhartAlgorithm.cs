using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart.Group
{
    public class AverageValuesGroupShewhartAlgorithm<TMark, TResult> : GroupShewhartAlgorithm<TMark, TResult>
    {
        public AverageValuesGroupShewhartAlgorithm(IChartBuilder<TMark, TResult> chartBuilder) : base(chartBuilder)
        {
        }

        public override TResult Calculate(IEnumerable<IMeasurement<TMark, double[]>> groupValues, int groupSize)
        {
            double totalDifference = 0;
            double totalAverage = 0;

            int totalGroupsCount = 0;

            foreach (var measurementsInGroup in groupValues)
            {
                double groupAverage = StatisticFunctions.ArithmeticAverage(measurementsInGroup.Value);
                totalAverage += groupAverage;

                double groupDifference = StatisticFunctions.GetAbsoluteDifference(measurementsInGroup.Value);
                totalDifference += groupDifference;

                chartBuilder.AddMeasurement(measurementsInGroup.Mark, groupAverage);

                ++totalGroupsCount;
            }

            totalAverage /= totalGroupsCount;
            totalDifference /= totalGroupsCount;

            chartBuilder.CentralLine = totalAverage;
            chartBuilder.UpperControlLevel = totalAverage + coefficients.A2(groupSize)*totalDifference;
            chartBuilder.LowerControlLevel = totalAverage - coefficients.A2(groupSize)*totalDifference;

            return chartBuilder.Build();
        }
    }
}