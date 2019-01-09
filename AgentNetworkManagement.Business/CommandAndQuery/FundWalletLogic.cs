using System;
using System.Linq;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using Echenim.Nine.Util.UniqueReferenceGenerator.Processs;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.Models;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
     public class FundWalletLogic
     {
         private readonly IWallet _wallet;

         public FundWalletLogic()
         {
             _wallet = new FundWalletsRepository(new ApplicationDbContext());
         }

         public Notification Add(AgentNetworkManager.Domain.ViewModels.FundWallets fund,string manager)
         {
             var entity = new Fund
             {
                 Id = new ReferenceGenerator().GenerateId(),
                 AgentId = fund.Agent,
                 Amount = fund.Fund,
                 AvailableOrNot = "A",
                 Manager = manager,
                 CreatedOn = DateTime.Now
             };

             return _wallet.Add(entity, manager);
         }

         public IQueryable<FundWallet> Get(Func<FundWallet, bool> predicate = null) => _wallet.Get(predicate: predicate);

        public IQueryable<MemberWithAgentRole> GetAgent(Func<MemberWithAgentRole, bool> predicate = null) => _wallet.Get(predicate: predicate);

         public IQueryable<WalletStatus> GetBalance(Func<WalletStatus, bool> predicate = null)
             => _wallet.Get(predicate:predicate);
     }
}
