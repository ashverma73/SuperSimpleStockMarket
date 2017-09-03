using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using SuperSimpleStockMarket.DataService;
namespace SuperSimpleStockMarket
{
    class ContainerBootStrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IStockService, StockMockService>("MockedStockService",
                                            new TransientLifetimeManager(),
                                            new InjectionConstructor());

            container.RegisterType<IStockService, StockService>("DBStockService",
                                            new TransientLifetimeManager(),
                                            new InjectionConstructor());
        }
    }
}
