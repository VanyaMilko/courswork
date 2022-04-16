using ClassLibraryForTCPConnectionAPI_C_sharp_;
using System;
using DatabaseEntities;
namespace TCPConnectionAPI_C_sharp_
{
    public class WeightingOfExpertOpinions
    {
        public void Rate(ref Market obj, Expert expert, float rate)
        {
            Rate newRate = new Rate(expert.RateWeight / (obj.RateSet.Count + 1));
            newRate.Expert = expert;
            newRate.TimeOfCommit = DateTime.Now;
            obj.RateSet.Add(newRate);
            double sum = 0;
            foreach (var item in obj.RateSet)
            {
                sum += item.Value;
            }
            obj.TotalRate = sum;
        }
    }
}
