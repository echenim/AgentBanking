using System.Linq;
using System.Web;
using System.Web.Http;
using AgentNetworkManagement.Business.CommandAndQuery;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Managers;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using Microsoft.AspNet.Identity.Owin;


namespace AgentNetworkManagement.Web.Controllers
{
    public class ServiceForAgentsController : ApiController
    {

        readonly  ApplicationDbContext _ctx = new ApplicationDbContext();

        #region sign-in

        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public ServiceForAgentsController()
        {
        }

        public ServiceForAgentsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

      

        public ApplicationUserManager UserManager
        {
            get
            {
                return this._userManager ?? OwinContextExtensions.GetUserManager<ApplicationUserManager>(HttpContextExtensions.GetOwinContext(HttpContext.Current));
            }
            private set
            {
                this._userManager = value;
            }
        }
        
     

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this._signInManager ?? OwinContextExtensions.Get<ApplicationSignInManager>(HttpContextExtensions.GetOwinContext(HttpContext.Current));
            }
            private set
            {
                this._signInManager = value;
            }
        }


        [HttpPost]
        [Route("signin/{username}/{password}/")]
        public IHttpActionResult Login(string username, string password)
        {
            var signInStatu = SignInManager.PasswordSignIn(username, password,false, shouldLockout: false);

            var notification = new Notification();

            switch (signInStatu)
            {
                  case  SignInStatus.Success:
                    notification.Id = "1";
                    notification.Message = username;
                    notification.Success = true;
                     break;
                   case SignInStatus.LockedOut:
                    notification.Id = "1";
                    notification.Message = $"{username} : you have been locked out of the system";
                    notification.Success = false;
                    break;
                    case SignInStatus.Failure:
                    notification.Id = "1";
                    notification.Message = $"{username} : invalide signin detail";
                    notification.Success = false;
                    break;
                    case  SignInStatus.RequiresVerification:
                    notification.Id = "1";
                    notification.Message = $"{username} : your credential requires additional verfication detail";
                    notification.Success = false;
                   break;
                   
               }
           
            var stam = new SpatialSystem().NonTransactionData(username, "login was successful", "0.0000", "0.0000");
            if (stam)
            {
                
            }
            return Ok(notification);
        }


        #endregion


        #region service

        [HttpPost]
        [Route("Telcos/transaction/{itemid}/{phonenumber}/{amount}/{username}/")]
        public IHttpActionResult AirtimeVendingTransactions(string itemid, string phonenumber, string amount, string username)
        {
            var notification = new ServiceProcess().AirtimeVendingTransactions(itemid.Trim(), phonenumber.Trim(), amount.Trim(), username.Trim());
            return Ok(notification);
        }

        [HttpPost]
        [Route("Telcos/transaction/{itemid}/{phonenumber}/{amount}/{username}/{latitude}/{longitude}/")]
        public IHttpActionResult AirtimeVendingTransactions(string itemid, string phonenumber, string amount, string username, string latitude, string longitude)
        {
            var notification = new ServiceProcess().AirtimeVendingTransactions(itemid.Trim(), phonenumber.Trim(), amount.Trim(), username.Trim(), latitude, longitude);
            return Ok(notification);
        }


        [HttpGet]
        [Route("Agent/Balance/{username}/")]
        public IHttpActionResult Balance(string username)
        {
            var walletStatuses = new FundWalletLogic().GetBalance(s => s.Email.ToLower().Equals(username.ToLower()));
            return Ok(walletStatuses);
         }


        [HttpGet]
        [Route("Banks/All/")]
        public IHttpActionResult Banks()
        {
            var bankses = _ctx.Bankses.OrderBy(s=>s.BankName);
            return Ok(bankses);
        }


        [HttpGet]
        [Route("Sam/All/")]
        public IHttpActionResult Nested()
        {
            var data = _ctx.Region
                .GroupBy(s => s.National.Name)
                .Select(p => new
                {
                    National = p.Key,
                    data = p.ToList().Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name
                    })

                }).ToList();
            return Ok(data);
        }


        [HttpGet]
        [Route("Bills/All/")]
        public IHttpActionResult Bills()
        {
            var bankses = _ctx.Billers.OrderBy(s => s.Name);
            return Ok(bankses);
        }



        [HttpPost]
        [Route("Bills/transaction/{itemid}/{custerId}/{amount}/{username}/")]
        public IHttpActionResult BillsPayment(string itemid, string custerId, string amount, string username)
        {
            var notification = new ServiceProcess().BillsPayment(itemid.Trim(), custerId.Trim(), amount.Trim(), username.Trim());
            return Ok(notification);
        }

        [HttpPost]
        [Route("Bills/transaction/{itemid}/{custerId}/{amount}/{username}/{latitude}/{longitude}/")]
        public IHttpActionResult BillsPayment(string itemid, string custerId, string amount, string username, string latitude, string longitude)
        {
            var notification = new ServiceProcess().BillsPayment(itemid.Trim(), custerId.Trim(), amount.Trim(), username.Trim(), latitude, longitude);
            return Ok(notification);
        }

        //[HttpPost]
        //[Route("Banks/transaction/{itemid}/{accountnumber}/{naration}/{amount}/{username}/")]
        //public IHttpActionResult FoundTransfer(string itemid, string accountnumber, string naration, string amount, string username)
        //{
        //    var notification = new ServiceProcess().FundTransfer(itemid.Trim(), accountnumber.Trim(), naration.Trim(), amount.Trim(), username.Trim());
        //    return Ok(notification);
        //}

        [HttpPost]
        [Route("Banks/transaction/{itemid}/{accountnumber}/{naration}/{amount}/{username}/{latitude}/{longitude}/")]
        public IHttpActionResult FoundTransfer(string itemid, string accountnumber, string naration, string amount, string username, string latitude, string longitude)
        {
            var notification = new ServiceProcess().FundTransfer(itemid.Trim(), accountnumber.Trim(), naration.Trim(), amount.Trim(), username.Trim(), latitude, longitude);
            return Ok(notification);
        }

        [HttpPost]
        [Route("Banks/accountopening/{firstname}/{lastname}/{othername}/{gender}/{phonenumber}/{address}/{dateofbirth}/{placeofbirth}/{nextofkinname}/{nextofkinphone}/{nextofkinaddress}/{product}/{cardserialnumber}/{username}/{latitude}/{longitude}/")]
        public IHttpActionResult FoundTransferAccountOpening(string firstname, string lastname, string othername, string gender, string phonenumber, string address, string dateofbirth, string placeofbirth, string nextofkinname, string nextofkinphone, string nextofkinaddress, string product, string cardserialnumber, string username, string latitude, string longitude)
        {
            var notification = new ServiceProcess().FundTransferAccountOpening(firstname, lastname, othername, gender, phonenumber, address, dateofbirth, placeofbirth, nextofkinname, nextofkinphone, nextofkinaddress, product, cardserialnumber, username, latitude, longitude);
            return Ok(notification);
        }

       




        [HttpPost]
        [Route("Banks/deposit/{bankId}/{accountnumber}/{amount}/{agentpin}/{username}/{latitude}/{longitude}/")]
        public IHttpActionResult FoundTransferDeposit(string bankId, string accountnumber, string amount, string agentpin, string username, string latitude, string longitude)
        {
            var notification = new ServiceProcess().FundTransferDeposit(accountnumber, amount, agentpin, username, latitude, longitude);
            return Ok(notification);
        }

        [HttpPost]
        [Route("Banks/withdrawal/{bankId}/{accountnumber}/{customerpin}/{otp}/{amount}/{agentpin}/{username}/{latitude}/{longitude}/")]
        public IHttpActionResult FoundTransferWithdrawal(string bankId, string accountnumber, string customerpin, string otp, string amount, string agentpin, string username, string latitude, string longitude)
        {
            var notification = new ServiceProcess().FundTransferWithDrawal(accountnumber, amount, username, customerpin, agentpin, latitude, longitude);
            return Ok(notification);
        }

        [HttpGet]
        [Route("Revenue/All/")]
        public IHttpActionResult Revenue()
        {
            var bankses = _ctx.RevenueCollection.OrderBy(s => s.Name);
            return Ok(bankses);
        }




      


        [HttpPost]
        [Route("Revenue/transaction/{itemid}/{custerId}/{amount}/{username}/")]
        public IHttpActionResult RevenueCollection(string itemid, string custerId, string amount, string username)
        {
           var notification = new ServiceProcess().RevenueCollection(itemid.Trim(), custerId.Trim(), amount.Trim(), username.Trim());
            return Ok(notification);
        }

        [HttpPost]
        [Route("Revenue/transaction/{itemid}/{custerId}/{amount}/{username}/{latitude}/{longitude}/")]
        public IHttpActionResult RevenueCollection(string itemid, string custerId, string amount, string username, string latitude, string longitude)
        {
            var notification = new ServiceProcess().RevenueCollection(itemid.Trim(), custerId.Trim(), amount.Trim(), username.Trim(), latitude, longitude);
            return Ok(notification);
        }

        [HttpGet]
        [Route("Telcos/All/")]
        public IHttpActionResult Telcos()
        {
            var bankses = _ctx.TelComs.OrderBy(s => s.Name);
            return Ok(bankses);
        }

        [HttpGet]
        [Route("Agent/Transaction/{username}/")]
        public IHttpActionResult TransactionActivities(string username)
        {
            var bankses = _ctx.AgentExpens.OrderByDescending(s => s.CreatedOn);
            return Ok(bankses);
        }



    #endregion


}
}
