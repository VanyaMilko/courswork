using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public class ClientConnectionModule : IAdminAccess, IExpertAccess, IClientAccess
    {
        protected IUserProtocol protocol;

        protected static int amountOfObjects;

        public bool Connected { get; }

        public ClientConnectionModule()
        {
            protocol = new TCPClientProtocol();
            if (amountOfObjects == 0)
            {
                Connected = protocol.connect();
            }
            amountOfObjects++;
        }

        public TypeOfUser Authorization(string login, string password)
        {
            protocol.sendCommand(CommandsToServer.Authorization);
            protocol.sendLogin(login);
            protocol.sendPassword(password);
            return protocol.receiveTypeOfUser();
        }

        public AnswerFromServer Registration(TypeOfUser type, string login, string password, float expertWeight = 0)
        {
            protocol.sendCommand(CommandsToServer.Registration);
            protocol.sendTypeOfUser(type);
            protocol.sendLogin(login);
            protocol.sendPassword(password);
            if (type == TypeOfUser.Expert)
            {
                protocol.sendString(expertWeight.ToString());
            }
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer Rate(int entityId, float Rate)
        {
            protocol.sendCommand(CommandsToServer.RateMarket);
            protocol.sendString(entityId.ToString());
            protocol.sendString(Rate.ToString());
            return protocol.receiveAnswerFromServer();
        }

        public void PreviousRoom()
        {
            protocol.GoToPreviousRoom();
        }

        public Client FindClientByLogin(string login)
        {
            protocol.sendCommand(CommandsToServer.FindClientByLogin);
            protocol.sendLogin(login);
            var received = protocol.receiveCollection<Client>();
            if (received.Count == 0 || received.Count > 1)
            {
                return new Client();
            }
            else
            {
                return received.First();
            }
        }

        public Expert FindExpertByLogin(string login)
        {
            protocol.sendCommand(CommandsToServer.FindExpertByLogin);
            protocol.sendLogin(login);
            var received = protocol.receiveCollection<Expert>();
            if (received.Count == 0 || received.Count > 1)
            {
                return new Expert();
            }
            else
            {
                return received.First();
            }
        }

        public Admin FindAdminByLogin(string login)
        {
            protocol.sendCommand(CommandsToServer.FindAdminByLogin);
            protocol.sendLogin(login);
            var received = protocol.receiveCollection<Admin>();
            if (received.Count == 0 || received.Count > 1)
            {
                return new Admin();
            }
            else
            {
                return received.First();
            }
        }

        public AnswerFromServer RegisterNewAdmin(string login, string password)
        {
            protocol.sendCommand(CommandsToServer.RegisterNewUser);
            protocol.sendTypeOfUser(TypeOfUser.Admin);
            protocol.sendLogin(login);
            protocol.sendPassword(password);
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer RegisterNewClient(string login, string password)
        {
            protocol.sendCommand(CommandsToServer.RegisterNewUser);
            protocol.sendTypeOfUser(TypeOfUser.Client);
            protocol.sendLogin(login);
            protocol.sendPassword(password);
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer RegisterNewExpert(string login, string password, float rateWeight)
        {
            protocol.sendCommand(CommandsToServer.RegisterNewUser);
            protocol.sendTypeOfUser(TypeOfUser.Expert);
            protocol.sendLogin(login);
            protocol.sendPassword(password);
            protocol.sendString(rateWeight.ToString());
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer BanClientWith(string login)
        {
            protocol.sendCommand(CommandsToServer.BanClient);
            protocol.sendLogin(login);
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer BanExpertWith(string login)
        {
            protocol.sendCommand(CommandsToServer.BanExpert);
            protocol.sendLogin(login);
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer UnbanExpertWith(string login)
        {
            protocol.sendCommand(CommandsToServer.UnbanExpert);
            protocol.sendLogin(login);
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer UnbanClientWith(string login)
        {
            protocol.sendCommand(CommandsToServer.UnbanExpert);
            protocol.sendLogin(login);
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer DeleteExpertWith(string login)
        {
            protocol.sendCommand(CommandsToServer.DeleteExpert);
            protocol.sendLogin(login);
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer DeleteClientWith(string login)
        {
            protocol.sendCommand(CommandsToServer.DeleteClient);
            protocol.sendLogin(login);
            return protocol.receiveAnswerFromServer();
        }

        public List<Client> GetAllClients()
        {
            protocol.sendCommand(CommandsToServer.GetAllClients);
            return protocol.receiveCollection<Client>();
        }

        public List<Expert> GetAllExperts()
        {
            protocol.sendCommand(CommandsToServer.GetAllExperts);
            return protocol.receiveCollection<Expert>();
        }

        public AnswerFromServer AddNewMarket(Market newMarket)
        {
            protocol.sendCommand(CommandsToServer.AddMarket);
            protocol.SendObject(newMarket);
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer ModifyMarket(Market newMarket)
        {
            protocol.sendCommand(CommandsToServer.ModifyMarket);
            protocol.SendObject(newMarket);
            return protocol.receiveAnswerFromServer();
        }

        public AnswerFromServer DeleteMarket(int id)
        {
            protocol.sendCommand(CommandsToServer.DeleteMarket);
            protocol.sendString(id.ToString());
            return protocol.receiveAnswerFromServer();
        }

        public List<Market> FindMarketByName(string name)
        {
            protocol.sendCommand(CommandsToServer.FindMarketByName);
            protocol.sendString(name);
            return protocol.receiveCollection<Market>();
        }

        public List<Market> FindMarketByTotalRate(double totalRate)
        {
            protocol.sendCommand(CommandsToServer.FindMarketByTotalRate);
            protocol.sendString(totalRate.ToString());
            return protocol.receiveCollection<Market>();
        }

        public List<Market> FindMarketByCountry(string country)
        {
            protocol.sendCommand(CommandsToServer.FindMarketByCountry);
            protocol.sendString(country);
            return protocol.receiveCollection<Market>();
        }

        public List<Market> FindMarketByDemandLevel(double demandLevel)
        {
            protocol.sendCommand(CommandsToServer.FindMarketByDemandLevel);
            protocol.sendString(demandLevel.ToString());
            return protocol.receiveCollection<Market>();
        }

        public List<Market> FindMarketByCompetitionLevel(double competitionLevel)
        {
            protocol.sendCommand(CommandsToServer.FindMarketByCompetitionLevel);
            protocol.sendString(competitionLevel.ToString());
            return protocol.receiveCollection<Market>();
        }

        public List<Market> FindMarketByMarketTrade(MarketTrade trade)
        {
            protocol.sendCommand(CommandsToServer.FindMarketByMarketTrade);
            protocol.sendString(trade.ToString());
            return protocol.receiveCollection<Market>();
        }

        public List<Market> GetAllMarkets()
        {
            protocol.sendCommand(CommandsToServer.GetAllMarkets);
            return protocol.receiveCollection<Market>();
        }

        public string GetReportAboutMarkets()
        {
            protocol.sendCommand(CommandsToServer.CreateReportAboutMarkets);
            return protocol.receiveString();
        }
    }
}
