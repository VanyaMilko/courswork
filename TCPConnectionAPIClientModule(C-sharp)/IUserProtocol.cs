using ClassLibraryForTCPConnectionAPI_C_sharp_;
using System.Collections.Generic;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IUserProtocol
    {
        bool connect();
        string receiveString();
        void sendString(string str);
        void sendLogin(string login);
        void sendPassword(string password);
        void sendCollection<T>(List<T> collection);
        List<T> receiveCollection<T>();
        T ReceiveObject<T>() where T : class;
        void SendObject<T>(T obj) where T : class;
        void sendCommand(CommandsToServer command);
        AnswerFromServer receiveAnswerFromServer();
        TypeOfUser receiveTypeOfUser();
        void GoToPreviousRoom();
        void sendTypeOfUser(TypeOfUser type);
    }
}
