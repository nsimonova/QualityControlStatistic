namespace QualityControlStatistic.Tests.Shewhart
{
    public class TestPoint<TMark>: IMeasurement<TMark, double>
    {
        public TestPoint(TMark mark, double value)
        {
            Mark = mark;
            Value = value;
        }

        public TMark Mark { get; private set; }
        public double Value { get; private set; }
    }
}