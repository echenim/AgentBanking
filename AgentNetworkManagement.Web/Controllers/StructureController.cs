using System;
using System.Web.Mvc;
using AgentNetworkManagement.Business.CommandAndQuery;
using AgentNetworkManager.Domain.Models;
using AgentNetworkManager.Domain.ViewModels;
using Microsoft.AspNet.Identity;

namespace AgentNetworkManagement.Web.Controllers
{
    public class StructureController : Controller
    {
       
        public ActionResult Index()
        {
            var member = new MemberLogic().Find(s => s.Id.Equals(User.Identity.GetUserId()));

            var networkStruction = member.Position == "Administrator"
                ? new OrganogramLogic().GetStructure()
                : (member.Position == "Platform Manager" ? new OrganogramLogic().GetStructure(s => s.Agency.Equals(member.Agency)) :
                    (member.Position == "Regional Manager" ? new OrganogramLogic().GetStructure(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName)):
                    (member.Position == "State Manager" ? new OrganogramLogic().GetStructure(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName)) :
                     (member.Position == "Area Manager" ? new OrganogramLogic().GetStructure(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area)):
                      (member.Position == "Zonal Manager" ? new OrganogramLogic().GetStructure(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area) && s.Zone.Equals(member.Zone)) :
                       new OrganogramLogic().GetStructure(s => s.Agency.Equals(member.Agency) && s.RegionName.Equals(member.RegionName) && s.StateName.Equals(member.StateName) && s.Area.Equals(member.Area) && s.Zone.Equals(member.Zone) && s.Clusta.Equals(member.Clusta) && member.Position.Equals("Field Agents")))))));

            
            return View(networkStruction);
        }


        public ActionResult Platform()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Platform([Bind(Include = "Name")] National national)
        {
            if (ModelState.IsValid)
            {
                var dataObj = new OrganogramLogic().Add(national);
                if (dataObj.Success)
                {
                    return RedirectToAction("Index");
                }
                
            }
           
            return RedirectToAction("Index");
        }


        public ActionResult Region()
        {
            var member = new MemberLogic().Find(s=> s.Id == User.Identity.GetUserId());
            var platform = new OrganogramLogic().GetPlatform(s => s.Name.Equals(member.Agency));
           
            ViewBag.NationalId = new SelectList(platform, "Id", "Name");
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Region([Bind(Include = "NationalId,Name")] Region region)
        {
            if (ModelState.IsValid)
            {
                var dataObj = new OrganogramLogic().Add(region);
                if (dataObj.Success)
                {
                    return RedirectToAction("Index");
                }
                
            }
           
            return RedirectToAction("Index");
        }

        public ActionResult State()
        {
            var member = new MemberLogic().Find(s => s.Id == User.Identity.GetUserId());

            var modelObj = new StateView();
            
            var platform = new OrganogramLogic().GetPlatform(s => s.Name.Equals(member.Agency));
            foreach (var item in platform)
            {
                modelObj.AvailablePlatform.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            modelObj.AvailableRegion.Add(new SelectListItem()
            {
                Text = "Please Select",
                Value = String.Empty
            });
            var region = new OrganogramLogic().GetRegion(s => s.National.Name.Equals(member.Agency));
            foreach (var item in region)
            {
                modelObj.AvailableRegion.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            
           
            return base.View(modelObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult State([Bind(Include = "RegionId,Name")] State state)
        {
            if (ModelState.IsValid)
            {
                var dataObj = new OrganogramLogic().Add(state);
                if (dataObj.Success)
                {
                    return RedirectToAction("Index");
                }

            }

            return RedirectToAction("Index");
        }





    }
}