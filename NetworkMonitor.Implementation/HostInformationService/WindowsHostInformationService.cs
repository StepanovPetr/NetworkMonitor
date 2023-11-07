using System.Net;
using System.Net.NetworkInformation;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;

namespace NetworkMonitor.Implementation.HostInformationService;

/// <summary> Получение информации об узле сети Windows. </summary>
public class WindowsHostInformationService : IHostInformationService
{
    private readonly IPInterfaceProperties _ipInterfaceProperties;
    private readonly WindowsCmdManager _cmdManager;

    public WindowsHostInformationService(IPInterfaceProperties ipInterfaceProperties, WindowsCmdManager cmdManager)
    {
        _ipInterfaceProperties = ipInterfaceProperties;
        _cmdManager = cmdManager;
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
            TracertTable = GetTracertTable(),
            ArpTable = GetArpTable()
        };
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

    public IEnumerable<string> GetTracertTable()
    {
        return _cmdManager.GetTracertTable(GetGateway());
    }

    /// <summary> Получение ARP таблицы. </summary>
    public IEnumerable<Host> GetArpTable()
    { 
        return _cmdManager.GetArpTable();
        //return new List<Host>();
    }
}