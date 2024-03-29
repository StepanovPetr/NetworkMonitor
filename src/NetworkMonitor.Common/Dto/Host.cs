﻿namespace NetworkMonitor.Common.Dto
{
    /// <summary> Информация об узле сети. </summary>
    public class Host
    {
        /// <summary> IP адрес. </summary>
        public string IpAddress { get; set; }

        /// <summary> MAC адрес. </summary>
        public string MacAddress { get; set; }
    }
}