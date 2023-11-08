using NetworkMonitor.Common.Dto;
using System.Collections.Generic;

namespace NetworkMonitor.Common.Interfaces;

public interface IWindowsCmdManager
{
    /// <summary> Получение arp таблицы через cmd. </summary>
    /// <returns> arp таблица. </returns>
    IEnumerable<Host> GetArpTable();

    /// <summary> Получение таблицы прассеровки через cmd. </summary>
    /// <param name="gateway"></param>
    /// <returns> таблицы прассеровки. </returns>
    IEnumerable<string> GetTracertTable(string gateway);
}