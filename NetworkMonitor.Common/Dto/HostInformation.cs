using System;
using System.Collections.Generic;

namespace NetworkMonitor.Common.Dto
{
    /// <summary> Информация об узле сети. </summary>
    [Serializable]
    public class HostInformation
    {
        /// <summary> IP адрес DHCP Сервера. </summary>
        public string Dhcp { get; set; }

        /// <summary> IP адрес шлюза по-умолчанию. </summary>
        public string Gateway { get; set; }

        /// <summary> Имя машины. </summary>
        public string HostName { get; set; }

        /// <summary> IP адрес машины. </summary>
        public string IPv4Address { get; set; }

        /// <summary> IP адресы DNS серверов. </summary>
        public IList<string> DnsList { get; set; }

        /// <summary> ARP таблица. </summary>
        public IEnumerable<Host> ArpTable { get; set; }

        /// <summary> Таблица маршрутизации. </summary>
        public IEnumerable<string> TracertTable { get; set; }
    }
}