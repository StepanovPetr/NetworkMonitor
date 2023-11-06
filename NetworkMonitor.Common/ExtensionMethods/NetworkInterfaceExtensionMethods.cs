using NetworkMonitor.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitor.Common.ExtensionMethods
{
    static class NetworkInterfaceExtensionMethods
    {
        IEnumerable<NetworkInterface> GetNetworkInterface(this IEnumerable<NetworkInterface> NetworkInterfaceSetting, NetworkInterfaceSetting networkInterfaceSetting)
        { 
           return NetworkInterfaceSetting.Where(i => i.Name == )
        }
    }
}
