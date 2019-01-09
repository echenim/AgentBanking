using AgentNetworkManagement.Business.Contracts.Base;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;

namespace AgentNetworkManagement.Business.Contracts
{
    interface IRole:IAdd<RoleViewModel>,IGet<ApplicationRole>,IFind<ApplicationRole>
    {
    }
}
