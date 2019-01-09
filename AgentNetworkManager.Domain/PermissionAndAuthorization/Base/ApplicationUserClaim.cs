using Microsoft.AspNet.Identity.EntityFramework;

namespace AgentNetworkManager.Domain.PermissionAndAuthorization.Base
{
    // You will not likely need to customize there, but it is necessary/easier to create our own 
    // project-specific implementations, so here they are:

    public class ApplicationUserClaim : IdentityUserClaim<string> { }
}
