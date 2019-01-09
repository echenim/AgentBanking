using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using AgentNetworkManagement.Business.CommandAndQuery;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.Models;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using Echenim.Nine.Util.UniqueReferenceGenerator.Processs;

namespace AgentNetworkManagement.Business.Repositories
{
    internal class ServiceRepositories:IPlatformService
    {
        private readonly ApplicationDbContext _ctx;
       // private readonly ApplicationDbContext _ctx_log = new ApplicationDbContext();

        public ServiceRepositories(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        

        #region Implementation of IPlatformService

        public Notification FoundTransferWithDrawal(string accountnumber, string amount,
            string username, string senderpin, string agentpin, string latitude, string longitude)

        {
            var notification = new Notification();
            var description = $"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ";
            //  var bankObj = _ctx.Bankses.SingleOrDefault(s => s.BankCode.Equals(itemid));
            /*
             * get the agent person id from the agent wallet view_table
             */
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username.ToLower()));
            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Transfer"));

            if (agentwalletinformation != null && fees != null)
            {
                var debit = agentwalletinformation.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = agentwalletinformation.Id,
                                Name = $"Fund Withdrawal",
                                PreviousBalance = agentwalletinformation.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();

                            var geolocation = new SpatialTransactionScheme
                            {
                                Id = new ReferenceGenerator().NGeneratedId(12),
                                AgentId = agentwalletinformation.Id,
                                Partition = "Transaction",
                                Transaction = "Bank Transaction Fund Deposit",
                                Longitude = longitude,
                                Latitude = latitude,
                                TransactionId = transaction.Id,
                                CreatedOn = DateTime.Now

                            };
                            _ctx.SpatialTransactional.Add(geolocation);
                            _ctx.SaveChanges();

                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;

                            //  Log4NetAudit.SuccessAudit($"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ", Log4NetAudit.Rank.SUCCESS, username,"","Fund transfer failed");

                        }
                        catch (DbEntityValidationException e)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = $"transaction failed ";
                            notification.Success = false;
                            var action = $"Fund Withdrawal";
                            var sb = new StringBuilder();
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                sb.AppendLine(
                               $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                                }
                            }
                            var message = sb.ToString();
                            new SystemAuditProcess().EntityError(username, action, "ENTITY ERROR", message);
                        }
                        catch (Exception ex)
                        {
                            notification.Id = "2";
                            notification.Message = "transaction was failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit(
                            //    $"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ",
                            //    Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }
                }

            }
            return notification;
        }



        public Notification FoundTransferDeposit(string accountnumber, string amount,
             string agentpin, string username, string latitude, string longitude)


        {
            var notification = new Notification();
            var description = $"Bank Transaction : (NGN{amount}) was deposited to accountno ({accountnumber}) ";
            //  var bankObj = _ctx.Bankses.SingleOrDefault(s => s.BankCode.Equals(itemid));
            /*
             * get the agent person id from the agent wallet view_table
             */
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username.ToLower()));
            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Transfer"));

            if (agentwalletinformation != null && fees != null)
            {
                var debit = agentwalletinformation.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = agentwalletinformation.Id,
                                Name = $"Fund Deposit ",
                                PreviousBalance = agentwalletinformation.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();

                            var geolocation = new SpatialTransactionScheme
                            {
                                Id = new ReferenceGenerator().NGeneratedId(12),
                                AgentId = agentwalletinformation.Id,
                                Partition = "Transaction",
                                Transaction = "Bank Transaction Fund Deposit",
                                Longitude = longitude,
                                Latitude = latitude,
                                TransactionId = transaction.Id,
                               
                                CreatedOn = DateTime.Now

                            };
                            _ctx.SpatialTransactional.Add(geolocation);
                            _ctx.SaveChanges();

                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;

                            //  Log4NetAudit.SuccessAudit($"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ", Log4NetAudit.Rank.SUCCESS, username,"","Fund transfer failed");

                        }
                        catch (DbEntityValidationException e)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = $"transaction failed ";
                            notification.Success = false;
                            var action = $"Fund Deposit ";
                            var sb = new StringBuilder();
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                sb.AppendLine(
                               $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                                }
                            }
                            var message = sb.ToString();
                            new SystemAuditProcess().EntityError(username, action, "ENTITY ERROR", message);
                        }
                        catch (Exception ex)
                        {
                            notification.Id = "2";
                            notification.Message = "transaction was failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit(
                            //    $"Bank Transaction : (NGN{amount}) was tranfered to accountno ({accountnumber}) ",
                            //    Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }
                }

            }
            return notification;
        }


        public Notification FoundTransferAccountOpening(string firstname, string lastname, string othername,
            string gender,
            string phonenumber, string address, string dateofbirth, string placeofbirth, string nextofkinname,
            string nextofkinphone, string nextofkinaddress, string product, string cardserialnumber, string username,
            string latitude, string longitude)
        {
            var notification = new Notification();
            var description = $"Account Opening : account opening for  ({firstname} {lastname})  ";
            // var bankObj = _ctx.Bankses.SingleOrDefault(s => s.BankCode.Equals(itemid));
            var walletStatus = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username));
            //var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Transfer"));

            if (walletStatus != null)
            {
                var debit = walletStatus.CurrentBalance - (Convert.ToDecimal("0.0") );
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = walletStatus.Id,
                                Name = $"Bank Transaction : account opening for  {firstname} {lastname}",
                                PreviousBalance = walletStatus.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = 0,
                                TransFee = 0
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();

                            var geolocation = new SpatialTransactionScheme
                            {
                                Id = new ReferenceGenerator().NGeneratedId(12),
                                AgentId = walletStatus.Id,
                                Partition = "Transaction",
                                Transaction = $"Account opening for  {firstname} {lastname}",
                                Longitude = longitude,
                                Latitude = latitude,
                                TransactionId = transaction.Id,

                                CreatedOn = DateTime.Now

                            };
                            _ctx.SpatialTransactional.Add(geolocation);
                            _ctx.SaveChanges();

                            #region account openin information

                            var customerInfirmation = new CustomerBankAccountOpening
                            {
                                Id = new ReferenceGenerator().NGeneratedId(12),
                                FirstName = firstname,
                                LastName = lastname,
                                OtherName = othername,
                                Sex = gender,
                                PhoneNumber = phonenumber,
                                Dob = dateofbirth,
                                Address = address
                            };
                            _ctx.CustomerBankAccountOpening.Add(customerInfirmation);
                            _ctx.SaveChanges();
                            var customerBank = new CustomerBankCardInformation
                            {
                                Id = new ReferenceGenerator().NGeneratedId(12),
                                CustomerId = customerInfirmation.Id,
                                CardSerialNumber = cardserialnumber,
                                ProductName = product
                                
                            };

                            _ctx.CustomerBankCardInformation.Add(customerBank);
                            _ctx.SaveChanges();
                            #endregion

                            trans.Commit();

                            var messageBody = $"ur accountno is:{customerBank.AccountNumber}";

                          //  "b617ff4c", "4b0369fbc50a3fdd"
                        //    https://rest.nexmo.com/sms/json?api_key=b617ff4c&api_secret=4b0369fbc50a3fdd&to=+2347035547841&from=NEXMO&text=hello+from+Nexmo

                            //var sms = new sms().SendSms($"+234{phonenumber}","UBA", messageBody, "b617ff4c", "4b0369fbc50a3fdd");

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;

                            //  Log4NetAudit.SuccessAudit($"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ", Log4NetAudit.Rank.SUCCESS, username,"","Fund transfer failed");

                        }
                        catch (DbEntityValidationException e)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = $"transaction failed ";
                            notification.Success = false;
                            var action = $"Bank Transaction : account opening for  {firstname} {lastname}";
                            var sb = new StringBuilder();
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                sb.AppendLine(
                               $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                                }
                            }
                            var message = sb.ToString();
                            new SystemAuditProcess().EntityError(username, action, "ENTITY ERROR", message);
                        }
                        catch (Exception ex)
                        {
                            notification.Id = "2";
                            notification.Message = "transaction was failed";
                            notification.Success = false;
                            //  Log4NetAudit.FailureAudit($"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ", Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }


                }
            }


            return notification;
        }

        public Notification FoundTransfer(string itemid, string accountnumber, string naration, string amount, string username)
        {
            var notification = new Notification();
            var description = $"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ";
            var bankObj = _ctx.Bankses.SingleOrDefault(s => s.BankCode.Equals(itemid));
            var walletStatus = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username));
            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Transfer"));

            if (walletStatus != null && fees != null)
            {
                var debit = walletStatus.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = walletStatus.Id,
                                Name = $"Found Transfer ( {bankObj.BankName} )",
                                PreviousBalance = walletStatus.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();



                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;
                          
                          //  Log4NetAudit.SuccessAudit($"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ", Log4NetAudit.Rank.SUCCESS, username,"","Fund transfer failed");

                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = "transaction was failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit($"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ", Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }


                }
            }


            return notification;
        }

        public Notification FoundTransfer(string itemid, string accountnumber, string naration, string amount,
            string username, string latitude, string longitude)
        {
            var notification = new Notification();
            var description = $"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ";
            var bankObj = _ctx.Bankses.SingleOrDefault(s => s.BankCode.Equals(itemid));

            /*
            * get the agent person id from the agent wallet view_table
            */
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username.ToLower()));



            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Transfer"));

            if (agentwalletinformation != null && fees != null)
            {
                var debit = agentwalletinformation.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = agentwalletinformation.Id,
                                Name = $"Bank Transaction ( {bankObj.BankName} )",
                                PreviousBalance = agentwalletinformation.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();

                            var geolocation = new SpatialTransactionScheme
                            {
                                Id = new ReferenceGenerator().NGeneratedId(12),
                                AgentId = agentwalletinformation.Id,
                                Partition = "Transaction",
                                Transaction = "Bank Transaction Fund Deposit",
                                Longitude = longitude,
                                Latitude = latitude,
                                TransactionId = transaction.Id,
                                CreatedOn = DateTime.Now

                            };
                            _ctx.SpatialTransactional.Add(geolocation);
                            _ctx.SaveChanges();

                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;

                            //  Log4NetAudit.SuccessAudit($"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ", Log4NetAudit.Rank.SUCCESS, username,"","Fund transfer failed");

                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = "transaction was failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit(
                            //    $"Fund Transfer : (NGN{amount}) was tranfered to accountno ({accountnumber}) ",
                            //    Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }
                }

            }
            return notification;
        }

        public Notification FoundTransferAccountToAccount(string senderBank, string senderAccount, string pin, string recieverBank,
            string recieverAccount, string amount, string username, string latitude, string longitude)
        {
            throw new NotImplementedException();
        }

        public Notification FoundTransferCashToCash(string sender, string reciever, string amount, string username, string latitude,
            string longitude)
        {
            throw new NotImplementedException();
        }

        public Notification FoundTransferCashToAccount(string sender, string recieverBank, string recieverAccount, string amount,
            string username, string latitude, string longitude)
        {
            throw new NotImplementedException();
        }

        public Notification FoundTransferAccountToCash(string senderBank, string senderAccount, string pin, string reciever,
            string amount, string username, string latitude, string longitude)
        {
            throw new NotImplementedException();
        }


        public Notification AirtimeVendingTransactions(string itemid, string phonenumber, string amount, string username)
        {
            var notification = new Notification();

             var telcoObj = _ctx.TelComs.SingleOrDefault(s => s.Code.Equals(itemid));
             //var telcoObj = _ctx.TelComs.Find(itemid);

            /*
           * get the agent person id from the agent wallet view_table
           */
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username.ToLower()));


            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Airtime"));

            var description = $"AirTime Vending : {telcoObj.Name} airtime topup of (NGN{amount}) on phone number ({phonenumber})";

            if (agentwalletinformation != null && fees != null)
            {
                var debit = agentwalletinformation.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = agentwalletinformation.Id,
                                Name = $"Airtime ({telcoObj.Name})",
                                PreviousBalance = agentwalletinformation.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();
                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;
                          //  Log4NetAudit.SuccessAudit($"AirTime Vending : {telcoObj.Name} airtime topup of (NGN{amount}) on phone number ({phonenumber})", Log4NetAudit.Rank.SUCCESS, username, "", "Fund transfer failed");

                        }
                        catch (DbEntityValidationException e)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = $"transaction failed ";
                            notification.Success = false;
                            var action = $"Airtime ({telcoObj.Name})";
                            var sb = new StringBuilder();
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                sb.AppendLine(
                               $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                                }
                            }
                            var message = sb.ToString();
                            new SystemAuditProcess().EntityError(username, action, "ENTITY ERROR", message);
                        }
                        catch (Exception ex)
                        {


                            notification.Id = "2";
                            notification.Message = "transaction was failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit($"AirTime Vending : {telcoObj.Name} airtime topup of (NGN{amount}) on phone number ({phonenumber})", Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }


                }
            }


            return notification;
        }
        public Notification AirtimeVendingTransactions(string itemid, string phonenumber, string amount, string username, string latitude, string longitude)
        {
            var notification = new Notification();

            var telcoObj = _ctx.TelComs.SingleOrDefault(s => s.Code.Equals(itemid));
           // var telcoObj = _ctx.TelComs.Find(itemid);

            /*
           * get the agent person id from the agent wallet view_table
           */
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username.ToLower()));


            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Airtime"));
            
            var description = $"AirTime Vending : {telcoObj.Name} airtime topup of (NGN{amount}) on phone number ({phonenumber})";

            if (agentwalletinformation != null && fees != null)
            {
                var debit = agentwalletinformation.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = agentwalletinformation.Id,
                                Name = $"Airtime ({telcoObj.Name})",
                                PreviousBalance = agentwalletinformation.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };

                          
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();

                            var geolocation = new SpatialTransactionScheme
                            {
                                Id = new ReferenceGenerator().NGeneratedId(12),
                                AgentId = agentwalletinformation.Id,
                                Partition = "Transaction",
                                Transaction = "Bank Transaction Fund Deposit",
                                Longitude = longitude,
                                Latitude = latitude,
                                TransactionId = transaction.Id,
                                CreatedOn = DateTime.Now

                            };
                            _ctx.SpatialTransactional.Add(geolocation);
                            _ctx.SaveChanges();


                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;
                            //  Log4NetAudit.SuccessAudit($"AirTime Vending : {telcoObj.Name} airtime topup of (NGN{amount}) on phone number ({phonenumber})", Log4NetAudit.Rank.SUCCESS, username, "", "Fund transfer failed");

                        }
                        catch (DbEntityValidationException e)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = $"transaction failed ";
                            notification.Success = false;
                            var action = $"Airtime ({telcoObj.Name})";
                            var sb = new StringBuilder();
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                sb.AppendLine(
                               $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                                }
                            }
                            var message = sb.ToString();
                            new SystemAuditProcess().EntityError(username, action, "ENTITY ERROR", message);
                        }
                        catch (Exception ex)
                        {

                            
                            notification.Id = "2";
                            notification.Message = "transaction was failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit($"AirTime Vending : {telcoObj.Name} airtime topup of (NGN{amount}) on phone number ({phonenumber})", Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }


                }
            }


            return notification;
        }

        public Notification BillsPayment(string itemid, string custerId, string amount, string username)
        {
            var notification = new Notification();
            var billcoObj = _ctx.Billers.Find(itemid);
            //var billcoObj = _ctx.Billers.SingleOrDefault(s => s.Code.Equals(itemid));

            /*
           * get the agent person id from the agent wallet view_table
           */
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username.ToLower()));


            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Bill & Collection"));

            var description = $"Bills Payment : customer with id : ({custerId}) paid (NGN{amount})  for {billcoObj.Name}";

            if (agentwalletinformation != null && fees != null)
            {
                var debit = agentwalletinformation.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = agentwalletinformation.Id,
                                Name = $"Bill Payment ( {billcoObj.Name} of  NGN{amount} )",
                                PreviousBalance = agentwalletinformation.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();
                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;


                        }
                        catch (DbEntityValidationException e)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = $"transaction failed ";
                            notification.Success = false;
                            var action = $"Bill Payment ( {billcoObj.Name} of  NGN{amount} )";
                            var sb = new StringBuilder();
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                sb.AppendLine(
                               $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                                }
                            }
                            var message = sb.ToString();
                            new SystemAuditProcess().EntityError(username, action, "ENTITY ERROR", message);
                        }
                        catch (Exception ex)
                        {

                            notification.Id = "2";
                            notification.Message = "transaction was failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit($"Bill Payment : ( {billcoObj.Name} bill of  NGN{amount} )", Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }


                }
            }


            return notification;
        }
        public Notification BillsPayment(string itemid, string custerId, string amount, string username, string latitude, string longitude)
        {
            var notification = new Notification();
           // var billcoObj = _ctx.Billers.Find(itemid);
            var billcoObj = _ctx.Billers.SingleOrDefault(s => s.Code.Equals(itemid));

            /*
           * get the agent person id from the agent wallet view_table
           */
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username.ToLower()));


            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Bill & Collection"));

            var description = $"Bills Payment : customer with id : ({custerId}) paid (NGN{amount})  for {billcoObj.Name}";

            if (agentwalletinformation != null && fees != null)
            {
                var debit = agentwalletinformation.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = agentwalletinformation.Id,
                                Name = $"Bill Payment ( {billcoObj.Name} of  NGN{amount} )",
                                PreviousBalance = agentwalletinformation.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();

                            var geolocation = new SpatialTransactionScheme
                            {
                                Id = new ReferenceGenerator().NGeneratedId(12),
                                AgentId = agentwalletinformation.Id,
                                Partition = "Transaction",
                                Transaction = "Bank Transaction Fund Deposit",
                                Longitude = longitude,
                                Latitude = latitude,
                                TransactionId = transaction.Id,
                                CreatedOn = DateTime.Now

                            };
                            _ctx.SpatialTransactional.Add(geolocation);
                            _ctx.SaveChanges();

                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;


                        }
                        catch (DbEntityValidationException e)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = $"transaction failed ";
                            notification.Success = false;
                            var action = $"Bill Payment ( {billcoObj.Name} of  NGN{amount} )";
                            var sb = new StringBuilder();
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                sb.AppendLine(
                               $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                                }
                            }
                            var message = sb.ToString();
                            new SystemAuditProcess().EntityError(username, action, "ENTITY ERROR", message);
                        }
                        catch (Exception ex)
                        {

                            notification.Id = "2";
                            notification.Message = "transaction was failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit($"Bill Payment : ( {billcoObj.Name} bill of  NGN{amount} )", Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }


                }
            }


            return notification;
        }
        public Notification RevenueCollectionRevenueCollection(string itemid, string custerId, string amount, string username)
        {
            var notification = new Notification();

            var revenucoObj = _ctx.RevenueCollection.SingleOrDefault(s => s.Code.Equals(itemid));
           // var revenucoObj = _ctx.RevenueCollection.Find(itemid);

            /*
           * get the agent person id from the agent wallet view_table
           */
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username.ToLower()));


            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Bill & Collection"));

            var description = $"Revenue Collection : customer with id : ({custerId}) paid (NGN{amount})  for {revenucoObj.Name}";

            if (agentwalletinformation != null && fees != null)
            {
                var debit = agentwalletinformation.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = agentwalletinformation.Id,
                                Name = $"Revenue Collection ( {revenucoObj.Name} )",
                                PreviousBalance = agentwalletinformation.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();
                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;


                        }
                        catch (DbEntityValidationException e)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = $"transaction failed ";
                            notification.Success = false;
                            var action = $"Revenue Collection ( {revenucoObj.Name} )";
                            var sb = new StringBuilder();
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                sb.AppendLine(
                               $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                                }
                            }
                            var message = sb.ToString();
                            new SystemAuditProcess().EntityError(username, action, "ENTITY ERROR", message);
                        }
                        catch (Exception ex)
                        {
                           
                            notification.Id = "2";
                            notification.Message = "transaction failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit(description, Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }


                }
            }


            return notification;
        }
        public Notification RevenueCollectionRevenueCollection(string itemid, string custerId, string amount, string username, string latitude, string longitude)
        {
            var notification = new Notification();

             var revenucoObj = _ctx.RevenueCollection.SingleOrDefault(s => s.Code.Equals(itemid));
            //var revenucoObj = _ctx.RevenueCollection.Find(itemid);

            /*
           * get the agent person id from the agent wallet view_table
           */
            var agentwalletinformation = _ctx.AgentCurrentWalletStatus.SingleOrDefault(s => s.Email.Equals(username.ToLower()));


            var fees = _ctx.Fees.SingleOrDefault(s => s.FeeName.Equals("Bill & Collection"));

            var description = $"Revenue Collection : customer with id : ({custerId}) paid (NGN{amount})  for {revenucoObj.Name}";

            if (agentwalletinformation != null && fees != null)
            {
                var debit = agentwalletinformation.CurrentBalance - (Convert.ToDecimal(amount) + fees.Amount);
                if (debit >= 0)
                {
                    using (var trans = _ctx.Database.BeginTransaction())
                    {
                        try
                        {

                            var transaction = new Transaction
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                PersonId = agentwalletinformation.Id,
                                Name = $"Revenue Collection ( {revenucoObj.Name} )",
                                PreviousBalance = agentwalletinformation.CurrentBalance,
                                CurrentBalance = debit,
                                DebitedAount = Convert.ToDecimal(amount),
                                TransFee = fees.Amount
                            };
                            _ctx.Transactions.Add(transaction);
                            _ctx.SaveChanges();

                            var transactiondescription = new TransactionDesciptions
                            {
                                Id = new ReferenceGenerator().NGeneratedId(10),
                                TransactionId = transaction.Id,
                                Description = description,
                                CreatedOn = DateTime.Now
                            };
                            _ctx.TransactionDesciptionses.Add(transactiondescription);
                            _ctx.SaveChanges();

                            var geolocation = new SpatialTransactionScheme
                            {
                                Id = new ReferenceGenerator().NGeneratedId(12),
                                AgentId = agentwalletinformation.Id,
                                Partition = "Transaction",
                                Transaction = "Bank Transaction Fund Deposit",
                                Longitude = longitude,
                                Latitude = latitude,
                                TransactionId = transaction.Id,

                                CreatedOn = DateTime.Now

                            };
                            _ctx.SpatialTransactional.Add(geolocation);
                            _ctx.SaveChanges();

                            trans.Commit();

                            notification.Id = "1";
                            notification.Message = "transaction was successful";
                            notification.Success = true;


                        }
                        catch (DbEntityValidationException e)
                        {
                            trans.Rollback();
                           
                           // var action = $"Revenue Collection ( {revenucoObj.Name} )";
                            var sb = new StringBuilder();
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                sb.AppendLine(
                               $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                                }
                            }
                            //var message = sb.ToString();
                            notification.Id = "3";
                            notification.Message = sb.ToString();
                            notification.Success = false;
                           
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            notification.Id = "2";
                            notification.Message = $"transaction failed";
                            notification.Success = false;
                            //Log4NetAudit.FailureAudit(description, Log4NetAudit.Rank.ERROR, username, "", "Fund transfer failed", ex);
                        }
                    }


                }
            }


            if (notification.Id == "3")
            {
                var action = $"Revenue Collection ( {revenucoObj.Name} )";
                new SystemAuditProcess().EntityError(username, action, "ENTITY ERROR", notification.Message);
            }
           
            return notification;
        }

        #endregion

       


    }
}
