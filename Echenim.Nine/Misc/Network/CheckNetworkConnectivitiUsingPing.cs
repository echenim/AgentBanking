using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using Echenim.Nine.Misc.Network.Contracts;

namespace Echenim.Nine.Misc.Network
{
    public class CheckNetworkConnectivitiUsingPing:ICheckForConnection
    {
        private readonly string _hostname;
        private readonly int _portnumber;
        private static int timeOut = 1000;
        

        public CheckNetworkConnectivitiUsingPing()
        {
            
        }

        public CheckNetworkConnectivitiUsingPing(string hostname)
        {
            _hostname = hostname;
        }

        public CheckNetworkConnectivitiUsingPing(string hostname,int portnumber)
        {
            _hostname = hostname;
            _portnumber = portnumber;
        }
        public PingReply CheckIfPointIsConnected() => new Ping().Send(_hostname,timeOut);

        public Notification PingHostTcpClient()
        {
          var notification = new Notification();

            try
            {
                notification.Success = true;
                notification.Message = "";
            }
            catch (Exception ex)
            {
                notification.Success = true;
                notification.Message = ex.Message;
            }


            return notification;
        }

        public Result PingHost()
        {
            return new TcpClient(_hostname,8080).Connected==true ? Result.Ok() :Result.Fail("fail to connect") ;
        }

    }
}
