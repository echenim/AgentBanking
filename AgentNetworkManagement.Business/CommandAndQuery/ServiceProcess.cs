using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
   public class ServiceProcess
   {
       readonly IPlatformService _platform;

       public ServiceProcess()
       {
           _platform = new ServiceRepositories(new ApplicationDbContext());
       }

       public Notification FundTransfer(string itemid, string accountnumber, string naration, string amount,
           string username)
           => _platform.FoundTransfer(itemid, accountnumber, naration, amount, username);


        public Notification FundTransfer(string itemid, string accountnumber, string naration, string amount,
          string username, string latitude, string longitude)
          => _platform.FoundTransfer(itemid, accountnumber, naration, amount, username, latitude, longitude);

        public Notification FundTransferDeposit(string accountnumber,string amount,
            string agentpin, string username, string latitude, string longitude)
         => _platform.FoundTransferDeposit(accountnumber, amount,
              agentpin,  username,  latitude,  longitude);


        public Notification FundTransferWithDrawal(string accountnumber, string amount,
            string username,string senderpin, string agentpin, string latitude, string longitude)
         => _platform.FoundTransferWithDrawal( accountnumber,  amount,
             username, senderpin, agentpin,  latitude,  longitude);

        public Notification FundTransferAccountOpening(string firstname, string lastname, string othername, string gender, string phonenumber,
            string address, string dateofbirth, string placeofbirth, string nextofkinname, string nextofkinphone, string nextofkinaddress,
            string product, string cardserialnumber, string username, string latitude, string longitude)
         => _platform.FoundTransferAccountOpening(firstname, lastname,othername,gender,phonenumber,
            address, dateofbirth,placeofbirth, nextofkinname,nextofkinphone,nextofkinaddress,
            product,  cardserialnumber, username,latitude,longitude);



        public Notification AirtimeVendingTransactions(string itemid, string phonenumber, string amount, string username)
           => _platform.AirtimeVendingTransactions(itemid, phonenumber, amount, username);
        public Notification AirtimeVendingTransactions(string itemid, string phonenumber, string amount, string username, string latitude, string longitude)
          => _platform.AirtimeVendingTransactions(itemid, phonenumber, amount, username, latitude, longitude);

        public Notification BillsPayment(string itemid, string custerId, string amount, string username)
            => _platform.BillsPayment(itemid, custerId,amount, username);

        public Notification BillsPayment(string itemid, string custerId, string amount, string username, string latitude, string longitude)
          => _platform.BillsPayment(itemid, custerId, amount, username, latitude, longitude);

        public Notification RevenueCollection(string itemid, string custerId, string amount,string username)
           => _platform.RevenueCollectionRevenueCollection(itemid, custerId, amount, username);

        public Notification RevenueCollection(string itemid, string custerId, string amount, string username, string latitude, string longitude)
          => _platform.RevenueCollectionRevenueCollection(itemid, custerId, amount, username, latitude, longitude);




    }
}
