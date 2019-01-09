using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
   public class CustomerNextOfKinInfo
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Customer")]
        [ForeignKey(nameof(Customers))]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "KinName")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "KinMobile")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "KinAddress")]
        public string Addresss { get; set; }



        public virtual CustomerBankAccountOpening Customers { get; set; }
    }
}
