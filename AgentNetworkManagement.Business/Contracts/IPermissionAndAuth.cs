using AgentNetworkManagement.Business.Contracts.Base;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;
using AgentNetworkManager.Domain.ViewModels;

namespace AgentNetworkManagement.Business.Contracts
{
    interface IPermissionAndAuth:IAdd<RegisterViewModel>, IAdd<UserRoleProfile>,
        IAdd<RegisterAndAssignUserToNetWork>, IAdd<RegisterAndAssignPlatformManagerToNetWork>
    {
    }
}
