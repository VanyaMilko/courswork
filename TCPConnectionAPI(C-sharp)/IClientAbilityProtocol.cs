using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public interface IClientAbilityProtocol : IDisposable
    {
        List<Market> FindMarketsWhere(Func<Market, bool> comparer);
    }
}
