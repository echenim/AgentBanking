using System.Net.NetworkInformation;

namespace Echenim.Nine.Misc.Network.Contracts.Base
{
    interface IPing
    {
        PingReply CheckIfPointIsConnected();
        //PingReply CheckIfPointIsConnected(string hostname, string timeout);

    }
}
