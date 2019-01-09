using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;

namespace AgentNetworkManagement.Business.Contracts.Base
{
    internal interface IDelete<T> where T : class
    {
        Notification Add(T entity);
    }
}
