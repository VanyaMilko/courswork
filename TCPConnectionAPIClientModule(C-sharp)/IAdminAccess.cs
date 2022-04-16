namespace TCPConnectionAPIClientModule_C_sharp_
{
    public interface IAdminAccess : IUserModifyAccess, IDataModifyAccess, ICommonAccess
    {
        string GetReportAboutMarkets();
    }
}
