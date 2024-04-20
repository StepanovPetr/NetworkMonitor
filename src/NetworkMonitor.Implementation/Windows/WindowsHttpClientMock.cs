using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;
using Newtonsoft.Json;

namespace NetworkMonitor.Implementation.Windows;

/// <summary> Класс заглушка для IHttpClient. </summary>
public class WindowsHttpClientMock : IHttpClient
{
    /// <summary> Сохранение информации об узле сети в json файл. </summary>
    public void SendHostInformation(HostInformation hostInformation)
    {
        if (!Directory.Exists("mock"))
        {
            Directory.CreateDirectory("mock");
        }
        var fileName = $"mock\\{DateTime.Now:yyyy_MM_dd-HH_mm_ss}.json";

        using (var stream = File.CreateText(fileName))
        {
            var serializer = new JsonSerializer();
            serializer.Serialize(stream, hostInformation);
        }
    }
}

