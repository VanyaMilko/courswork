using DatabaseEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TCPConnectionAPI_C_sharp_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Server server = new Server();
                server.openConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
            }

        }
    }
}
