using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RegularExpressions.Tests
{
    [TestClass]
    public class MarketDataReaderTest
    {
        [TestMethod]
        public void Market_data_is_parsed_correctly()
        {
            var testData = "Date,Open,High,Low,Close,Adj Close,Volume\n" +
                           "2019-05-01,1278.699951,1283.300049,1278.699951,1281.400024,1281.400024,114\n" +
                           "2019-05-02,1269.199951,1270.800049,1266.599976,1269.699951,1269.699951,70\n" +
                           "2019-05-03,1270.099976,1279.199951,1270.099976,1279.199951,1279.199951,63\n" +
                           "2019-05-05,null,null,null,null,null,null\n" +
                           "2019-05-06,1282.199951,1282.199951,1280.300049,1281.699951,1281.699951,15";

            var result = MarketDataReader.Reader(testData.Split("\n"));

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(new DateTime(2019, 5, 1), result[0].Date);
            Assert.AreEqual(new DateTime(2019, 5, 2), result[1].Date);
            Assert.AreEqual(new DateTime(2019, 5, 3), result[2].Date);
            Assert.AreEqual(new DateTime(2019, 5, 6), result[3].Date);
        }
    }
}
