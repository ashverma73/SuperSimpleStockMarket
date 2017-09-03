using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStockMarket.DataService;
using SuperSimpleStockMarket.DataModel;
namespace SuperSimpleStockMarketTests
{
    [TestClass]
    public class TradeServiceTests
    {
        ITradeService _tradeService = new TradeService();
        [TestMethod]
        public void GetTradesWithinMinutesNullTest()
        {
           var rslt= _tradeService.GetTradesWithinMinutes(null, 0);
            Assert.IsNotNull(rslt);
        }

        [TestMethod]
        public void RecordTradeTest()
        {
            ITrade trd = new Trade {TradedStock= new Stock { Ticker="AAPL", ParValue=100, LastPrice=100 },Quantity=100,TradePrice=100,TradeTime=DateTime.Now };
            _tradeService.RecordTrade(trd);
            var rslt = _tradeService.GetTradesWithinMinutes("AAPL", 1);
            Assert.IsNotNull(rslt);
            foreach (var k in rslt)
            {
                Assert.IsTrue(k.TradedStock.Ticker == "AAPL");

            }
        }

        [TestMethod]
        public void CalculateVWStockPricePerLast15Min()
        {
            ITrade trd = new Trade { TradedStock = new Stock { Ticker = "GOOG", ParValue = 100, LastPrice = 100 }, Quantity = 100, TradePrice = 100, TradeTime = DateTime.Now };
            _tradeService.RecordTrade(trd);
            ITrade trd1 = new Trade { TradedStock = new Stock { Ticker = "GOOG", ParValue = 100, LastPrice = 100 }, Quantity = 100, TradePrice = 50, TradeTime = DateTime.Now.AddMinutes(-16) };
            _tradeService.RecordTrade(trd1);
            var rslt =_tradeService.CalculateVWStockPrice("GOOG", 15);
            Assert.IsTrue(rslt == 100);
            ITrade trd2 = new Trade { TradedStock = new Stock { Ticker = "GOOG", ParValue = 100, LastPrice = 100 }, Quantity = 100, TradePrice = 50, TradeTime = DateTime.Now.AddMinutes(-5) };
            _tradeService.RecordTrade(trd2);
            rslt = _tradeService.CalculateVWStockPrice("GOOG", 15);
            Assert.IsTrue(rslt == 75);
        }
    }
}
