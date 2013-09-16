using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualityControlStatistic.Shewhart;

namespace QualityControlStatistic.Tests.Shewhart.Group.RussianStateStandartsExamples
{
    public class GroupShewhartAlgorithmTestBase
    {
        protected TestGroupMeasurement[] wrappedMeasurements;

        [TestInitialize]
        public virtual void SetUp()
        {
            int groupNumber = 0;
            wrappedMeasurements = measurements.Select(x =>
                {
                    ++groupNumber;
                    return new TestGroupMeasurement(groupNumber, x);
                })
            .ToArray();
        }

        protected double[][] measurements = new[] {
            new[] {0.1898, 0.1729, 0.2067, 0.1898 },
            new[] {0.2012, 0.1913, 0.1878, 0.1921 },
            new[] {0.2217, 0.2192, 0.2078, 0.1980 },
            new[] {0.1832, 0.1812, 0.1963, 0.1800 },
            new[] {0.1692, 0.2263, 0.2066, 0.2091 },
            new[] {0.1621, 0.1832, 0.1914, 0.1783 },
            new[] {0.2001, 0.1937, 0.2169, 0.2082 },
            new[] {0.2401, 0.1825, 0.1910, 0.2264 },
            new[] {0.1996, 0.1980, 0.2076, 0.2023 },
            new[] {0.1783, 0.1715, 0.1829, 0.1961 },
            new[] {0.2166, 0.1748, 0.1960, 0.1923 },
            new[] {0.1924, 0.1984, 0.2377, 0.2003 },
            new[] {0.1768, 0.1986, 0.2241, 0.2022 },
            new[] {0.1923, 0.1876, 0.1903, 0.1986 },
            new[] {0.1924, 0.1996, 0.2120, 0.2160 },
            new[] {0.1720, 0.1940, 0.2116, 0.2320 },
            new[] {0.1824, 0.1790, 0.1876, 0.1821 },
            new[] {0.1812, 0.1585, 0.1699, 0.1680 },
            new[] {0.1700, 0.1567, 0.1694, 0.1702 },
            new[] {0.1698, 0.1664, 0.1700, 0.1600 }
        };

        protected static double precision = 0.0001;

        protected static void AssertWithPrecision(double expected, double actual)
        {
            Assert.AreEqual(expected, actual, precision);
        }

        protected TestShewhartResult ExecuteAlgorithm<TAlgorithm>(int groupSize) where TAlgorithm : GroupShewhartAlgorithm<int>, new()
        {
            TestShewhartChartBuilder chartBuilder = new TestShewhartChartBuilder();
            TAlgorithm algorithm = new TAlgorithm();
            algorithm.Calculate(wrappedMeasurements, groupSize, chartBuilder);

            TestShewhartResult result = chartBuilder.Build();

            return result;
        }
    }
}