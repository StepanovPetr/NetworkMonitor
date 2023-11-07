//See https://aka.ms/new-console-template for more information
using NetworkMonitor.Implementation.HostInformationService;
using System.Net.NetworkInformation;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;
using NetworkMonitor.Implementation;

var networkInterfaceSetting = new NetworkInterfaceSetting
{
    Name = "Ethernet"
};

var result = NetworkInterface.GetAllNetworkInterfaces();

//var networkInterface = NetworkInterface.GetAllNetworkInterfaces().GetNetworkInterfaceByName(networkInterfaceSetting);

INetworkInterfacesManager networkInterfacesManager = new WindowsNetworkInterfacesManager();
var networkInterface = networkInterfacesManager.GetNetworkInterface(NetworkInterface.GetAllNetworkInterfaces() ,networkInterfaceSetting);

var windowsCmdManager = new WindowsCmdManager();
var host = new WindowsHostInformationService(networkInterface.GetIPProperties(), windowsCmdManager);
var hostInformation = host.GetHostInformation();

Console.WriteLine(hostInformation.Gateway);
Console.WriteLine(hostInformation.HostName);
Console.WriteLine(hostInformation.IPv4Address);
Console.WriteLine(hostInformation.Dhcp);

foreach (var address in hostInformation.DnsList)
{
    Console.WriteLine(address);
}

foreach (var address in hostInformation.TracertTable)
{
    Console.WriteLine(address);
}

foreach (var address in hostInformation.ArpTable)
{
    Console.WriteLine( $"{address.IpAddress} - {address.MacAddress}");
}


Console.ReadLine();