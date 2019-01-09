using System.ComponentModel.DataAnnotations;

namespace AgentNetworkManager.Domain.DbViews
{
    public class Organogramm
    {
        [Key]
        public string Id { get; set; }
        public string Agency { get; set; }
        public string RegionName { get; set; }
        public string StateName { get; set; }
        public string Area { get; set; }
        public string Zone { get; set; }
        public string Clusta { get; set; }
        public string Kind { get; set; }

    }
}
