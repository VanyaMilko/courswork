using ClassLibraryForTCPConnectionAPI_C_sharp_;
using System.Net.Sockets;

namespace TCPConnectionAPI_C_sharp_
{
    public class ConnectedUserInfo
    {
        public Socket ConnectionSocket { get; set; }
        public TypeOfUser Type { get; set; }
        public int DB_Id { get; set; }
        public ConnectedUserInfo()
        {
            Type = TypeOfUser.Undefined;
        }

    }
}
