using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;

namespace AgentNetworkManagement.Business.Repositories
{
   internal class GroupRepository:IGroup
   {
       private readonly ApplicationDbContext _ctx;

       public GroupRepository(ApplicationDbContext ctx)
       {
           _ctx = ctx;
       }



       #region Implementation of IGet<ApplicationGroup>

       public IQueryable<ApplicationGroup> Get(Func<ApplicationGroup, bool> predicate = null)
           => predicate == null
               ? _ctx.ApplicationGroups.OrderBy(s => s.Name)
               : _ctx.ApplicationGroups.Where(predicate: predicate).AsQueryable();



       #endregion
   }
}
