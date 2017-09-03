using SuperSimpleStockMarket.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSimpleStockMarket.DataService
{
    public class TradeService:ITradeService
    {
        private  List<ITrade> _tradeData;

        public TradeService()
        {
            _tradeData = new List<ITrade>();
        }

      public  double CalculateVWStockPrice(string ticker, int minutes)
        {
            var trades = GetTradesWithinMinutes(ticker, minutes);
            if(trades!=null && trades.Any())
            {
                var sumqnty = trades.Sum(p => p.Quantity);
                var sumtrdedpriceqnty = trades.Sum(p => p.TradePrice * p.Quantity);
                return sumqnty == 0 ? 0 : Math.Round(sumtrdedpriceqnty / sumqnty, 2);

            }
            return 0;
        }

        public IEnumerable<ITrade> GetTradesWithinMinutes(string ticker, int minutes)
        {
            return _tradeData?.Where(p => p?.TradedStock.Ticker == ticker && p?.TradeTime >= DateTime.Now.AddMinutes(-minutes));
        }

        public void RecordTrade(ITrade tradedata)
        {
            _tradeData?.Add(tradedata);
        }
    }
}
