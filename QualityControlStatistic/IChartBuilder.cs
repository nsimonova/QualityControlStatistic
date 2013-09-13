namespace QualityControlStatistic
{
    public interface IChartBuilder<in TMark, out TResult>
    {
        void AddMeasurement(TMark mark, double value);

        double CentralLine { set; }
        double UpperControlLevel { set; }
        double LowerControlLevel { set; }

        TResult Build();
    }
}