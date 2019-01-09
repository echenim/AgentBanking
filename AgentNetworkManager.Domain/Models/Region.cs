using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
   public class Region
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [ForeignKey(nameof(National))]
        public string NationalId { get; set; }

        [Required]
        [Display(Name = "Region")]
        
        public string Name { get; set; }

        public National National { get; set; }
    }
}
