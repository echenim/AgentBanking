using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;

namespace AgentNetworkManagement.Business.Contracts
{
    interface IPlatformService
    {
        Notification FoundTransferWithDrawal(string accountnumber, string amount, string username,string senderpin, string agentpin, string latitude, string longitude);
        Notification FoundTransferDeposit(string accountnumber, string amount,string agentpin,string username, string latitude, string longitude);
        Notification FoundTransferAccountOpening(string firstname,string lastname, string othername,string gender,string phonenumber, 
            string address, string dateofbirth,string placeofbirth,string nextofkinname, string nextofkinphone,string nextofkinaddress,
            string product,string cardserialnumber, string username, string latitude, string longitude);

        Notification FoundTransfer(string itemid, string accountnumber, string naration, string amount, string username);
        Notification FoundTransfer(string itemid, string accountnumber, string naration, string amount, string username,string latitude, string longitude);

        Notification FoundTransferAccountToAccount(string senderBank, string senderAccount,string pin,string recieverBank, string recieverAccount, string amount, string username, string latitude, string longitude);

        Notification FoundTransferCashToCash(string sender, string reciever, string amount, string username, string latitude, string longitude);

        Notification FoundTransferCashToAccount(string sender, string recieverBank, string recieverAccount, string amount, string username, string latitude, string longitude);
        Notification FoundTransferAccountToCash(string senderBank,string senderAccount,string pin, string reciever, string amount, string username, string latitude, string longitude);



        Notification AirtimeVendingTransactions(string itemid, string phonenumber, string amount, string username);
        Notification AirtimeVendingTransactions(string itemid, string phonenumber, string amount, string username, string latitude, string longitude);
        Notification BillsPayment(string itemid, string custerId, string amount, string username);
        Notification BillsPayment(string itemid, string custerId, string amount, string username, string latitude, string longitude);
        Notification RevenueCollectionRevenueCollection(string itemid, string custerId, string amount, string username);
        Notification RevenueCollectionRevenueCollection(string itemid, string custerId, string amount, string username, string latitude, string longitude);

    }
}
