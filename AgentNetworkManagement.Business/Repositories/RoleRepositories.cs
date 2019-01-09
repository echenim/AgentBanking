using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;


namespace AgentNetworkManagement.Business.Repositories
{
    internal class RoleRepositories:IRole
    {
        private readonly ApplicationDbContext _ctx;


        public RoleRepositories(ApplicationDbContext context)
        {
            _ctx = context;
        }


        

        public Notification Add(RoleViewModel entity)
        {
            var notification = new Notification();
            try
            {
                //var role = new IdentityRole(entity.Name);
                var role = new ApplicationRole(entity.Name,entity.Kind,entity.Description);
               // role.Id = new ReferenceGenerator().GenerateId();
                _ctx.Roles.Add(role);
                _ctx.SaveChanges();
                notification.Message = "role was created successful";
                notification.Success = false;
            }
            catch (Exception ex)
            {
                notification.Message = "fail to create role";
                notification.Success = false;
            }
            return notification;
        }

        public IQueryable<ApplicationRole> Get(Func<ApplicationRole, bool> predicate = null)
        { 
            
            var datalist = _ctx.Roles;
            return (predicate == null
                ? _ctx.Roles.OrderBy(s => s.Name)
                : _ctx.Roles.Where(predicate)).AsQueryable();
        }

        public ApplicationRole Find(Func<ApplicationRole, bool> predicate)
        {
            return _ctx.Roles.SingleOrDefault(predicate);
        }
    }
}
