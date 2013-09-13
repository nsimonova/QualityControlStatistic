namespace QualityControlStatistic
{
    public interface IMeasurement<out TMark, out TValue>
    {
        TMark Mark { get; }
        TValue Value { get; }
    }
}