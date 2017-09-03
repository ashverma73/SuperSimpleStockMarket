using Microsoft.Practices.Unity;
using SuperSimpleStockMarket.DataModel;
using SuperSimpleStockMarket.DataService;
using System;
namespace SuperSimpleStockMarket
{

    class Program
    {
        protected static IUnityContainer container;
        private static IStockService _stockService;
        private static ITradeService _tradeService;
        static void Main(string[] args)
        {
            container = new UnityContainer();
            ContainerBootStrapper.RegisterTypes(container); // Register Unity Container for services use dependency injection 
            try
            {
                _stockService = container.Resolve<IStockService>("MockedStockService"); // Using Mocked Stock service as all data is mocked and not loaded from DB. 
                    // Production code will use StockService insted of Mocked Service --Not implemented
                 _tradeService = new TradeService();
                SetupPrice(); // Setting up market price
                SetupTrades(); //setting up trades
                PrintOutput(); //printing output
           
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + " \n Please try again");
            }
            Console.ReadKey();
        }

        static void PrintOutput()
        {
            Console.WriteLine("*********************Super Simple Stock Market**********************");
            Console.WriteLine("Ticker\tPrice\tP/E\t     Div.Yield\t\tVW Stock Price");
            foreach (IStock stk in _stockService.LoadStockData())
            {
                var str = $"\n {stk.Ticker} \t {stk.LastPrice} \t {_stockService.CalcPERatio(stk)?.ToString()??"-"} \t\t {_stockService.CalcDividendYield(stk).ToString("P")} \t\t {_tradeService.CalculateVWStockPrice(stk.Ticker,15)}";
                Console.WriteLine(str);
            }
            Console.WriteLine($"\nGBCE All Share Index: {_stockService.CalcAllShareIndex()}");
        }

        static void SetupPrice()
        {
            Random rnd = new Random();
            foreach (IStock stk in _stockService.LoadStockData())
            { 
              int marketprice = rnd.Next(50, 101); 
                stk.LastPrice = marketprice;
               
            }
        }
        static void SetupTrades()
        {
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                int stockindex = rnd.Next(5); 
                var stk = _stockService.LoadStockData()[stockindex];
                var qnty = rnd.Next(100, 1001);
                var signal = rnd.Next(2);
                var trdPrice = stk.LastPrice * ( 1 + (double)(rnd.Next(1,4)) / 100);
                _tradeService.RecordTrade(new Trade { TradedStock = stk, Quantity = qnty, TradeSignal = signal < 1 ? Signal.Sell : Signal.Buy, TradePrice = trdPrice, TradeTime = DateTime.Now.AddMinutes(-stockindex) });
            }
        }
    }
    
}
