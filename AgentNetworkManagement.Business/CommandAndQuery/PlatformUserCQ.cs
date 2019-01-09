using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
    public class PlatformUserCq
    {
        private readonly IPlatformUser _platformUser;


        public PlatformUserCq()
        {
            _platformUser = new PlatformUserRepository(new ApplicationDbContext());
        }


        public Member GetUserInfo(Func<Member, bool> predicate) 
            => _platformUser.Find(predicate: predicate);

        public IQueryable<Member> Get(Func<Member, bool> predicate = null)
            => predicate == null
                ? _platformUser.Get()
                : _platformUser.Get(predicate: predicate);



    }
}
