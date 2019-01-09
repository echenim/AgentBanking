using System.Linq;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using AgentNetworkManagement.Business.Contracts.Base;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.Models;

namespace AgentNetworkManagement.Business.Contracts
{
    internal interface IMember:IFind<Member>,IAdd<UserPositionHeldInOrganogramm>,IGet<Member>
    {
        IQueryable<Member> GetMembers();
        Notification AddMemberToAgentNetwork(AssignUsersToTheirAgentNetwork entity);


    }
}
