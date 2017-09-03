using System;

namespace SuperSimpleStockMarket.DataModel
{
    public enum Signal
    {
        Buy,
        Sell
    }
   public interface ITrade
    {
        Stock TradedStock { get; set; }
        int Quantity { get; set; }
        DateTime TradeTime { get; set; }
        Signal TradeSignal { get; set; }
        double TradePrice { get; set; }
    }
}
