using NetworkMonitor.Common.Dto;
using System.Collections.Generic;

namespace NetworkMonitor.Common.Interfaces
{
    /// <summary> Получение информации об узле сети. </summary>
    public interface IHostInformationService
    {
        /// <summary> Получение информации об узле сети. </summary>
        HostInformation GetHostInformation();

        /// <summary> Получение IP адреса DHCP Сервера. </summary>
        string GetDhcp();

        /// <summary> Получение IP адреса шлюза по-умолчанию. </summary>
        string GetGateway();

        /// <summary> Получение имени машины. </summary>
        string GetHostName();

        /// <summary> Получение IP адреа машины. </summary>
        string GetPv4Address();

        /// <summary> Получение списка IP адресов DNS. </summary>
        IEnumerable<string> GetDnsList();

        /// <summary> Получение таблицы маршрутизации. </summary>
        IEnumerable<string> GetTracertTable();

        /// <summary> Получение ARP таблицы. </summary>
        IEnumerable<Host> GetArpTable();
    }
}