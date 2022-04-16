using ClassLibraryForTCPConnectionAPI_C_sharp_;
using System.Collections.Generic;
using System.Net.Sockets;

namespace TCPConnectionAPI_C_sharp_
{
    public interface IServerProtocol
    {
        Socket acceptConnectionRequest();
        string receiveString(Socket from);
        void sendString(string str, Socket destination);
        string receiveLogin(Socket from);
        string receivePassword(Socket from);
        void sendCollection<T>(List<T> collection, Socket destination);
        List<T> receiveCollection<T>(Socket from);
        T ReceiveObject<T>(Socket from) where T : class;
        void SendObject<T>(T obj, Socket destination) where T : class;
        CommandsToServer receiveCommand(Socket from);
        void sendAnswerFromServer(AnswerFromServer answer, Socket desination);
        void sendTypeOfUser(TypeOfUser typeOfUser, Socket destination);
        TypeOfUser receiveTypeOfUser(Socket from);
        void closeConnection();
    }
}
