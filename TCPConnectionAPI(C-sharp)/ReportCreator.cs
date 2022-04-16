using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPConnectionAPI_C_sharp_
{
    static public class ReportCreator
    {
        public static string CreateReportAboutVehicles()
        {
            using (IDataViewPermision db = new DatabaseContext())
            {
                var vehicles = db.FindMarketsWhere(c => c != null);
                string str = ("Отчет состояния транспортных средств на " + DateTime.Now.ToString() + '\n');
                foreach (var item in vehicles)
                {
                }
                return str;
            }
        }
    }
}
