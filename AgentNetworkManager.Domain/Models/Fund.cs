using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class Fund
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [ForeignKey(nameof(Person))]
        public string AgentId { get; set; }

        [Required(ErrorMessage = "amount is required please")]
        [Display(Name = "Amount", Prompt = "Enter Amount")]
        public decimal Amount { get; set; }


        [Required(ErrorMessage = "fund is required please")]
        [Display(Name = "FundedOn", Prompt = "Enter Fund Date")]
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = " manager is required please")]
        [Display(Name = "Manager", Prompt = "Enter manager")]
        public string Manager { get; set; }


        [Required(ErrorMessage = "fund status is required please")]
        [Display(Name = "Status", Prompt = "Enter Fund Status")]
        public string AvailableOrNot { get; set; }
        public virtual Person Person { get; set; }
    }
}
