using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public class ClientAbilityProtocol : IClientAbilityProtocol
    {
        IDataViewPermision DBconnection;

        public ClientAbilityProtocol()
        {
            DBconnection = new DatabaseContext();
        }

        public void Dispose()
        {
            DBconnection.Dispose();
        }

        public List<Market> FindMarketsWhere(Func<Market, bool> comparer)
        {
            return DBconnection.FindMarketsWhere(comparer);
        }
    }
}
