using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentNetworkManager.Domain.DbViews
{
    public class FundWallet
    {
        [Key]
        [ReadOnly(true)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public decimal Amount { get; set; }
        public string Manager { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Agency { get; set; }
        public string RegionName { get; set; }
        public string StateName { get; set; }
        public string Area { get; set; }
        public string Zone { get; set; }
        public string Clusta { get; set; }

        [NotMapped]
        public string NameAndPosition => $"{Name} ( {Position} )";
    }
}
