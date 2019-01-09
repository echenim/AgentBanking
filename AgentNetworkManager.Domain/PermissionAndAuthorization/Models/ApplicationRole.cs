using System;
using System.ComponentModel.DataAnnotations;
using Humanizer;
using Microsoft.AspNet.Identity.EntityFramework;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Base;

namespace AgentNetworkManager.Domain.PermissionAndAuthorization.Models
{
  

    // Must be expressed in terms of our custom UserRole:
    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationRole(string name, string kind)
           : this()
        {
            this.Name = name.Humanize(LetterCasing.Title);
             this.Kind = kind.Humanize(LetterCasing.Title);
        }

        public ApplicationRole(string name, string kind, string description)
          : this()
        {
            this.Name = name.Humanize(LetterCasing.Title);
            this.Kind = kind.Humanize(LetterCasing.Title);
            this.Description = description.Humanize(LetterCasing.Sentence);
        }

        /*
         * This will allow us to differentiate roles types, the roles that are function or positional
         */
        [Required]
        [MaxLength(10)]
        public string Kind { get; set; }


        /*
         * This will allow role ranking where the role with highest rank will be assumed 
         * is the user functional officer position in the portal, the true reflectio of the user position i nthe organization
         */
        [Required]
        public long Preceed { get; set; }
        
        public string Description { get; set; }

       
    }
}
