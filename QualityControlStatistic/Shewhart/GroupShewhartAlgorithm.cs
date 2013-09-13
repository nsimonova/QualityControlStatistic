using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart
{
    public abstract class GroupShewhartAlgorithm<TMark, TResult> : ShewhartAlgorithm<TMark, TResult>
    {
        protected GroupShewhartAlgorithm(IChartBuilder<TMark, TResult> chartBuilder) : base(chartBuilder)
        {
        }

        public abstract TResult Calculate(IEnumerable<IMeasurement<TMark, double[]>> groupValues, int groupSize);
    }
}