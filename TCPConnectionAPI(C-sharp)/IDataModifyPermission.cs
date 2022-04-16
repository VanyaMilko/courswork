using System;
using DatabaseEntities;
namespace TCPConnectionAPI_C_sharp_
{
    public interface IDataModifyPermission : IDataViewPermision
    {
        int CreateMarket(Market newMarket);
        bool DeleteMarketsWhere(Func<Market, bool> comparer);
        bool UpdateMarket(Market newVersion);
    }
}
