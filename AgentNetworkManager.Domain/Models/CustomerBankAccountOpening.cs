using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public  class CustomerBankAccountOpening
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

       
        [MaxLength(50)]
        [Display(Name = "OtherName")]
        public string OtherName { get; set; }

         [Required]
         [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(14)]
        public string Dob { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string Name => $"{FirstName} {OtherName} {LastName}";

    }
}
