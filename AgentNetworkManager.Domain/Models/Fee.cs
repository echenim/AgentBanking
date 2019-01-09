using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.Models
{
    public class Fee
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        public string FeeName { get; set; }
        public decimal Amount { get; set; }



    }
}
