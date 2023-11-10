using NetworkMonitor.Common.Dto;

namespace NetworkMonitor.Common.Interfaces;

/// <summary> Отправка данных на сервер по протоколу HTTP. </summary>
public interface IHttpClient
{
    /// <summary> Отправка данных сети текущего узла на сервер. </summary>
    /// <param name="hostInformation"> Информация об узле сети. </param>
    void SendHostInformation(HostInformation hostInformation);
}

