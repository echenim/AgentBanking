using AgentNetworkManagement.Business.Contracts.Base;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.Models;

namespace AgentNetworkManagement.Business.Contracts
{
    interface IOrganogram: IGetEn<Organogramm>, IGetEn<National>, IAdd<National>, IGetEn<Region>, IAdd<Region>, IGetEn<State>, 
        IAdd<State>, IGetEn<Area>, IAdd<Area>, IGetEn<Zone>,IAdd<Zone>, IGetEn<Cluster>,IAdd<Cluster>
    {
    }
}
