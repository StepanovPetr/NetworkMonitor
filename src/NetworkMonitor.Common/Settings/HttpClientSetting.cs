namespace NetworkMonitor.Common.Settings;

/// <summary> Настройки для HttpClient. </summary>
public class HttpClientSetting
{
    /// <summary> IP адрес. </summary>
    public string IpAddress { get; set; }

    /// <summary> Задержка в микросекундах (должно быть больше 5000). </summary>
    public int Delay { get; set; }
}