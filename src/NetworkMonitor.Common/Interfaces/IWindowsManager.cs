using NetworkMonitor.Common.Dto;
using System.Collections.Generic;

namespace NetworkMonitor.Common.Interfaces;

/// <summary> Работа с Windows. </summary>
public interface IWindowsManager
{
    /// <summary> Получение ARP таблицы. </summary>
    /// <returns> ARP таблица. </returns>
    IEnumerable<Host> GetArpTable();

    /// <summary> Получение таблицы маршрутизации. </summary>
    /// <param name="gateway"> IP адрес шлюза по-умолчанию. </param>
    /// <returns> Таблица маршрутизации. </returns>
    IEnumerable<string> GetTracertTable(string gateway);
}

