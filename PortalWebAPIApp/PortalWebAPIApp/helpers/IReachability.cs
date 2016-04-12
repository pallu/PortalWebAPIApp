using System;

namespace PortalWebAPIApp.helpers
{
    public interface IReachability
    {
        bool IsConnectedToNetwork();
        bool IsConnectedToWifi();
        bool IsRoaming();
        
    }
}
