using System;
using System.Collections.Generic;

namespace QualityControlStatistic.Shewhart
{
    public abstract class GroupShewhartAlgorithm<TMark> : ShewhartAlgorithm<TMark>
    {
        public abstract void Calculate(IEnumerable<IMeasurement<TMark, double[]>> groupValues, int groupSize, IChartBuilder<TMark> chartBuilder);

        protected void ValidateSize(IMeasurement<TMark, double[]> values, int minimumSize, int orderGroupNumber)
        {
            if (values.Value.Length < minimumSize)
            {
                throw new ArgumentException("Actual size of group " + orderGroupNumber + " is less than specified group size", "minimumSize");
            }
        }
    }
}