namespace QualityControlStatistic.Tests.Shewhart.Individual
{
    public class TestIndividualMeasurement : IMeasurement<int, double>
    {
        public TestIndividualMeasurement(int mark, double value)
        {
            Mark = mark;
            Value = value;
        }

        public int Mark { get; private set; }
        public double Value { get; private set; }
    }
}
