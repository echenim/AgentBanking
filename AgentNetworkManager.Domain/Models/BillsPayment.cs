using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class BillsPayment
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

         [Required]
         public string Name { get; set; }

         public string Kind { get; set; }

         [Required]
         public decimal Amount { get; set; }
         
         [Required]
         public string Code { get; set; }


        [NotMapped]
        public string Revenu => $"{Name} ({Kind} {Amount} )";




    }
}
