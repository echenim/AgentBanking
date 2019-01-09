using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.Models
{
   public class Gender
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        public string Name { get; set; }

    }
}
