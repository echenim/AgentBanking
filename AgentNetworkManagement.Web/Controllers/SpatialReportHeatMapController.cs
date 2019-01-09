using System.Web.Mvc;

namespace AgentNetworkManagement.Web.Controllers
{
    public class SpatialReportHeatMapController : Controller
    {
        // GET: SpatialReports
        public ActionResult AgentsDistribution()
        {
            return View();
        }

        public ActionResult TransactionsDistribution()
        {
            return View();
        }

        public ActionResult ActivityCluster()
        {
            return View();
        }
    }
}