using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualityControlStatistic.Shewhart.Group;

namespace QualityControlStatistic.Tests.Shewhart.Group.RussianStateStandartsExamples
{
    [TestClass]
    public class AverageValuesGroupShewhartAlgorithmTest : GroupShewhartAlgorithmTestBase
    {
        [TestMethod]
        public void Test()
        {
            AverageValuesGroupShewhartAlgorithm<int, TestShewhartResult> algotithm = new AverageValuesGroupShewhartAlgorithm<int, TestShewhartResult>(new TestShewhartChartBuilder());
            TestShewhartResult result = algotithm.Calculate(wrappedMeasurements, 4);

            AssertWithPrecision(0.1924, result.CentralLine);
            AssertWithPrecision(0.2133, result.UpperControlLevel);
            AssertWithPrecision(0.1715, result.LowerControlLevel);

            AssertWithPrecision(0.1898, result.Points[0].Value);
            AssertWithPrecision(0.1949, result.Points[10].Value);
            AssertWithPrecision(0.16655, result.Points[19].Value);

            Assert.AreEqual(20, result.Points[19].Mark);
        }
    }
}
