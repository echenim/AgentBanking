using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class State
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [ForeignKey(nameof(Region))]
        public string RegionId { get; set; }

        [Required]
        [Display(Name = "State")]
       
        public string Name { get; set; }

        public virtual  Region Region { get; set; }
    }
}
