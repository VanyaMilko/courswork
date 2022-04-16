using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;

namespace TCPConnectionAPI_C_sharp_
{
<<<<<<< Updated upstream:TCPConnectionAPI(C-sharp)/IUserValidator.cs
    public interface IUserValidator
    {
        // CRUD для пользователей
        int CreateAdmin(Admin newAdmin);
        Admin FindAdmin(int adminId);
        Admin FindAdmin(in string login, in string password);
        bool UpdateAdmin(Admin newVersion); //С ID изменяемого объекта
        bool DeleteAdmin(int adminId);
=======
    public interface IUserModifyPermission : IUserViewPermission
    {
        int CreateAdmin(Admin admin);
        int CreateClient(Client client);
        int CreateExpert(Expert expert);
>>>>>>> Stashed changes:TCPConnectionAPI(C-sharp)/IUserModifyPermission.cs

        int CreateClient(Client newClient);
        Client FindClient(int clientId);
        Client FindClient(in string login, in string password);
        bool UpdateClient(Client newVersion);//С ID изменяемого объекта
        bool DeleteClientsWhere(Func<Client, bool> comparer);

        int CreateExpert(Expert newExpert);
        Expert FindExpert(int expertId);
        Expert FindExpert(in string login, in string password);
        bool UpdateExpert(Expert newVersion);//С ID изменяемого объекта
<<<<<<< Updated upstream:TCPConnectionAPI(C-sharp)/IUserValidator.cs
        bool DeleteExpert(int expertId);

=======
        bool DeleteExpertsWhere(Func<Expert, bool> comparer);
>>>>>>> Stashed changes:TCPConnectionAPI(C-sharp)/IUserModifyPermission.cs
    }
}
