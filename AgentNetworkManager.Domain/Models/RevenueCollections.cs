using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.Models
{
    public class RevenueCollections
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string Code { get; set; }


    }
}
