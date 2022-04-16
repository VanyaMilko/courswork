using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IDataViewAccess
    {
        List<Market> FindMarketByName(string name);
        List<Market> FindMarketByTotalRate(double totalRate);
        List<Market> FindMarketByCountry(string country);
        List<Market> FindMarketByDemandLevel(double demandLevel);
        List<Market> FindMarketByCompetitionLevel(double competitionLevel);
        List<Market> FindMarketByMarketTrade(MarketTrade trade);
        List<Market> GetAllMarkets();
    }
}
