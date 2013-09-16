using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QualityControlStatistic.Tests.Shewhart.Individual
{
    public class IndividualShewhartAlgorithmTestBase : ShewhartAlgorithmTestBase
    {
        protected double[] measurements = new[] { 2.9, 3.2, 3.6, 4.3, 3.8, 3.5, 3.0, 3.1, 3.6, 3.5 };
        protected TestIndividualMeasurement[] wrappedMeasurements;

        [TestInitialize]
        public void SetUp()
        {
            precision = 0.01;
            int measurementNumber = 0;
            wrappedMeasurements = measurements.Select(x => {
                ++measurementNumber;
                return new TestIndividualMeasurement(measurementNumber, x);
            }).ToArray();
        }
    }
}