using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;
using AgentNetworkManager.Domain.ViewModels;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
   public class PermissionAndAuthorization
   {
       private readonly IPermissionAndAuth _permissionAndAuth;
       private readonly ApplicationDbContext _context = new ApplicationDbContext();


       public PermissionAndAuthorization()
       {
           _permissionAndAuth = new AuthAndPermissionRepository(_context);
       }

        /// <summary>
        /// register user for the application by populating the RegisterViewModel entity
        /// </summary>
        /// <param name="entity">RegisterViewModel</param>
        /// <returns>notification object {messagge = "carry the message to communicate to the user", Success = true or false}</returns>
        public Notification Add(RegisterViewModel entity)
       {
            return _permissionAndAuth.Add(entity);
       }


        /// <summary>
        /// register user for the application by populating the RegisterAndAssignUserToNetWork entity
        /// </summary>
        /// <param name="entity">RegisterAndAssignUserToNetWork</param>
        /// <returns>notification object {messagge = "carry the message to communicate to the user", Success = true or false}</returns>
        public Notification Add(RegisterAndAssignUserToNetWork entity)
        {
            return _permissionAndAuth.Add(entity);
        }


        /// <summary>
        /// register user for the application by populating the RegisterAndAssignPlatformManagerToNetWork entity
        /// </summary>
        /// <param name="entity">RegisterAndAssignPlatformManagerToNetWork</param>
        /// <returns>notification object {messagge = "carry the message to communicate to the user", Success = true or false}</returns>
        public Notification Add(RegisterAndAssignPlatformManagerToNetWork entity)
        {
            return _permissionAndAuth.Add(entity);
        }




    }
}
