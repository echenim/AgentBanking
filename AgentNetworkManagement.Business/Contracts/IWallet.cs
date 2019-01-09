using System;
using AgentNetworkManagement.Business.Contracts.Base;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.Models;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using MemberWithAgentRole = AgentNetworkManager.Domain.DbViews.MemberWithAgentRole;

namespace AgentNetworkManagement.Business.Contracts
{
    
    interface IWallet : IGet<FundWallet>,IGet<MemberWithAgentRole>, IGet<WalletStatus>
    {
     //   WalletStatus GetBalance(string username);
        Notification Add(Fund entity, String manager);
    }
}
