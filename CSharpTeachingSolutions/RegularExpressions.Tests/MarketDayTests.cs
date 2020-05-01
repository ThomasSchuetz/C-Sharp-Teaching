using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RegularExpressions.Tests
{
    [TestClass]
    public class MarketDayTests
    {
        [TestMethod]
        public void TryParse_returns_false_for_the_header_row()
        {
            var testData = "Date,Open,High,Low,Close,Adj Close,Volume";
            var result = MarketDay.TryParse(testData, out _);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_returns_false_for_null_rows()
        {
            var testData = "2019-05-05,null,null,null,null,null,null";
            var result = MarketDay.TryParse(testData, out _);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_returns_true_for_a_regular_data_row()
        {
            var testData = "2020-04-30,1729.500000,1737.000000,1687.500000,1695.400024,1695.400024,110088974";
            var result = MarketDay.TryParse(testData, out MarketDay marketDay);

            var accuracy = 0.001;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2020, 4, 30), marketDay.Date);
            Assert.AreEqual(1729.5, (double)marketDay.Open, accuracy);
            Assert.AreEqual(1737, (double)marketDay.High, accuracy);
            Assert.AreEqual(1687.5, (double)marketDay.Low, accuracy);
            Assert.AreEqual(1695.400024, (double)marketDay.Close, accuracy);
            Assert.AreEqual(1695.400024, (double)marketDay.AdjClose, accuracy);
            Assert.AreEqual(110088974, (double)marketDay.Volume, accuracy);
        }
    }
}
