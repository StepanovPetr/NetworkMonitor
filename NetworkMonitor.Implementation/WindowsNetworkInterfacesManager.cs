using System.Net.NetworkInformation;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;

namespace NetworkMonitor.Implementation;

public class WindowsNetworkInterfacesManager : INetworkInterfacesManager
{
    public NetworkInterface GetNetworkInterface(
        NetworkInterface[] networkInterfaces, 
        NetworkInterfaceSetting networkInterfaceSetting)
    {
        var result =
            networkInterfaces
                .FirstOrDefault(i => i.Name == networkInterfaceSetting.Name || string.IsNullOrEmpty(networkInterfaceSetting.Name));

        return result;
    }
}