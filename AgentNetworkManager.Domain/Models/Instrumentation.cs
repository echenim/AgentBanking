using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.Models
{
   public class Instrumentation
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required(ErrorMessage = "tool is required please")]
        [Display(Name = "Tool", Prompt = "Enter Tool ")]
        [StringLength(150, ErrorMessage = "tool  must not be longer than 150 characters")]
        public string Name { get; set; }
    }
}
