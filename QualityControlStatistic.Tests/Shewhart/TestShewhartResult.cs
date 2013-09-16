using System.Collections.Generic;
using System.Linq;

namespace QualityControlStatistic.Tests.Shewhart
{
    public class TestShewhartResult
    {
        public TestShewhartResult(double centralLine, double lowerControlLevel, double upperControlLevel, IEnumerable<TestPoint<int>> points)
        {
            CentralLine = centralLine;
            LowerControlLevel = lowerControlLevel;
            Points = points.ToArray();
            UpperControlLevel = upperControlLevel;
        }

        public double CentralLine { get; private set; }
        public double UpperControlLevel { get; private set; }
        public double LowerControlLevel { get; private set; }

        public TestPoint<int>[] Points { get; private set; }
    }
}