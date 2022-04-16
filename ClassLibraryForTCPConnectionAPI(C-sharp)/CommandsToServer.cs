namespace ClassLibraryForTCPConnectionAPI_C_sharp_
{
    public enum CommandsToServer
    {
        Registration,
        Authorization,
        PreviousRoom,
        //Admin commands
        RegisterNewUser,
        BanClient,
        BanExpert,
        UnbanClient,
        UnbanExpert,
        DeleteClient,
        DeleteExpert,
        FindClientByLogin,
        GetAllClients,
        FindExpertByLogin,
        GetAllExperts,
        FindAdminByLogin,
        AddMarket,
        ModifyMarket,
        DeleteMarket,
        CreateReportAboutMarkets,
        //Expert commands
        RateMarket,
        //Client commands
        FindMarketByName,
        FindMarketByTotalRate,
        FindMarketByCountry,
        FindMarketByDemandLevel,
        FindMarketByCompetitionLevel,
        FindMarketByMarketTrade,
        GetAllMarkets
    }
}
