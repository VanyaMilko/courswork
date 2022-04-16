using ClassLibraryForTCPConnectionAPI_C_sharp_;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TCPConnectionAPI_C_sharp_
{
    class TCPServerProtocol : IServerProtocol
    {
        protected IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse
            (ConfigurationManager.AppSettings.Get("serverIP")),
            int.Parse(ConfigurationManager.AppSettings.Get("serverPort")));

        protected Socket listenSocket
            = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public TCPServerProtocol()
        {
            Console.WriteLine($"Server IP: {ConfigurationManager.AppSettings.Get("serverIP")}  " +
                $"Server port: {int.Parse(ConfigurationManager.AppSettings.Get("serverPort"))}");
            listenSocket.Bind(endPoint);
            listenSocket.Listen(5);
        }

        public Socket acceptConnectionRequest()
        {
            return listenSocket.Accept();
        }

        protected void sendServiceCommand(ServiceCommands command, Socket destination)
        {
            destination.Send(BitConverter.GetBytes((int)command));
        }

        protected ServiceCommands receiveServiceCommand(Socket from)
        {
            byte[] buffer = new byte[4];
            from.Receive(buffer);
            return (ServiceCommands)(BitConverter.ToInt32(buffer, 0));
        }

        public List<T> receiveCollection<T>(Socket from)
        {
            var sizeBuffer = new byte[8];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(sizeBuffer);
            var collectionBuffer = new byte[BitConverter.ToInt32(sizeBuffer, 0)];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(collectionBuffer);
            var formatter = new BinaryFormatter();
            List<T> collection = null;
            using (var ms = new MemoryStream(collectionBuffer))
            {
                collection = new List<T>(formatter.Deserialize(ms) as List<T>);
            }
            return collection;
        }

        public CommandsToServer receiveCommand(Socket from)
        {
            byte[] commandBuf = new byte[4];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(commandBuf);
            CommandsToServer command = (CommandsToServer)(BitConverter.ToInt32(commandBuf, 0));
            return command;
        }

        public string receiveLogin(Socket from)
        {
            var sizeBuffer = new byte[4];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(sizeBuffer);
            byte[] loginBuffer = new byte[BitConverter.ToInt32(sizeBuffer, 0)];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(loginBuffer);
            return Encoding.UTF8.GetString(loginBuffer);
        }

        public string receivePassword(Socket from)
        {
            var sizeBuffer = new byte[4];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(sizeBuffer);
            byte[] passwordBuffer = new byte[BitConverter.ToInt32(sizeBuffer, 0)];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(passwordBuffer);
            return Encoding.UTF8.GetString(passwordBuffer);
        }

        public void sendTypeOfUser(TypeOfUser typeOfUser, Socket destination)
        {
            receiveServiceCommand(destination);
            destination.Send(BitConverter.GetBytes((int)typeOfUser));
        }

        public void sendAnswerFromServer(AnswerFromServer answer, Socket desination)
        {
            receiveServiceCommand(desination);
            desination.Send(BitConverter.GetBytes((int)answer));
        }

        public void sendCollection<T>(List<T> collection, Socket destination)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(ms, collection);
                receiveServiceCommand(destination);
                destination.Send(BitConverter.GetBytes(ms.Length));
                receiveServiceCommand(destination);
                destination.Send(ms.ToArray());
            }
        }

        public void closeConnection()
        {
            listenSocket.Shutdown(SocketShutdown.Both);
            listenSocket.Close();
        }

        public TypeOfUser receiveTypeOfUser(Socket from)
        {
            byte[] typeBuf = new byte[4];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(typeBuf);
            TypeOfUser type = (TypeOfUser)(BitConverter.ToInt32(typeBuf, 0));
            return type;
        }

        public string receiveString(Socket from)
        {
            var sizeBuffer = new byte[4];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(sizeBuffer);
            byte[] loginBuffer = new byte[BitConverter.ToInt32(sizeBuffer, 0)];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(loginBuffer);
            return Encoding.Default.GetString(loginBuffer);
        }

        public void sendString(string str, Socket destination)
        {
            receiveServiceCommand(destination);
            destination.Send(BitConverter.GetBytes(str.Length));
            receiveServiceCommand(destination);
            destination.Send(Encoding.Default.GetBytes(str));
        }

        public T ReceiveObject<T>(Socket from) where T: class
        {
            var sizeBuffer = new byte[8];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(sizeBuffer);
            var objBuffer = new byte[BitConverter.ToInt32(sizeBuffer, 0)];
            sendServiceCommand(ServiceCommands.Ready_to_receive, from);
            from.Receive(objBuffer);
            var formatter = new BinaryFormatter();
            T buf;
            using (var ms = new MemoryStream(objBuffer))
            {
                buf = formatter.Deserialize(ms) as T;
            }
            return buf;
        }

        public void SendObject<T>(T obj, Socket destination) where T: class
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(ms, obj);
                receiveServiceCommand(destination);
                destination.Send(BitConverter.GetBytes(ms.Length));
                receiveServiceCommand(destination);
                destination.Send(ms.ToArray());
            }
        }
    }
}
