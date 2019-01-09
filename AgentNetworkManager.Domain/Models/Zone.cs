using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class Zone
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [ForeignKey(nameof(Area))]
        public string AreaId { get; set; }

        [Required]
        [Display(Name = "Wards")]
        public string ZoneName { get; set; }

        public virtual Area Area { get; set; }
    }
}
