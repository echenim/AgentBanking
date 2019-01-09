using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgentNetworkManagement.Web.Startup))]
namespace AgentNetworkManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
