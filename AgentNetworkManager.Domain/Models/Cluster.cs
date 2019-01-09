using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class Cluster
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [ForeignKey(nameof(Zone))]
        public string ZoneId { get; set; }

        [Required]
        [Display(Name = "Cluster")]
        public string ClusterName { get; set; }

        public virtual Zone Zone { get; set; }
    }
}
