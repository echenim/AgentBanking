using System.Collections.Generic;
using System.Web.Mvc;

namespace AgentNetworkManager.Domain.ViewModels
{
    public class PlatformView
    {
        public PlatformView()
        {
            AvailablePlatform = new List<SelectListItem>();
        }

        public string Id { get; set; }
        public string platform { get; set; }
        public List<SelectListItem> AvailablePlatform { get; set; }

        public string UserName { get; set; }
    }
}
