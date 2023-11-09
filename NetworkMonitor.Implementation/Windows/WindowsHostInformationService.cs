using System.Net.NetworkInformation;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;

namespace NetworkMonitor.Implementation.Windows;

/// <summary> Получение информации об узле сети Windows. </summary>
public class WindowsHostInformationService : IHostInformationService
{
    private readonly IPInterfaceProperties _ipInterfaceProperties;
    private readonly IWindowsCmdManager _cmdManager;

    public WindowsHostInformationService(IPInterfaceProperties ipInterfaceProperties, IWindowsCmdManager cmdManager)
    {
        _ipInterfaceProperties = ipInterfaceProperties;
        _cmdManager = cmdManager;
    }

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

    public string GetDhcp()
    {
        return _ipInterfaceProperties.DhcpServerAddresses.FirstOrDefault()?.ToString();
    }

    public string GetGateway()
    {
        return _ipInterfaceProperties.GatewayAddresses.FirstOrDefault()?.Address.MapToIPv4().ToString();
    }

    public string GetHostName()
    {
        return Environment.MachineName;
    }

    public string GetPv4Address()
    {
        return _ipInterfaceProperties
            .UnicastAddresses
            .FirstOrDefault(a => a.IPv4Mask.Address != 0)
            .Address.MapToIPv4().ToString();
    }

    public IEnumerable<string> GetDnsList()
    {
        return _ipInterfaceProperties.DnsAddresses.Select(i => i.MapToIPv4().ToString()).ToList();
    }

    public IEnumerable<string> GetTracertTable()
    {
        return _cmdManager.GetTracertTable(GetGateway());
    }

    public IEnumerable<Host> GetArpTable()
    { 
        return _cmdManager.GetArpTable();
    }
}