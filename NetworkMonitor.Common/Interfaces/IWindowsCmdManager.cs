using NetworkMonitor.Common.Dto;
using System.Collections.Generic;

namespace NetworkMonitor.Common.Interfaces;

/// <summary> Работа с утилитами командной строки Windows. </summary>
public interface IWindowsCmdManager
{
    /// <summary> Получение arp таблицы через cmd. </summary>
    /// <returns> arp таблица. </returns>
    IEnumerable<Host> GetArpTable();

    /// <summary> Получение таблицы маршрутизации через cmd. </summary>
    /// <param name="gateway"> IP адрес шлюза по-умолчанию. </param>
    /// <returns> таблицы прассеровки. </returns>
    IEnumerable<string> GetTracertTable(string gateway);
}