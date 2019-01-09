using System;
using System.Linq;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using AgentNetworkManagement.Business.CommandAndQuery;
using AgentNetworkManager.Domain.Models;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Managers;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;
using AgentNetworkManager.Domain.ViewModels;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using Microsoft.AspNet.Identity;
using PagedList;

namespace AgentNetworkManagement.Web.Controllers
{
    [Authorize]
    public class UserManagementController : Controller
    {

        private ApplicationUserManager _userManager;

        private ApplicationGroupManager _groupManager;

        private ApplicationRoleManager _roleManager;

        public ApplicationGroupManager GroupManager
        {
            get { return _groupManager ?? new ApplicationGroupManager(); }
            private set { this._groupManager = value; }
        }

       
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext()
                    .Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

       
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public UserManagementController()
        {
        }

        public UserManagementController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                base.ModelState.AddModelError("", error);
            }
        }

        private void AddErrors(Notification result)
        {
            base.ModelState.AddModelError("", $" Success: {result.Success}  :  {result.Message}");
        }


        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var member = new MemberLogic().Find(s => s.Id.Equals(User.Identity.GetUserId()));

            var networkStruction = member.Position == "Administrator"
                ? new MemberLogic().Get()
                : (member.Position == "Platform Manager"
                    ? new MemberLogic().Get(s => s.Agency.Equals(member.Agency))
                    : (member.Position == "Regional Manager"
                        ? new MemberLogic().Get(
                            s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName))
                        : (member.Position == "State Manager"
                            ? new MemberLogic().Get(
                                s =>
                                    s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) &&
                                    s.StateName.Equals(member.StateName))
                            : (member.Position == "Area Manager"
                                ? new MemberLogic().Get(
                                    s =>
                                        s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) &&
                                        s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area))
                                : (member.Position == "Zonal Manager"
                                    ? new MemberLogic().Get(
                                        s =>
                                            s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) &&
                                            s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area) &&
                                            s.Zone.Equals(member.Zone))
                                    : new MemberLogic().Get(
                                        s =>
                                            s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) &&
                                            s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area) &&
                                            s.Zone.Equals(member.Zone) && s.Clusta.Equals(member.Clusta) &&
                                            member.Position.Equals("Field Agents")))))));


            if (!String.IsNullOrEmpty(searchString))
            {
                networkStruction = networkStruction.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "Date":
                    networkStruction = networkStruction.OrderBy(s => s.Name);
                    break;

                default: // Name ascending 
                    networkStruction = networkStruction.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(networkStruction.ToPagedList(pageNumber, pageSize));




        }


        public ActionResult AssignToNetwork()
        {
            var member = new MemberLogic().Find(s => s.Id.Equals(User.Identity.GetUserId()));

            var addAgentModel = new RegisterAndAssignUserToNetWork();
            addAgentModel.AvailableSex.Add(new SelectListItem()
            {
                Text = "Select Sex",
                Value = ""
            });
            var sex = new GenderProcess().GetSex().OrderBy(s => s.Name);
            foreach (var item in sex)
            {
                addAgentModel.AvailableSex.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id

                });
            }

            addAgentModel.AvailableFunction.Add(new SelectListItem()
            {
                Text = "Select Function",
                Value = ""
            });

            var function = new GroupLogic().Get(s => s.Owner.Equals(member.Agency));
            foreach (var item in function)
            {
                addAgentModel.AvailableFunction.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id

                });
            }

            return View(addAgentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignToNetwork(RegisterAndAssignUserToNetWork userViewModel)
        {
            if (ModelState.IsValid)
            {
                var member = new MemberLogic().Find(s => s.Id.Equals(User.Identity.GetUserId()));
                var notification = (new PermissionAndAuthorization()).Add(userViewModel);
                if (!notification.Success || string.IsNullOrEmpty(notification.Id))
                {
                    //AddErrors(notification);
                }
                else
                {
                    var applicationUser = new ApplicationUser
                    {
                        UserName = userViewModel.Email.ToLower(),
                        Email = userViewModel.Email.ToLower(),
                        PersonId = notification.Id,
                        PhoneNumber = userViewModel.Phone
                    };

                    var identityResult = UserManager.Create(applicationUser, userViewModel.Password);
                    if (identityResult.Succeeded)
                    {
                        if (userViewModel.Function != null)
                        {
                            var profileuserfunction = GroupManager.SetUserGroups(applicationUser.Id,userViewModel.Function);
                            if (profileuserfunction.Succeeded)
                            {
                                var getPersonId = UserManager.FindByEmail(userViewModel.Email);
                                var addUseToThierNetwork = new AssignUsersToTheirAgentNetwork
                                {
                                    UserId = getPersonId.Id,
                                    NetworkId = member.AgencyId
                                };
                                var results = new MemberLogic().AssignMemberToNetwork(addUseToThierNetwork);
                                if (results.Success)
                                {
                                    var userPositionHeldInOrganogramm = new UserPositionHeldInOrganogramm
                                    {
                                        UserId = addUseToThierNetwork.UserId,
                                        OrggrammId = member.AgencyId
                                    };

                                    var resultss = new MemberLogic().AddWorkArea(userPositionHeldInOrganogramm);
                                    if (resultss.Success)
                                    {
                                        return RedirectToAction("Index");
                                    }



                                }
                            }
                        }

                    }
                }

                // this.AddErrors(identityResult);
            }
            return View();
        }
    }
}