using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.Models;


namespace AgentNetworkManagement.Business.Repositories
{
    internal class SpatialRepository: ISpatial
    {
        private readonly ApplicationDbContext _ctx;

        public SpatialRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        #region Implementation of IAdd<SpatialNonTransactionScheme>

        public bool Add(SpatialNonTransactionScheme entity)
        {
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(entity.Agent.ToLower()));

           
            var state = false;
            if (agentwalletinformation != null)
            {
                entity.Agent = agentwalletinformation.Id;
                try
                {
                    _ctx.SpatialNonTransactional.Add(entity);
                    _ctx.SaveChanges();
                    state = true;
                }
                catch (Exception ex)
                {
                    state = false;
                }
            }
           
            return state;
        }

        #endregion

        #region Implementation of IAdd<SpatialTransactionScheme>

        public void Add(SpatialTransactionScheme entity)
        {
            _ctx.SpatialTransactional.Add(entity);
            _ctx.SaveChanges();
        }

        #endregion
    }
}
