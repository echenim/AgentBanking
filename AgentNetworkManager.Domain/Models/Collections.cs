using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.Models
{
    public class Collections
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required(ErrorMessage = "collections name is required please")]
        [Display(Name = "Name", Prompt = "Enter Name ")]
        [StringLength(150, ErrorMessage = "name  must not be longer than 150 characters")]
        public string Name { get; set; }





    }
}
