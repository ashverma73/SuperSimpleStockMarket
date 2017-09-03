using SuperSimpleStockMarket.DataModel;
using System.Collections.Generic;
namespace SuperSimpleStockMarket.DataService
{
    public interface ITradeService
    {
        
        void RecordTrade(ITrade tradedata);
        IEnumerable<ITrade> GetTradesWithinMinutes(string ticker,int minutes);
        double CalculateVWStockPrice(string ticker, int minutes);
    }
}
