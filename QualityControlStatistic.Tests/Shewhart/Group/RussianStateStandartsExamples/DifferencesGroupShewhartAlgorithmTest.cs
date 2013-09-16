using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualityControlStatistic.Shewhart.Group;

namespace QualityControlStatistic.Tests.Shewhart.Group.RussianStateStandartsExamples
{
    [TestClass]
    public class DifferencesGroupShewhartAlgorithmTest : GroupShewhartAlgorithmTestBase
    {
        [TestMethod]
        public void Test()
        {
            precision = 0.001;

            DifferencesGroupShewhartAlgorithm<int, TestShewhartResult> algorithm = new DifferencesGroupShewhartAlgorithm<int, TestShewhartResult>(new TestShewhartChartBuilder());
            TestShewhartResult result = algorithm.Calculate(wrappedMeasurements, 4);

            AssertWithPrecision(0.0287, result.CentralLine);
            AssertWithPrecision(0.0655, result.UpperControlLevel);
            AssertWithPrecision(0, result.LowerControlLevel);

            AssertWithPrecision(0.0338, result.Points[0].Value);
            AssertWithPrecision(0.0418, result.Points[10].Value);
            AssertWithPrecision(0.01, result.Points[19].Value);
        }
    }
}
