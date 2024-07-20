using System.Net.Http.Json;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;
using NetworkMonitor.Common.Settings;

namespace NetworkMonitor.Implementation.Windows;

/// <summary> Класс заглушка для IHttpClient. </summary>
public class WindowsHttpClient : IHttpClient
{
    private HttpClientSetting _httpClientSetting;

    public WindowsHttpClient(HttpClientSetting httpClientSetting)
    {
        _httpClientSetting = httpClientSetting;
    }

    /// <summary> Сохранение информации об узле сети в json файл. </summary>
    public void SendHostInformation(HostInformation hostInformation)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_httpClientSetting.IpAddress);
            var response = client.PostAsJsonAsync("Validation", hostInformation).Result;
        }
    }
}