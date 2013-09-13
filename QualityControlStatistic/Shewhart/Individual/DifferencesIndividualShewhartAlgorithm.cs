using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart.Individual
{
    public class DifferencesIndividualShewhartAlgorithm<TMark, TResult> : IndividualShewhartAlgorithm<TMark, TResult>
    {
        public DifferencesIndividualShewhartAlgorithm(IChartBuilder<TMark, TResult> chartBuilder) : base(chartBuilder)
        {
        }

        public override TResult Calculate(IEnumerable<IMeasurement<TMark, double>> individualValues)
        {
            double totalDifference = 0;
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

                double currentDifference = measurement.Value - previousValue;
                totalDifference += currentDifference;

                chartBuilder.AddMeasurement(measurement.Mark, currentDifference);

                ++totalGroupsCount;
            }

            totalDifference /= totalGroupsCount;

            chartBuilder.CentralLine = totalDifference;
            chartBuilder.UpperControlLevel = coefficients.D4(2) * totalDifference;
            chartBuilder.LowerControlLevel = coefficients.D3(2) * totalDifference;

            return chartBuilder.Build();
        }
    }
}
