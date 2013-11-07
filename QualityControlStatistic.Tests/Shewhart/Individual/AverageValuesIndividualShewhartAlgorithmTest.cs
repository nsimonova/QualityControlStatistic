using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualityControlStatistic.Shewhart.Individual;

namespace QualityControlStatistic.Tests.Shewhart.Individual
{
    [TestClass]
    public class AverageValuesIndividualShewhartAlgorithmTest : IndividualShewhartAlgorithmTestBase
    {
        [TestMethod]
        public void Test()
        {
            AverageValuesIndividualShewhartAlgorithm<int> algorithm = new AverageValuesIndividualShewhartAlgorithm<int>();
            TestShewhartChartBuilder builder = new TestShewhartChartBuilder();
            algorithm.Calculate(wrappedMeasurements, builder);
            TestShewhartResult result = builder.Build();

            AssertWithPrecision(3.45, result.CentralLine);
            AssertWithPrecision(4.46, result.UpperControlLevel);
            AssertWithPrecision(2.44, result.LowerControlLevel);

            AssertWithPrecision(2.9, result.Points[0].Value);
            AssertWithPrecision(4.3, result.Points[3].Value);
            AssertWithPrecision(3.6, result.Points[8].Value);
        }
    }
}
