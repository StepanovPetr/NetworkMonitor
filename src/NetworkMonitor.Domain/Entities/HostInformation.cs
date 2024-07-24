namespace NetworkMonitor.Domain.Entities;

public class HostInformation
{
    /// <summary> Id. </summary>
    public int Id { get; set; }

    public string Mac { get; set; }

    /// <summary> Имя машины. </summary>
    public string HostName { get; set; }

    /// <summary> IP адрес DHCP Сервера. </summary>
    public string Dhcp { get; set; }

    /// <summary> IP адрес шлюза по-умолчанию. </summary>
    public string Gateway { get; set; }

    /// <summary> IP адрес машины. </summary>
    public string IPv4Address { get; set; }

    /// <summary> IP адреса DNS серверов. </summary>
    public string Dns { get; set; }
}