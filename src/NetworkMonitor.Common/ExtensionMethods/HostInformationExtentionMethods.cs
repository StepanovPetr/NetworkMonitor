using System;
using NetworkMonitor.Common.Dto;

namespace NetworkMonitor.Common.ExtensionMethods;

public static class HostInformationExtensionMethods
{
    public static string Log(this HostInformation hostInformation)
    {
        var result = $"Gateway - {hostInformation.Gateway}{Environment.NewLine}";
        result += $"HostName - {hostInformation.HostName}{Environment.NewLine}";
        result += $"IPv4Address - {hostInformation.IPv4Address}{Environment.NewLine}";
        result += $"DHCP - {hostInformation.Dhcp}{Environment.NewLine}";
        result += $"DNS сервера:{Environment.NewLine}";

        foreach (var address in hostInformation.DnsList)
        {
            result += $"{address}{Environment.NewLine}";
        }

        result += $"Таблица трассировки: {Environment.NewLine}";
        foreach (var address in hostInformation.TracertTable)
        {
             result += $"{address}{Environment.NewLine}";
        }

        result += $"Таблица ARP: {Environment.NewLine}";
        foreach (var address in hostInformation.ArpTable)
        {
            result += $"{address.IpAddress} - {address.MacAddress}{Environment.NewLine}";
        }

        return result;
    }
}