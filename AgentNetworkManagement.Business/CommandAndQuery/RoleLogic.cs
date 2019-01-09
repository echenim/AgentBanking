using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
    public class RoleLogic
    {
        private readonly IRole _role;

        public RoleLogic()
        {
            _role = new RoleRepositories(new ApplicationDbContext());
        }


        /// <summary>
        /// create a new role
        /// </summary>
        /// <param name="entity">ApplicationRole</param>
        /// <returns>notification object {messagge = "carry the message to communicate to the user", Success = true or false}</returns>

        public Notification Add(RoleViewModel entity)
        {
            return _role.Add(entity);
        }

        public IQueryable<ApplicationRole> Get(Func<ApplicationRole, bool> predicate = null)
        {
            return _role.Get(predicate);
        }

        public ApplicationRole Find(Func<ApplicationRole, bool> predicate)
        {
            return _role.Find(predicate);
        }
    }
}
