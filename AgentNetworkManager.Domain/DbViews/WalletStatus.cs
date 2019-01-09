using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.DbViews
{
   public class WalletStatus
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal CurrentBalance { get; set; }

    }
}
