using NetworkMonitor.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace NetworkMonitor.Common.ExtensionMethods
{
    static class NetworkInterfaceExtensionMethods
    {
        /// <summary>
        ///  Получение сетевого интерфейса по имени
        /// </summary>
        /// <param name="NetworkInterfaces"></param>
        /// <param name="networkInterfaceSetting"></param>
        /// <returns></returns>
        public static IEnumerable<NetworkInterface> GetNetworkInterfaceByName(
            this NetworkInterface[] NetworkInterfaces, 
            NetworkInterfaceSetting networkInterfaceSetting)
        {
            return NetworkInterfaces.Where(i => i.Name == networkInterfaceSetting.Name);
        }
    }
}
