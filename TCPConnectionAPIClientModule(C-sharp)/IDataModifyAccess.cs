using ClassLibraryForTCPConnectionAPI_C_sharp_;
using DatabaseEntities;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IDataModifyAccess : IDataViewAccess   
    {
        AnswerFromServer AddNewMarket(Market newMarket);
        AnswerFromServer ModifyMarket(Market newMarket);
        AnswerFromServer DeleteMarket(int id);
    }
}
