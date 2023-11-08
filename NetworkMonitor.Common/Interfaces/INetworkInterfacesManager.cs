using NetworkMonitor.Common.Settings;
using System.Net.NetworkInformation;

namespace NetworkMonitor.Common.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public  interface INetworkInterfacesManager
    {
        public NetworkInterface GetNetworkInterface(
            NetworkInterface[] networkInterfaces,
            NetworkInterfaceSetting networkInterfaceSetting);
    }
}
