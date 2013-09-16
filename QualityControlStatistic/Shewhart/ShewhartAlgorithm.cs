using QualityControlStatistic.Shewhart.Coefficients;

namespace QualityControlStatistic.Shewhart
{
    public abstract class ShewhartAlgorithm<TMark>
    {
        protected ShewhartAlgorithm()
        {
            //TODO make constructor with this parameter
            this.coefficients = new HardCodedShewhartCoefficientsTable();
        }

        protected IShewhartCoefficientsTable coefficients;
    }
}