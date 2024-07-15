using System.Net.Http.Json;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;

namespace NetworkMonitor.Implementation.Windows;

/// <summary> Класс заглушка для IHttpClient. </summary>
public class WindowsHttpClient : IHttpClient
{

    /// <summary> Сохранение информации об узле сети в json файл. </summary>
    public void SendHostInformation(HostInformation hostInformation)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:5115/");
            var response = client.PostAsJsonAsync("Validation", hostInformation).Result;
        }
    }
}