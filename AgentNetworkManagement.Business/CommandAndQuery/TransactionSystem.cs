using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.ViewModels;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
    public class TransactionSystem
    {
        readonly ITransactions _transactions;

        public TransactionSystem()
        {
            _transactions = new TransactionRepository(new ApplicationDbContext());
        }

        public IQueryable<LastTransaction> GetTransactions(Func<LastTransaction, bool> predicate = null)
            => _transactions.Get(predicate: predicate);

        public IQueryable<TransactionHistory> GetTransactionHistories(Func<TransactionHistory, bool> predicate = null)
            => _transactions.Get(predicate: predicate);

        public AgentDetail FindPersonDetail(string personid)
            => _transactions.Find(personid);
    }
}
