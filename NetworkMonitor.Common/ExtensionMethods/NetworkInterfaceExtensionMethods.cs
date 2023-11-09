using System.Linq;
using System.Net.NetworkInformation;
using NetworkMonitor.Common.Constants;
using NetworkMonitor.Common.Exceptions;
using NetworkMonitor.Common.Settings;

namespace NetworkMonitor.Common.ExtensionMethods
{
    /// <summary> Методы расширения для класса NetworkInterface. </summary>
    public static class NetworkInterfaceExtensionMethods
    {
        /// <summary> Получение сетевого интерфейса по имени. </summary>
        /// <param name="networkInterfaces"></param>
        /// <param name="networkInterfaceSetting"> Настройки для получения сетевого интерфейса. </param>
        /// <returns> Сетевой интерфейс. </returns>
        public static NetworkInterface GetNetworkInterfaceByName(
            this NetworkInterface[] networkInterfaces, 
            NetworkInterfaceSetting networkInterfaceSetting)
        {
            var result =
                networkInterfaces
                    .FirstOrDefault(i => i.Name == networkInterfaceSetting.Name || string.IsNullOrEmpty(networkInterfaceSetting.Name));

            if (result == null)
            {
                throw new NetworkInterfaceException(ErrorMessages.NetworkInterfaceExceptionNotFound);
            }

            return result;
        }
    }
}
