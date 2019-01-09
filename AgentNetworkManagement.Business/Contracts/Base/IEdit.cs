using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;

namespace AgentNetworkManagement.Business.Contracts.Base
{
    internal interface IEdit<T> where T : class
    {
        Notification Add(T entity);
    }
}
