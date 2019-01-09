using System;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.DbViews
{
    public class LastTransaction
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeOfTransaction { get; set; }
        public decimal DebitedAmount { get; set; }
        public decimal TransFee { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Agency { get; set; }
        public string RegionName { get; set; }
        public string StateName { get; set; }
        public string Area { get; set; }
        public string Zone { get; set; }
        public string Clusta { get; set; }

    }
}
