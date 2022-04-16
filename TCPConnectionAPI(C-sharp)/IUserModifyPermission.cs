using DatabaseEntities;
using System;

namespace TCPConnectionAPI_C_sharp_
{
    public interface IUserModifyPermission : IUserViewPermission
    {
        int CreateAdmin(Admin admin);
        int CreateClient(Client client);
        int CreateExpert(Expert expert);

        bool UpdateClient(Client newVersion);//С ID изменяемого объекта
        bool DeleteClientsWhere(Func<Client, bool> comparer);

        bool UpdateExpert(Expert newVersion);//С ID изменяемого объекта
        bool DeleteExpertsWhere(Func<Expert, bool> comparer);

        bool UpdateAdmin(Admin newVersion);


    }
}
