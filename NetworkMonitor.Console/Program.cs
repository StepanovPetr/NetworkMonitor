//See https://aka.ms/new-console-template for more information

using NetworkMonitor.Implementation.HostInformationService;
using System.Net.NetworkInformation;

var result =  NetworkInterface.GetAllNetworkInterfaces();

var host = new WindowsHostInformationService(NetworkInterface.GetAllNetworkInterfaces()[2].GetIPProperties());

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
