using NetworkMonitor.Common.Dto;

namespace NetworkMonitor.Common.Interfaces;

/// <summary> Отправка данных на сервер по протоколу HTTP. </summary>
public interface IHttpClient
{
    /// <summary> Отправка данных сети текущего узла на сервер. </summary>
    /// <param name="hostInformationDto"> Информация об узле сети. </param>
    void SendHostInformation(HostInformationDto hostInformationDto);
}

