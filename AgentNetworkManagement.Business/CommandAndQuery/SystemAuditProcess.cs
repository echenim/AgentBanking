using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
    public class SystemAuditProcess
    {
        readonly ISystemAudit _systemAudit;

        public SystemAuditProcess()
        {
            _systemAudit = new SystemAuditRepository(new ApplicationDbContext());
        }


        public void EntityError(string actor, string whatwastheactodoing, string ranking, string sb)
            => _systemAudit.Add(actor,whatwastheactodoing, ranking, sb);

    }
}
