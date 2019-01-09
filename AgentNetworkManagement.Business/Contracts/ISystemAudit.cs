namespace AgentNetworkManagement.Business.Contracts
{
    interface ISystemAudit
    {
        void Add(string actor, string whatwastheactodoing, string ranking, string sb);
    }
}
