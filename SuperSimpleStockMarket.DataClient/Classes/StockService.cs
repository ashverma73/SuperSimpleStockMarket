using SuperSimpleStockMarket.DataModel;
using System;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.DataService
{
    public class StockService:IStockService
    {
       public List<Stock> LoadStockData() { throw new NotImplementedException(); }
        double IStockService.CalcAllShareIndex()
        {
            throw new NotImplementedException();
        }

        double IStockService.CalcDividendYield(IStock stock)
        {
            throw new NotImplementedException();
        }

        double? IStockService.CalcPERatio(IStock stock)
        {
            throw new NotImplementedException();
        }
    }
}
