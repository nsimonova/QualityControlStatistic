using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualityControlStatistic.Tests.Shewhart
{
    public class TestShewhartChartBuilder : IChartBuilder<int, TestShewhartResult>
    {
        public TestShewhartChartBuilder()
        {
            points = new LinkedList<TestPoint<int>>();
        }

        public void AddMeasurement(int mark, double value)
        {
            points.AddLast(new TestPoint<int>(mark, value));
        }

        public double CentralLine { set; get; }
        public double UpperControlLevel { set; get; }
        public double LowerControlLevel { set; get; }

        public TestShewhartResult Build()
        {
            return new TestShewhartResult(CentralLine, LowerControlLevel, UpperControlLevel, points.ToArray());
        }

        private LinkedList<TestPoint<int>> points;
    }
}
