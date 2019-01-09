using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Stores;

namespace AgentNetworkManager.Domain.PermissionAndAuthorization.Managers
{
    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly

    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new ApplicationRoleStore(context.Get<ApplicationDbContext>()));
        }
    }
}
