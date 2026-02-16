using System;
using NetworkMonitor.Common.Dto;

namespace NetworkMonitor.Common.ExtensionMethods;

public static class HostInformationExtensionMethods
{
    public static string Log(this HostInformationDto hostInformationDto)
    {
        var result = $"Gateway - {hostInformationDto.Gateway}{Environment.NewLine}";
        result += $"HostName - {hostInformationDto.HostName}{Environment.NewLine}";
        result += $"IPv4Address - {hostInformationDto.IPv4Address}{Environment.NewLine}";
        result += $"DHCP - {hostInformationDto.Dhcp}{Environment.NewLine}";
        result += $"DNS сервера:{Environment.NewLine}";

        foreach (var address in hostInformationDto.DnsList)
        {
            result += $"{address}{Environment.NewLine}";
        }

        result += $"Таблица трассировки: {Environment.NewLine}";
        foreach (var address in hostInformationDto.TracertTable)
        {
             result += $"{address}{Environment.NewLine}";
        }

        result += $"Таблица ARP: {Environment.NewLine}";
        foreach (var address in hostInformationDto.ArpTable)
        {
            result += $"{address.IpAddress} - {address.MacAddress}{Environment.NewLine}";
        }

        return result;
    }
}