using DatabaseEntities;
using System;
using System.Collections.Generic;


namespace TCPConnectionAPI_C_sharp_
{
    public class ExpertAbilityProtocol : IExpertAbilityProtocol
    {
        public WeightingOfExpertOpinions expertMethod { get; set; }

        public IDataModifyPermission DBconnection;

        public bool Rate(Market entity, Expert expert, float rate)
        {
            expertMethod.Rate(ref entity, expert, rate);
            return DBconnection.UpdateMarket(entity);
        }

        public void Dispose()
        {
            DBconnection.Dispose();
        }

        public List<Market> FindMarketsWhere(Func<Market, bool> comparer)
        {
            return DBconnection.FindMarketsWhere(comparer);
        }

        public ExpertAbilityProtocol()
        {
            expertMethod = new WeightingOfExpertOpinions();
            DBconnection = new DatabaseContext();
        }

    }
}
