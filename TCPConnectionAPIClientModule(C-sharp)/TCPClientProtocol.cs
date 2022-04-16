using ClassLibraryForTCPConnectionAPI_C_sharp_;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    class TCPClientProtocol : IUserProtocol
    {
        protected IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse
            (ConfigurationManager.AppSettings.Get("serverIP")),
            int.Parse(ConfigurationManager.AppSettings.Get("serverPort")));

        protected Socket connectionSocket
            = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        protected void sendServiceCommand(ServiceCommands command)
        {
            connectionSocket.Send(BitConverter.GetBytes((int)command));
        }

        protected ServiceCommands receiveServiceCommand()
        {
            byte[] buffer = new byte[4];
            connectionSocket.Receive(buffer);
            return (ServiceCommands)(BitConverter.ToInt32(buffer, 0));
        }

        public void GoToPreviousRoom()
        {
            sendCommand(CommandsToServer.PreviousRoom);
        }

        public bool connect()
        {
            connectionSocket.Connect(serverEndPoint);
            return connectionSocket.Connected;
        }

        public AnswerFromServer receiveAnswerFromServer()
        {
            byte[] answerBuf = new byte[4];
            sendServiceCommand(ServiceCommands.Ready_to_receive);
            connectionSocket.Receive(answerBuf);
            AnswerFromServer answer = (AnswerFromServer)(BitConverter.ToInt32(answerBuf, 0));
            return answer;
        }

        public List<T> receiveCollection<T>()
        {
            var sizeBuffer = new byte[sizeof(System.Int64)];
            sendServiceCommand(ServiceCommands.Ready_to_receive);
            connectionSocket.Receive(sizeBuffer);
            var collectionBuffer = new byte[BitConverter.ToInt64(sizeBuffer, 0)];
            sendServiceCommand(ServiceCommands.Ready_to_receive);
            connectionSocket.Receive(collectionBuffer);
            var formatter = new BinaryFormatter();
            List<T> collection = null;
            using (var ms = new MemoryStream(collectionBuffer))
            {
                collection = formatter.Deserialize(ms) as List<T>;
            }
            return collection;
        }

        public TypeOfUser receiveTypeOfUser()
        {
            byte[] typeBuf = new byte[4];
            sendServiceCommand(ServiceCommands.Ready_to_receive);
            connectionSocket.Receive(typeBuf);
            TypeOfUser type = (TypeOfUser)(BitConverter.ToInt32(typeBuf, 0));
            return type;
        }

        public void sendCollection<T>(List<T> collection)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(ms, collection);
                receiveServiceCommand();
                connectionSocket.Send(BitConverter.GetBytes(ms.Length));
                receiveServiceCommand();
                connectionSocket.Send(ms.ToArray());
            }
        }

        public void sendCommand(CommandsToServer command)
        {
            receiveServiceCommand();
            connectionSocket.Send(BitConverter.GetBytes((int)command));
        }

        public void sendLogin(string login)
        {
            receiveServiceCommand();
            connectionSocket.Send(BitConverter.GetBytes(login.Length));
            receiveServiceCommand();
            connectionSocket.Send(Encoding.UTF8.GetBytes(login));
        }

        public void sendPassword(string password)
        {
            receiveServiceCommand();
            connectionSocket.Send(BitConverter.GetBytes(password.Length));
            receiveServiceCommand();
            connectionSocket.Send(Encoding.UTF8.GetBytes(password));
        }

        public void sendTypeOfUser(TypeOfUser typeOfUser)
        {
            receiveServiceCommand();
            connectionSocket.Send(BitConverter.GetBytes((int)typeOfUser));
        }

        public string receiveString()
        {
            var sizeBuffer = new byte[4];
            sendServiceCommand(ServiceCommands.Ready_to_receive);
            connectionSocket.Receive(sizeBuffer);
            byte[] loginBuffer = new byte[BitConverter.ToInt32(sizeBuffer, 0)];
            sendServiceCommand(ServiceCommands.Ready_to_receive);
            connectionSocket.Receive(loginBuffer);
            return Encoding.Default.GetString(loginBuffer);
        }

        public void sendString(string str)
        {
            receiveServiceCommand();
            connectionSocket.Send(BitConverter.GetBytes(str.Length));
            receiveServiceCommand();
            connectionSocket.Send(Encoding.Default.GetBytes(str));
        }

        public T ReceiveObject<T>() where T : class
        {
            var sizeBuffer = new byte[8];
            sendServiceCommand(ServiceCommands.Ready_to_receive);
            connectionSocket.Receive(sizeBuffer);
            var collectionBuffer = new byte[BitConverter.ToInt32(sizeBuffer, 0)];
            sendServiceCommand(ServiceCommands.Ready_to_receive);
            connectionSocket.Receive(collectionBuffer);
            var formatter = new BinaryFormatter();
            T buf = null;
            using (var ms = new MemoryStream(collectionBuffer))
            {
                buf = formatter.Deserialize(ms) as T;
            }
            return buf;
        }

        public void SendObject<T>(T obj) where T : class
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(ms, obj);
                receiveServiceCommand();
                connectionSocket.Send(BitConverter.GetBytes(ms.Length));
                receiveServiceCommand();
                connectionSocket.Send(ms.ToArray());
            }
        }
    }
}
