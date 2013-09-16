using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualityControlStatistic.Shewhart.Group;

namespace QualityControlStatistic.Tests.Shewhart.Group.RussianStateStandartsExamples
{
    [TestClass]
    public class MedianGroupShewhartAlgorithmTest : GroupShewhartAlgorithmTestBase
    {
        [TestInitialize]
        public override void SetUp()
        {
            precision = 0.01;
            measurements = new[]
            {
                new double[] {14, 8, 12, 12, 8},
                new double[] {11, 10, 13, 8, 10},
                new double[] {11, 12, 16, 14, 9},
                new double[] {16, 12, 17, 15, 13},
                new double[] {15, 12, 14, 10, 7},
                new double[] {13, 8, 15, 15, 8},
                new double[] {14, 12, 13, 10, 16},
                new double[] {11, 10, 8, 16, 10},
                new double[] {14, 10, 12, 9, 7},
                new double[] {12, 10, 12, 14, 10},
                new double[] {10, 12, 8, 10, 12},
                new double[] {10, 10, 8, 8, 10},
                new double[] {8, 12, 10, 8, 10},
                new double[] {13, 8, 11, 14, 12},
                new double[] {7, 8, 14, 13, 11}
            };
            base.SetUp();
        }

        [TestMethod]
        public void Test()
        {
            TestShewhartResult result = ExecuteAlgorithm<MedianGroupShewhartAlgorithm<int>>(5);

            AssertWithPrecision(11.47, result.CentralLine);
            AssertWithPrecision(15.42, result.UpperControlLevel);
            AssertWithPrecision(7.52, result.LowerControlLevel);

            AssertWithPrecision(12, result.Points[0].Value);
            AssertWithPrecision(10, result.Points[10].Value);
            AssertWithPrecision(11, result.Points[14].Value);
            
        }
    }
}
