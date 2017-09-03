using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStockMarket.DataService;
using SuperSimpleStockMarket.DataModel;
namespace SuperSimpleStockMarket.Tests
{
    [TestClass]
    public class StockServiceTests
    {
      
        IStockService _mockService = new StockMockService();
        
        [TestMethod]
        public void LoadStockDataTest()
        {
            var data = _mockService.LoadStockData();
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count > 0);
        }
        [TestMethod]
        public void CalcDividendYieldNullTest()
        {
            var divyield = _mockService.CalcDividendYield(null);
            Assert.IsTrue(divyield == -1);
        }

        [TestMethod]
        public void CalcDividendYieldCommonTest()
        {
            var stock = new Stock { Ticker = "test",  Type=StockType.Common, LastDividend = 100, LastPrice = 100 };
            var divyield = _mockService.CalcDividendYield(stock);
             Assert.IsTrue(divyield == 1);
        }
        [TestMethod]
        public void CalcDividendYieldPreferredTest()
        {
            var stock = new Stock { Ticker = "test", Type = StockType.Preferred, ParValue=100, FixedDividend = .1, LastPrice = 100 };
            var divyield = _mockService.CalcDividendYield(stock);
            Assert.IsTrue(divyield == .1);
        }

        [TestMethod]
        public void CalcPERatioWithNoStockTest()
        {
           // var stock = new Stock { Ticker = "test", Type = StockType.Common, LastDividend = 100, LastPrice = 100 };
            var peratio = _mockService.CalcPERatio(null);
            Assert.IsTrue(peratio is null);
        }
        [TestMethod]
        public void CalcPERatioTest()
        {
             var stock = new Stock { Ticker = "test", Type = StockType.Common, LastDividend = 100, LastPrice = 100 };
            var peratio = _mockService.CalcPERatio(stock);
            Assert.IsTrue(peratio == 1);
        }

        [TestMethod]
        public void CalcAllShareIndexTest()
        {
            var peratio = _mockService.CalcAllShareIndex();
            Assert.IsTrue(peratio == 68.5347);
        }

    }
}
