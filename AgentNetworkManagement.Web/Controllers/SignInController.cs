//using Microsoft.AspNet.Identity.Owin;
//using System.Web;
//using System;
//using System.Web;
//using System.Web.Http;
//using AgentNetworkManager.Domain.PermissionAndAuthorization.Managers;
//using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;
//using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;


//namespace AgentNetworkManagement.Web.Controllers
//{
//    public class SignInController : ApiController
//    {

//        public SignInController()
//        {
//        }

//        public SignInController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
//        {
//            UserManager = userManager;
//            SignInManager = signInManager;
//        }

//        private ApplicationUserManager _userManager;
//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }

//        private ApplicationSignInManager _signInManager;

//        public ApplicationSignInManager SignInManager
//        {
//            get
//            {
//                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
//            }
//            private set { _signInManager = value; }
//        }



       


//        [HttpPost]
//        [Route("signin/{username}/{password}/")]
//        public IHttpActionResult Login(string username, string password)
//        {
//            var loginViewModel = new LoginViewModel
//            {
//                Email = username,
//                Password = password
//            };
            
//            var notification = new Notification();
//            var signInStatu = SignInManagerExtensions.PasswordSignIn<ApplicationUser, string>(this.SignInManager, loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);
//            if (signInStatu == null)
//            {
//                notification.Id="1";
//                notification.Message=loginViewModel.Email;
//                notification.Success=true;
//            }
//            if (signInStatu == 3)
//            {
//                notification.Id="2";
//                notification.Message="invalide signin detail";
//                notification.Success=false;
//            }
//            if (signInStatu == 1)
//            {
//                notification.Id="3";
//                notification.Message="you have been locked out";
//                notification.Success=false;
//            }
//            return Ok(notification);
//        }
//    }
//}
