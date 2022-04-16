using DatabaseEntities;

namespace TCPConnectionAPI_C_sharp_
{
    public interface IExpertAbilityProtocol : IClientAbilityProtocol
    {
        bool Rate(Market entity, Expert expert, float rate);
    }
}
