using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;

namespace AgentNetworkManagement.Business.Repositories
{
    internal class PlatformUserRepository:IPlatformUser
    {
        readonly private ApplicationDbContext _ctx;

        public PlatformUserRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        #region Implementation of IGet<Member>

        public IQueryable<Member> Get(Func<Member, bool> predicate = null)
            => predicate == null
                ? _ctx.Members.OrderBy(s => s.Name)
                : _ctx.Members.Where(predicate: predicate).AsQueryable();



        #endregion

        #region Implementation of IFind<Member>

        public Member Find(Func<Member, bool> predicate) 
            => _ctx.Members.Where(predicate).SingleOrDefault();

        #endregion

       
    }
}
