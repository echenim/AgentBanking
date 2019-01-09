using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
   public class CustomerBankAccountOpningAddress
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Customer")]
        [ForeignKey(nameof(Customers))]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "PlaceOfBirth")]
        public string BirthPlace { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Address")]
        public string Addresss { get; set; }



        public virtual CustomerBankAccountOpening Customers { get; set; }
    }
}
