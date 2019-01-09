using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;

namespace AgentNetworkManager.Domain.Models
{
    public class AssignUsersToTheirAgentNetwork
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        [Required]
        [ForeignKey(nameof(National))]
        public string NetworkId { get; set; }

        public virtual  ApplicationUser ApplicationUser { get; set; }
        public virtual National National { get; set; }


    }
}
