using System;
using System.Collections.Generic;

namespace AgentNetworkManagement.Business.Contracts.Base
{
    internal interface IGetEn<T> where T : class
    {
       IEnumerable<T> Get(Func<T, bool> predicate = null);
    }
}
