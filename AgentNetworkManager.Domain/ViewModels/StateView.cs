﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace AgentNetworkManager.Domain.ViewModels
{
   public  class StateView
    {
       public StateView()
       {
            AvailablePlatform = new List<SelectListItem>();
           AvailableRegion = new List<SelectListItem>();
            AvailableState = new List<SelectListItem>();
       }

        public string Id { get; set; }

        public string platform { get; set; }
        public List<SelectListItem> AvailablePlatform { get; set; }

        public string Regional { get; set; }
        public List<SelectListItem> AvailableRegion{get;set;}

        public string State { get; set; }
        public List<SelectListItem> AvailableState { get; set; }
        public string UserName { get; set; }

    }
}
