using System;
using System.Linq;
using System.Web.Mvc;
using AgentNetworkManagement.Business.CommandAndQuery;
using AgentNetworkManager.Domain.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;

namespace AgentNetworkManagement.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Histories(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {

                var agentinfo =
                    new TransactionSystem().FindPersonDetail(id);

                var trnsaction = new TransactionSystem().GetTransactionHistories(s => s.AgentId.Equals(id))
                   .OrderByDescending(s=>s.CreatedOn);

                var history = new HistoryView
                {
                    Agent = agentinfo,
                    TransactionHistoryList = trnsaction.ToList()

                };


                return View(history);
            }

            return View();
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
                ? new TransactionSystem().GetTransactions()
                : (member.Position == "Platform Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency)) :
                    (member.Position == "Regional Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName)) :
                    (member.Position == "State Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName)) :
                     (member.Position == "Area Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area)) :
                      (member.Position == "Zonal Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area) && s.Zone.Equals(member.Zone)) :
                       new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area) && s.Zone.Equals(member.Zone) && s.Clusta.Equals(member.Clusta) && member.Position.Equals("Field Agents")))))));


            if (!String.IsNullOrEmpty(searchString))
            {
                networkStruction = networkStruction.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    networkStruction = networkStruction.OrderByDescending(s => s.CreatedOn);
                    break;
                case "Date":
                    networkStruction = networkStruction.OrderBy(s => s.Name);
                    break;
                case "date_desc":
                    networkStruction = networkStruction.OrderByDescending(s => s.Name);
                    break;
                default:  // Name ascending 
                    networkStruction = networkStruction.OrderBy(s => s.CreatedOn);
                    break;
            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(networkStruction.ToPagedList(pageNumber, pageSize));



           
        }

        public ActionResult SkIndex(string sortOrder, string currentFilter, string searchString, int? page)
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
                ? new TransactionSystem().GetTransactions()
                : (member.Position == "Platform Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency)) :
                    (member.Position == "Regional Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName)) :
                    (member.Position == "State Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName)) :
                     (member.Position == "Area Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area)) :
                      (member.Position == "Zonal Manager" ? new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area) && s.Zone.Equals(member.Zone)) :
                       new TransactionSystem().GetTransactions(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area) && s.Zone.Equals(member.Zone) && s.Clusta.Equals(member.Clusta) && member.Position.Equals("Field Agents")))))));


            if (!String.IsNullOrEmpty(searchString))
            {
                networkStruction = networkStruction.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    networkStruction = networkStruction.OrderByDescending(s => s.CreatedOn);
                    break;
                case "Date":
                    networkStruction = networkStruction.OrderBy(s => s.Name);
                    break;
                case "date_desc":
                    networkStruction = networkStruction.OrderByDescending(s => s.Name);
                    break;
                default:  // Name ascending 
                    networkStruction = networkStruction.OrderBy(s => s.CreatedOn);
                    break;
            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(networkStruction.ToPagedList(pageNumber, pageSize));




        }


    }
}