namespace NetworkMonitor.Common.Settings;

public class HttpClientSetting
{
    /// <summary> Ip адрес. </summary>
    public string IpAddress { get; set; }

    /// <summary> задержка в микросекундах (должно быть больше 5000) </summary>
    public int Delay { get; set; }
}