using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.DbViews
{
    public class Member
    {
        [Key]
        public string Id { get; set; }
        public string Pid { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactAddress { get; set; }

        public string Position { get; set; }

        public string AgencyId { get; set; }
        public string Agency { get; set; }
        public string RegionName { get; set; }
        public string StateName { get; set; }
        public string Area { get; set; }
        public string Zone { get; set; }
        public string Clusta { get; set; }
        public string Kind { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullDetail => $"{Name} ({Position})";

    }
}
