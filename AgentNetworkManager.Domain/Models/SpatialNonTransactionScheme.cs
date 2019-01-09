using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.Models
{
    public class SpatialNonTransactionScheme
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Agent")]
        [ForeignKey(nameof(Person))]
        public string Agent { get; set; }

        [Required]
        [MaxLength(50)]
        public string Partition { get; set; }



        [Required]
        [MaxLength(50)]
        public string Transaction { get; set; }

        [Required]
        [MaxLength(15)]
        public string Latitude { get; set; }

        [Required]
        [MaxLength(15)]
        public string Longitude { get; set; }

        


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        public virtual Person Person { get; set; }
    }
}
