using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.ViewModels;
using Humanizer;

namespace AgentNetworkManagement.Business.Repositories
{
    internal class TransactionRepository:ITransactions
    {
        readonly ApplicationDbContext _ctx;

        public TransactionRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

       

        #region Implementation of IGet<LastTransaction>

        public IQueryable<LastTransaction> Get(Func<LastTransaction, bool> predicate = null)
        {
            return predicate == null
                ? _ctx.LastTransactions.OrderBy(s => s.CreatedOn)
                : _ctx.LastTransactions.Where(predicate: predicate).AsQueryable();
        }

        #endregion

        #region Implementation of IGet<TransactionHistory>

        public IQueryable<TransactionHistory> Get(Func<TransactionHistory, bool> predicate = null)
            => predicate == null
                ? _ctx.TransactionHistories.OrderBy(s => s.CreatedOn)
                : _ctx.TransactionHistories.Where(predicate: predicate).AsQueryable();

        #endregion

        #region Implementation of IFind<AgentDetail>

        public AgentDetail Find(string agentId)
        {
            

            var agentCollection = _ctx.Members.SingleOrDefault(s=>s.Pid.Equals(agentId));
            var agent = new AgentDetail
            {
                Name = agentCollection.Name.Humanize(LetterCasing.Title),
                PhoneNumber = agentCollection.PhoneNumber,
                Email = agentCollection.Email.ToLower(),
                Gender = agentCollection.Gender.Humanize(LetterCasing.Title),
                Position = agentCollection.Position.Humanize(LetterCasing.Title),
                Agency = agentCollection.Agency,
                RegionName = agentCollection.RegionName,
                StateName = agentCollection.StateName,
                Area = agentCollection.Area,
                Zone = agentCollection.Zone,
                Clusta = agentCollection.Clusta,
            };
            return agent;
        }

        #endregion



    }
}
