using DatabaseEntities;
using System;
using System.Collections.Generic;

namespace TCPConnectionAPI_C_sharp_
{
    public interface IUserViewPermission : IDisposable
    {
        List<Admin> FindAdminsWhere(Func<Admin, bool> comparer);
        List<Client> FindClientsWhere(Func<Client, bool> comparer);
        List<Expert> FindExpertsWhere(Func<Expert, bool> comparer);
    }
}
