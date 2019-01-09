using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class CollectionTransaction
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [ForeignKey(nameof(Collections))]
        [Required(ErrorMessage = "collections name is required please")]
        [Display(Name = "Collections", Prompt = "Enter Name ")]
        public string CollectionId { get; set; }

        [Required(ErrorMessage = "name is required please")]
        [Display(Name = "Name", Prompt = "Enter Name ")]
        [StringLength(150, ErrorMessage = "name  must not be longer than 150 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "tel is required please")]
        [Display(Name = "Tel", Prompt = "Enter Tel")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set;}

        [Required(ErrorMessage = "address is required please")]
        [Display(Name = "Address", Prompt = "Enter address ")]
        [StringLength(350, ErrorMessage = "address  must not be longer than 350 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "amount is required please")]
        [Display(Name = "Amount", Prompt = "Enter amount ")]
        public decimal Amount { get; set; }

        [Required]
        public string Person { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Collections Collections { get; set; }

    }
}
