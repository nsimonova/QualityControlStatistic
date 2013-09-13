namespace QualityControlStatistic
{
    public class Measurement<TMark> : IMeasurement<TMark, double>
    {
        public Measurement(TMark mark, double value)
        {
            Mark = mark;
            Value = value;
        }

        public TMark Mark { get; private set; }
        public double Value { get; private set; }
    }
}