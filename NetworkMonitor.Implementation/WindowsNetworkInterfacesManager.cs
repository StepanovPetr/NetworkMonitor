using System.Net.NetworkInformation;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Exceptions;
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

        if (result == null)
        {
            throw new NetworkInterfaceException("Сетевой интерфейс не найден.");
        }

        return result;
    }
}