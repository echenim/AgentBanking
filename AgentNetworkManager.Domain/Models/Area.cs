using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class Area
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [ForeignKey(nameof(State))]
        public string StateId { get; set; }

        [Required]
        [Display(Name = "Area")]
        public string AreaName { get; set; }

        public virtual State State { get; set; }
    }
}
