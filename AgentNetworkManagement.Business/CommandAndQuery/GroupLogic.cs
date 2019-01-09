using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
   public class GroupLogic
    {
        private readonly IGroup _group;

        public GroupLogic()
        {
            _group = new GroupRepository(new ApplicationDbContext());
        }


       

        public IQueryable<ApplicationGroup> Get(Func<ApplicationGroup, bool> predicate = null)
            => _group.Get(predicate);
    }
}
