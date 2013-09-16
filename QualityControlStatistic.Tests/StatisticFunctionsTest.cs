using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QualityControlStatistic.Tests
{
    [TestClass]
    public class StatisticFunctionsTest
    {
        [TestMethod]
        public void Median_WhenLengthIsEven()
        {
            TestMedian(7.5, 8, 7, 4, 10);
        }

        [TestMethod]
        public void Median_WhenLengthIsOdd()
        {
            TestMedian(7, 4, 8, 7);
        }

        [TestMethod]
        public void Median_WhenLengthIsTwo()
        {
            TestMedian(6, 4, 8);
        }

        [TestMethod]
        public void Median_WhenLengthIsOne()
        {
            TestMedian(2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Median_WhenLengthIsZero()
        {
            TestMedian(1);
        }

        [TestMethod]
        public void Average_Standart()
        {
            double actualAverage = StatisticFunctions.ArithmeticAverage(new double[] {1, 2, 3});
            Assert.AreEqual(2, actualAverage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Average_WhenLengthIsZero()
        {
            StatisticFunctions.ArithmeticAverage(new double[] {});
        }

        [TestMethod]
        public void Difference_Standart()
        {
            double actualDifference = StatisticFunctions.GetDifference(new double[] {5, 7, 8, 11, 15});
            Assert.AreEqual(10, actualDifference);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Difference_WhenLengthIsZero()
        {
            StatisticFunctions.GetDifference(new double[] { });
        }

        private static void TestMedian(double expectedMedian, params double[] array)
        {
            double actualMedian = StatisticFunctions.Median(array);
            Assert.AreEqual(expectedMedian, actualMedian);
        }
    }
}
