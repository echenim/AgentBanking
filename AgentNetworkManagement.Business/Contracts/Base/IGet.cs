using System;
using System.Linq;

namespace AgentNetworkManagement.Business.Contracts.Base
{
    internal interface IGet<T> where T : class 
    {
        IQueryable<T> Get(Func<T, bool> predicate = null);
    }
}
