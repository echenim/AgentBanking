using System.Collections.Generic;
using System.Web.Mvc;

namespace AgentNetworkManager.Domain.ViewModels
{
    public class ZoneView
    {
        public ZoneView()
        {
            AvailablePlatform = new List<SelectListItem>();
            AvailableRegion = new List<SelectListItem>();
            AvailableState = new List<SelectListItem>();
            AvailableArea = new List<SelectListItem>();
            AvailableZone = new List<SelectListItem>();
        }

        public string Id { get; set; }

        public string platform { get; set; }
        public List<SelectListItem> AvailablePlatform { get; set; }
        public string region { get; set; }
        public List<SelectListItem> AvailableRegion { get; set; }

        public string state { get; set; }
        public List<SelectListItem> AvailableState { get; set; }
        public string area { get; set; }
        public List<SelectListItem> AvailableArea { get; set; }

        public string Zone { get; set; }

        public List<SelectListItem> AvailableZone { get; set; }

        public string UserName { get; set; }
    }
}
