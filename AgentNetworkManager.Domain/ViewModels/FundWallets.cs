using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.ViewModels
{
    public class FundWallets
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Agent", Prompt = "Enter Agent")]
        public string Agent { get; set; }
        
        [Required(ErrorMessage = "Please enter amount")]
        [Display(Name = "Fund", Prompt = "Enter Fund")]
        public decimal Fund { get; set; }
        

    }
}
