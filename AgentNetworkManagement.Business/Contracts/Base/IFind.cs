using System;

namespace AgentNetworkManagement.Business.Contracts.Base
{
    internal interface IFind<T> where T : class
    {
        T Find(Func<T, bool> predicate);
    }
}
