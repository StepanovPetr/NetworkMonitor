using System.Net;
using System.Net.NetworkInformation;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;

namespace NetworkMonitor.Implementation.HostInformationService;

/// <summary> Получение информации об узле сети Windows. </summary>
public class WindowsHostInformationService : IHostInformationService
{
    private readonly IPInterfaceProperties _ipInterfaceProperties;

    public WindowsHostInformationService(IPInterfaceProperties ipInterfaceProperties)
    {
        _ipInterfaceProperties = ipInterfaceProperties;
    }


    /// NetworkInterface.GetAllNetworkInterfaces()[2].GetIPProperties();

    /// <inheritdoc />
    public HostInformation GetHostInformation()
    {
        return new HostInformation
        {
            Dhcp = GetDhcp(),
            DnsList = GetDnsList(),
            Gateway = GetGateway(),
            HostName = GetHostName(),
            IPv4Address = GetPv4Address(),
        };
    }

    /// <summary> Получение ARP таблицы. </summary>
    public IList<Host> GetArpTable()
    {
        throw new NotImplementedException();
    }

    /// <summary> Получение IP адреса DHCP Сервера. </summary>
    public string? GetDhcp()
    {
        return _ipInterfaceProperties.DhcpServerAddresses.FirstOrDefault()?.ToString();
    }

    /// <summary> Получение списка IP адресов DNS. </summary>
    public IList<string> GetDnsList()
    {
        return _ipInterfaceProperties.DnsAddresses.Select(i => i.MapToIPv4().ToString()).ToList();
    }

    /// <summary> Получение IP адреса шлюза по-умолчанию. </summary>
    public string? GetGateway()
    {
        return _ipInterfaceProperties.GatewayAddresses.FirstOrDefault()?.Address.MapToIPv4().ToString();
    }

    /// <summary> Получение имени машины. </summary>
    public string GetHostName()
    {
        return Environment.MachineName;
    }

    /// <summary> IP адрес машины. </summary>
    public string? GetPv4Address()
    {

        //return _ipInterfaceProperties.UnicastAddresses.Where(a => a.IPv4Mask == );

        return Dns.GetHostEntry(Dns.GetHostName()).AddressList.LastOrDefault()?.ToString();
    }
}