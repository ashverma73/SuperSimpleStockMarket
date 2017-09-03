
using SuperSimpleStockMarket.DataModel;
using System.Collections.Generic;
namespace SuperSimpleStockMarket.DataService
{

    public interface IStockService
        {
             List<Stock> LoadStockData();
             double CalcDividendYield(IStock stock);
             double? CalcPERatio(IStock stock);
             double CalcAllShareIndex();
        
        }
   
}
