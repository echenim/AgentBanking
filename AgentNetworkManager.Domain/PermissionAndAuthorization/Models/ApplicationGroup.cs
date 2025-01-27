﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Humanizer;

namespace AgentNetworkManager.Domain.PermissionAndAuthorization.Models
{

    public class ApplicationGroup
    {
        public ApplicationGroup()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ApplicationRoles = new List<ApplicationGroupRole>();
            this.ApplicationUsers = new List<ApplicationUserGroup>();
        }

        public ApplicationGroup(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationGroup(string name, string description)
            : this(name)
        {
            this.Description = description.ToLower();
        }

        public ApplicationGroup(string name, string description,string owner)
           : this(name)
        {
            this.Description = description.ToLower();
            this.Owner = owner.Humanize(LetterCasing.Title);
        }


        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Owner { get; set; }


        public virtual ICollection<ApplicationGroupRole> ApplicationRoles { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUsers { get; set; }
    }
}
