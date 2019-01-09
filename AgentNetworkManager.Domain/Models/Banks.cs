using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.Models
{
   public  class Banks
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        public string BankName { get; set; }

        public string BankCode { get; set; }
       
    }
}
