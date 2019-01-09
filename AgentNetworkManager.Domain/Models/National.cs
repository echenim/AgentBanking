using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class National
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Platform")]
        public string Name { get; set; }


        [ForeignKey(nameof(PlatformManagingRule))]
        [Display(Name = "Platform")]
        public string ProcessKind { get; set; }

        public virtual PlatformManagingRule PlatformManagingRule { get; set; }

    }
}
