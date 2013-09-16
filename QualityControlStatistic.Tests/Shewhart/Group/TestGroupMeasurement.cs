namespace QualityControlStatistic.Tests.Shewhart.Group
{
    public class TestGroupMeasurement : IMeasurement<int, double[]>
    {
        public TestGroupMeasurement(int groupNumber, params double[] values)
        {
            this.Mark = groupNumber;
            this.Value = values;
        }

        public int Mark { get; private set; }
        public double[] Value { get; private set; }
    }
}
