using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.Models
{
     public class TelComms
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public decimal Amount { get; set; }

        
        public string TeCons => $"{Name} ( N{Amount} )";

    }
}
