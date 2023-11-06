using NetworkMonitor.Common.Dto;
using System.Net.NetworkInformation;

namespace NetworkMonitor.Common.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public  interface INetworkInterfacesManager
    {
        public NetworkInterface GetNetworkInterface(NetworkInterfaceSetting);
    }
}
