using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class CustomerBankCardInformation
    {

        public CustomerBankCardInformation()
        {
            AccountNumber = $"{DateTime.Now:MM/dd/yy}{DateTime.Now:h:mm:ss}".Replace("/","").Replace(":","");
        }

        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Customer")]
        [ForeignKey(nameof(Customers))]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(25)]
        public string CardSerialNumber { get; set; }

        [Required]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "AccountNumber")]
        [MaxLength(12)]
        [Index("xi_account_number",IsUnique = true)]
        public string AccountNumber { get; set; }

        public virtual CustomerBankAccountOpening Customers { get; set; }



    }
}
