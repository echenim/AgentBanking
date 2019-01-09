using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.Models
{
    public class PersonAndFunctionalArea
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "User")]
        
        public string PersoNameId { get; set; }

        [Required]
        [Display(Name = "Function Area")]
        public string WorkAreaId { get; set; }

        [ReadOnly(true)]
        public DateTime CreatedOn { get; set; }




    }
}
