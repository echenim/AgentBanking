using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.Models;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;


namespace AgentNetworkManagement.Business.Repositories
{
    internal class FundWalletsRepository:IWallet
    {
        private readonly ApplicationDbContext _ctx;

        public FundWalletsRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public IQueryable<WalletStatus> Get(Func<WalletStatus, bool> predicate = null)
            => predicate == null
                ? _ctx.AgentCurrentWalletStatus
                : _ctx.AgentCurrentWalletStatus.Where(predicate: predicate).AsQueryable();
            //=> _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username));

        public Notification Add(Fund entity,string manager)
        {
            var notification = new Notification();
            try
            {
                //entity.Id = new ReferenceGenerator().GenerateId();
                //entity.AvailableOrNot = "A";
                //entity.Manager = manager.Humanize(LetterCasing.Title);
                //entity.CreatedOn = DateTime.Now;
                _ctx.Funds.Add(entity);
                _ctx.SaveChanges();
                notification.Message = "agent wallet  was funded successful";
                notification.Success = false;
            }
            catch (Exception ex)
            {
                notification.Message = "fail to fund agent";
                notification.Success = false;
            }
            return notification;
        }

        public IQueryable<FundWallet> Get(Func<FundWallet, bool> predicate = null) => predicate == null
            ? _ctx.FundWallets.OrderByDescending(s => s.CreatedOn)
            : _ctx.FundWallets.Where(predicate: predicate).AsQueryable();

        public IQueryable<MemberWithAgentRole> Get(Func<MemberWithAgentRole, bool> predicate = null) => predicate == null
           ? _ctx.MemberWithAgentRoles.OrderByDescending(s => s.Name)
           : _ctx.MemberWithAgentRoles.Where(predicate: predicate).AsQueryable();

        #region Implementation of IGet<WalletStatus>

     
        #endregion
    }
}
