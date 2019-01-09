using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class TransactionDesciptions
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [ForeignKey(nameof(Transaction))]
        public string TransactionId { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MaxLength(800)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual  Transaction Transaction { get; set; }
    }
}
