using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class Transaction
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [ForeignKey(nameof(Person))]
        public string PersonId { get; set; }

        [Required(ErrorMessage = "transaction name is required please")]
        [Display(Name = "Transaction", Prompt = "Enter Transaction Name ")]
        [StringLength(400, ErrorMessage = "transaction name  must not be longer than 400 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "previous balance is required please")]
        [Display(Name = "PreviousBalance", Prompt = "Enter previous balance")]
        public decimal PreviousBalance { get; set; }

        [Required(ErrorMessage = "current balance is required please")]
        [Display(Name = "CurrentBalance", Prompt = "Enter current balance")]
        public decimal CurrentBalance { get; set; }


        [Required()]
        [Display(Name = "Debited Amount")]
        public decimal DebitedAount { get; set; }

        [Required(ErrorMessage = "transaction fee is required please")]
        [Display(Name = "Charge")]
        public decimal TransFee { get; set; }



        public virtual Person Person{ get; set; }
    }
}
