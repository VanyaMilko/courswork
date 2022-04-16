using ClassLibraryForTCPConnectionAPI_C_sharp_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface ICommonAccess
    {
        TypeOfUser Authorization(string login, string password);
        AnswerFromServer Registration(TypeOfUser type, string login, string password, float expertWeight = 0);
        void PreviousRoom();
    }
}
