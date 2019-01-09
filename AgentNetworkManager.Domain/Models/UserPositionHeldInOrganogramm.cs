using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class UserPositionHeldInOrganogramm
    {
        [Required]
        [Key, Column(Order = 1)]
        [Index("IX_AspPerson", 1, IsUnique = true)]
        public string UserId { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        [Index("IX_Organogram", 2, IsUnique = false)]
        public string OrggrammId { get; set; }

    }
}
