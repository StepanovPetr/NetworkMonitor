namespace NetworkMonitor.Common.Dto
{
    /// <summary> Информация об узле сети. </summary>
    public class Host
    {
        /// <summary> Ip адрес. </summary>
        public string IpAddress { get; }

        /// <summary> MAC адрес. </summary>
        public string MacAddress { get; }
    }
}