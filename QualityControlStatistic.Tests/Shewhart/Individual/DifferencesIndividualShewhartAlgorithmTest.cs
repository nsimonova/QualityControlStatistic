using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualityControlStatistic.Shewhart.Individual;

namespace QualityControlStatistic.Tests.Shewhart.Individual
{
    [TestClass]
    public class DifferencesIndividualShewhartAlgorithmTest : IndividualShewhartAlgorithmTestBase
    {
        [TestMethod]
        public void Test()
        {
            DifferencesIndividualShewhartAlgorithm<int> algorithm = new DifferencesIndividualShewhartAlgorithm<int>();
            TestShewhartChartBuilder builder = new TestShewhartChartBuilder();
            algorithm.Calculate(wrappedMeasurements, builder);
            TestShewhartResult result = builder.Build();

            AssertWithPrecision(0.3, result.Points[0].Value);
            AssertWithPrecision(0.5, result.Points[3].Value);
            AssertWithPrecision(0.1, result.Points[8].Value);

            AssertWithPrecision(0.38, result.CentralLine);
            AssertWithPrecision(1.24, result.UpperControlLevel);
            AssertWithPrecision(0, result.LowerControlLevel);
        }
    }
}
