namespace QualityControlStatistic
{
    public interface IChartBuilder<in TMark>
    {
        void AddMeasurement(TMark mark, double value);

        double CentralLine { set; }
        double UpperControlLevel { set; }
        double LowerControlLevel { set; }
    }

    public interface IChartBuilder<in TMark, out TResult> : IChartBuilder<TMark>
    {
        TResult Build();
    }
}