//See https://aka.ms/new-console-template for more information

using NetworkMonitor.Implementation.HostInformationService;
using System.Net.NetworkInformation;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.ExtensionMethods;
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

var host = new WindowsHostInformationService(networkInterface.GetIPProperties());
var hostInformation = host.GetHostInformation();

Console.WriteLine(hostInformation.Gateway);
Console.WriteLine(hostInformation.HostName);
Console.WriteLine(hostInformation.IPv4Address);
Console.WriteLine(hostInformation.Dhcp);

foreach (var address in hostInformation.DnsList)
{
    Console.WriteLine(address);
}

Console.ReadLine();