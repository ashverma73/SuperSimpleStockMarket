using SuperSimpleStockMarket.DataModel;
using System;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.DataService
{
    public  class StockMockService : IStockService
    {
        List<Stock> _stockData= null;
        public StockMockService()
        {
            _stockData = LoadStockData();
        }
       public double CalcAllShareIndex()
        {
            double totalmv = 1;
            if (_stockData is null) return -1;
            _stockData.ForEach(p => totalmv = p.LastPrice * totalmv);
            return Math.Round(Math.Pow(totalmv, 1.0 /_stockData.Count),4);
        }

        public double CalcDividendYield(IStock stock)
        {
            if (stock == null) return -1;
            if (stock.LastPrice == 0) return -1;
            if (stock.Type == StockType.Common)
                return Math.Round(stock.LastDividend / stock.LastPrice,4);
            return Math.Round((stock.FixedDividend * stock.ParValue / stock.LastPrice),4);


        }

        public double? CalcPERatio(IStock stock)
        {
            if (stock == null) return null;
            if (stock.LastDividend == 0) return null; else return Math.Round(stock.LastPrice / stock.LastDividend,2);
           
        }
        public List<Stock> LoadStockData() { return _stockData ?? MockData.MockData.GetStockData();   }
      
    }
}
