﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Echenim.Nine.Util.Audit
{
    public class SystemAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "User")]
        public string Originator { get; set; }

        [Required]
        [MaxLength(400)]
        [DataType(DataType.Text)]
        [Display(Name = "WHat Cause The Exception")]
        public string Reason { get; set; }


        [Required]
        [MaxLength(10)]
        [DataType(DataType.Text)]
        [Display(Name = "Error Level")]
        public string Ranking { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string DataKey { get; set; }

        
        [DataType(DataType.Text)]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Exception Detail")]
        public string Exceptions { get; set; }

        [Required]
        public DateTime Stamp { get; set; }


        

    }
}
