using QualityControlStatistic.Shewhart.Coefficients;

namespace QualityControlStatistic.Shewhart
{
    public abstract class ShewhartAlgorithm<TMark, TResult>
    {
        protected ShewhartAlgorithm(IChartBuilder<TMark, TResult> chartBuilder)
        {
            this.chartBuilder = chartBuilder;
        }

        protected IShewhartCoefficientsTable coefficients;
        protected IChartBuilder<TMark, TResult> chartBuilder;
    }
}