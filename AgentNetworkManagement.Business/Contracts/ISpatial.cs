using AgentNetworkManager.Domain.Models;

namespace AgentNetworkManagement.Business.Contracts
{
    internal interface ISpatial
    {
        bool Add(SpatialNonTransactionScheme entity);
        void Add(SpatialTransactionScheme entity);
    }
}
