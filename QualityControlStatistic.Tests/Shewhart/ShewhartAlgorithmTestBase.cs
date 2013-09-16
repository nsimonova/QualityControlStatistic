using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QualityControlStatistic.Tests.Shewhart
{
    public class ShewhartAlgorithmTestBase
    {
        protected static double precision = 0.0001;

        protected static void AssertWithPrecision(double expected, double actual)
        {
            Assert.AreEqual(expected, actual, precision);
        }
    }
}