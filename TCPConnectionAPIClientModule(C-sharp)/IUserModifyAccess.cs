using ClassLibraryForTCPConnectionAPI_C_sharp_;

namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IUserModifyAccess : IUserViewAccess   
    {
        AnswerFromServer RegisterNewAdmin(string login, string password);
        AnswerFromServer RegisterNewClient(string login, string password);
        AnswerFromServer RegisterNewExpert(string login, string password, float rateWeight);
        AnswerFromServer BanClientWith(string login);
        AnswerFromServer BanExpertWith(string login);
        AnswerFromServer UnbanExpertWith(string login);
        AnswerFromServer UnbanClientWith(string login);
        AnswerFromServer DeleteExpertWith(string login);
        AnswerFromServer DeleteClientWith(string login);
    }
}
