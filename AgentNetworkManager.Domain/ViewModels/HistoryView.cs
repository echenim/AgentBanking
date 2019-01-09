using System.Collections.Generic;
using AgentNetworkManager.Domain.DbViews;

namespace AgentNetworkManager.Domain.ViewModels
{
   public  class HistoryView
    {

       public HistoryView()
       {
           Agent = new AgentDetail();
           TransactionHistoryList = new List<TransactionHistory>();
       }

        public AgentDetail Agent { get; set; }
        public List<TransactionHistory> TransactionHistoryList { get; set; }
    }
}
