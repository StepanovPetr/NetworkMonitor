using NetworkMonitor.Common.Dto;

namespace NetworkMonitor.Common.Interfaces;

public interface IHttpClient
{
    void SendHostInformation(HostInformation hostInformation);
}