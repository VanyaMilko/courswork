using DatabaseEntities;
using System.Collections.Generic;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IUserViewAccess
    {
        List<Client> GetAllClients();
        List<Expert> GetAllExperts();
        Client FindClientByLogin(string login);
        Expert FindExpertByLogin(string login);
        Admin FindAdminByLogin(string login);
    }
}
