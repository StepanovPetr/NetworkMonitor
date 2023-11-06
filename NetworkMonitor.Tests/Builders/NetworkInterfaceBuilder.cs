using NetworkMonitor.Tests.Entities;
using System.Net.NetworkInformation;

namespace NetworkMonitor.Tests.Builders; 

public class NetworkInterfaceBuilder
{
    private NetworkInterfaceTest _networkInterface;
    
    /// <summary> Создание нового экземпляра NetworkInterfaceBuilder. </summary>
    /// <returns> Новый экземпляр NetworkInterfaceBuilder </returns>
    public static NetworkInterfaceBuilder CreateBuilder()
    {
        return new();
    }

    public NetworkInterfaceBuilder SetName(string name)
    {
        _networkInterface = new NetworkInterfaceTest(name);
        
        return this;
    }

    /// <summary> Получение экземпляра класса NetworkInterface. </summary>
    /// <returns> Экземпляр класса NetworkInterface. </returns>
    public NetworkInterface Build()
    {
        return _networkInterface;
    }

    public static NetworkInterface[] BuildArray(IEnumerable<string> names)
    {
        var networkInterfaces = new List<NetworkInterface>();

        foreach (var name in names)
        {
            var item = NetworkInterfaceBuilder
                .CreateBuilder()
                .SetName(name)
                .Build();
            networkInterfaces.Add(item);
        }

        return networkInterfaces.ToArray();
    }
}