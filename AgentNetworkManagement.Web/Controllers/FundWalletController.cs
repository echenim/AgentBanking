using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using AgentNetworkManagement.Business.CommandAndQuery;
using AgentNetworkManager.Domain.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;

namespace AgentNetworkManagement.Web.Controllers
{
    [Authorize(Roles = "Administrator,Platform Manager,Region Manager,State Manager,Area Manager,Zonal Manager,Field Agents")]
    public class FundWalletController : Controller
    {
       

         public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var person = new PlatformUserCq().GetUserInfo(s => s.Id.Equals(User.Identity.GetUserId()));
            

          
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewBag.DateSortParm = sortOrder == "name" ? "name_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var usersOfTheAnm = person.Position == "Administrator" ? new FundWalletLogic().Get() :
              (person.Position == "Platform Manager" ? new FundWalletLogic().Get(s => s.Agency.Equals(person.Agency)) :
              (person.Position == "Regional Manager" ? new FundWalletLogic().Get(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName)) :
              (person.Position == "State Manager" ? new FundWalletLogic().Get(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName)) :
               (person.Position == "Area Manager" ? new FundWalletLogic().Get(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName) && s.Area.Equals(person.Area)) :
                (person.Position == "Zonal Manager" ? new FundWalletLogic().Get(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName) && s.Area.Equals(person.Area) && s.Zone.Equals(person.Zone)) :
                  new FundWalletLogic().Get(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName) && s.Area.Equals(person.Area) && s.Zone.Equals(person.Zone) && s.Clusta.Equals(person.Clusta)))))));

            if (!string.IsNullOrEmpty(searchString))
            {
                usersOfTheAnm = usersOfTheAnm.Where(s => s.Name.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
               
                case "name_desc":
                    usersOfTheAnm = usersOfTheAnm.OrderByDescending(s => s.Name);
                    break;
                default:  // Name ascending 
                    usersOfTheAnm = usersOfTheAnm.OrderByDescending(s => s.Name);
                    break;
            }




            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(usersOfTheAnm.ToPagedList(pageNumber, pageSize));
        }

 

        public ActionResult Create()
        {
            var person = new PlatformUserCq().GetUserInfo(s => s.Id.Equals(User.Identity.GetUserId()));
            var members = new FundWalletLogic().GetAgent();
            var getAgents = person.Position == "Platform Manager" ? members.Where(s => s.Agency.Equals(person.Agency)) :
                (person.Position == "Regional Manager" ? members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName)) :
                ((person.Position == "State Manager" ? members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName)) :
                ((person.Position == "Area Manager" ? members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName) && s.Area.Equals(person.Area)) :
                 ((person.Position == "Zonal Manager" ? members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName) && s.Area.Equals(person.Area) && s.Zone.Equals(person.Zone)) :
                   members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName) && s.Area.Equals(person.Area) && s.Zone.Equals(person.Zone) && s.Clusta.Equals(person.Clusta))
                 )))))));

            ViewBag.Agent = new SelectList(getAgents, "Pid", "FullDetail");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Agent,Fund")] FundWallets wallet)
        {
            ParameterExpression parameterExpression;
            if (ModelState.IsValid)
            {
                (new FundWalletLogic()).Add(wallet, User.Identity.Name);
                return base.RedirectToAction("Index");
            }
            var person = new PlatformUserCq().GetUserInfo(s => s.Id.Equals(User.Identity.GetUserId()));
            var members = new MemberLogic().Get();
            var getAgents = person.Position == "Platform Manager" ? members.Where(s => s.Agency.Equals(person.Agency)) :
                (person.Position == "Regional Manager" ? members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName)) :
                ((person.Position == "State Manager" ? members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName)) :
                ((person.Position == "Area Manager" ? members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName) && s.Area.Equals(person.Area)) :
                 ((person.Position == "Zonal Manager" ? members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName) && s.Area.Equals(person.Area) && s.Zone.Equals(person.Zone)) :
                   members.Where(s => s.Agency.Equals(person.Agency) && s.RegionName.Equals(person.RegionName) && s.StateName.Equals(person.StateName) && s.Area.Equals(person.Area) && s.Zone.Equals(person.Zone) && s.Clusta.Equals(person.Clusta))
                 )))))));

            ViewBag.Agent = new SelectList(getAgents, "Pid", "FullDetail");

            return View(wallet);
        }

     


    }
}