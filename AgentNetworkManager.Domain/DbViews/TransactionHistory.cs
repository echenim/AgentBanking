using System;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.DbViews
{
    public class TransactionHistory
    {
        [Key]
        public string Id { get; set; }
        public string AgentId { get; set; }
        public string Agent { get; set; }

        public string Transactions { get; set; }
        public string Descriptions { get; set; }
        public decimal Amount { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string Agency { get; set; }
        public string RegionName { get; set; }
        public string StateName { get; set; }
        public string Area { get; set; }
        public string Zone { get; set; }
        public string Clusta { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }



    }
}
