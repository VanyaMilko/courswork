using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public interface IAdminAbilityProtocol : IClientAbilityProtocol
    {
        int RegisterNewUser(TypeOfUser type, string login, string password, float rateWeight = 0);
        List<Client> FindClientsWhere(Func<Client, bool> comparer);
        List<Admin> FindAdminsWhere(Func<Admin, bool> comparer);
        List<Expert> FindExpertsWhere(Func<Expert, bool> comparer);
        bool BanClientsWhere(Func<Client, bool> comparer);
        bool BanExpertsWhere(Func<Expert, bool> comparer);
        bool UnbanExpertsWhere(Func<Expert, bool> comparer);
        bool UnbanClientsWhere(Func<Client, bool> comparer);
        bool DeleteClientsWhere(Func<Client, bool> comparer);
        bool DeleteExpertsWhere(Func<Expert, bool> comparer);
        bool CreateMarket(Market newMarket);
        bool ModifyMarket(Market newVesrion);
        bool DeleteMarketsWhere(Func<Market, bool> sampler);
        string CreateReportAboutMarkets();
    }
}
