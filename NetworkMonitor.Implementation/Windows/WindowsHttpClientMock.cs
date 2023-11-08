using NetworkMonitor.Common.Dto;
using NetworkMonitor.Common.Interfaces;
using Newtonsoft.Json;

namespace NetworkMonitor.Implementation.Windows;

public class WindowsHttpClientMock : IHttpClient
{
    public void SendHostInformation(HostInformation hostInformation)
    {
        if (!Directory.Exists("mock"))
        {
            Directory.CreateDirectory("mock");
        }
        var fileName = $"mock\\{DateTime.Now:MM_dd_yyyy-HH_mm_ss}.json";

        using (var stream = File.CreateText(fileName))
        {
            var serializer = new JsonSerializer();
            serializer.Serialize(stream, hostInformation);
        }
    }
}