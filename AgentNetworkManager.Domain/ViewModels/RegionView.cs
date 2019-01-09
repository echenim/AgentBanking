using System.Collections.Generic;
using System.Web.Mvc;

namespace AgentNetworkManager.Domain.ViewModels
{
   public class RegionView
    {
       public RegionView()
       {
            AvailablePlatform = new List<SelectListItem>();
            AvailableRegion = new List<SelectListItem>();
        }

        public string Id { get; set; }
        public string platform{ get; set; }
        public List<SelectListItem> AvailablePlatform { get; set; }

        public string region { get; set; }
        public List<SelectListItem> AvailableRegion { get; set; }
        public string UserName { get; set; }
    }
}
