using AgentNetworkManagement.Business.Contracts.Base;
using AgentNetworkManager.Domain.DbViews;

namespace AgentNetworkManagement.Business.Contracts
{
    interface IPlatformUser:IGet<Member>,IFind<Member>
    {


    }
}
