using AgentNetworkManagement.Business.Contracts.Base;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.ViewModels;

namespace AgentNetworkManagement.Business.Contracts
{
    interface ITransactions: IGet<LastTransaction>, IGet<TransactionHistory>
    {
        AgentDetail Find(string agentId);
    }
}
