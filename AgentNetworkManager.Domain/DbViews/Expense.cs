using System;
using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.DbViews
{
    public class Expense
    {
         [Key]
         public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Transactions { get; set; }
        public string Descriptions { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        
     
    }

}
