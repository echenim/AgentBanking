using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AgentNetworkManager.Domain.Models;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Base;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Managers;

namespace AgentNetworkManager.Domain.PermissionAndAuthorization.Models
{
    // Must be expressed in terms of our custom Role and other types:
    public class ApplicationUser
        : IdentityUser<string, ApplicationUserLogin,
        ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            // Add any custom User properties/code here
        }

       
        [ForeignKey(nameof(Person))]
        public string PersonId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

      public virtual Person Person { get; set; }


    }
}
