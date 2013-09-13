namespace QualityControlStatistic.Shewhart.Coefficients
{
    public interface IShewhartCoefficientsTable
    {
        double A2(int groupSize);
        double A4(int groupSize);
        double D3(int groupSize);
        double D4(int groupSize);
        double d2(int groupSize);
    }
}