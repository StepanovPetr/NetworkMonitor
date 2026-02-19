using NetworkMonitor.Common.Dto;
using Swashbuckle.AspNetCore.Filters;
using Host = NetworkMonitor.Common.Dto.Host;

namespace NetworkMonitor.Api.Models.Examples.Validation;

/// <summary> Пример тела запроса/ответа для HostInformationDto. </summary>
public class HostInformationDtoExample : IExamplesProvider<HostInformationDto>
{
    /// <inheritdoc />
    public HostInformationDto GetExamples()
    {
        return new HostInformationDto
        {
            Dhcp = "192.168.1.1",
            Gateway = "192.168.1.1",
            HostName = "WORKSTATION01",
            IPv4Address = "192.168.1.100",
            DnsList = new[] { "8.8.8.8", "8.8.4.4", "192.168.1.1" },
            ArpTable = new[]
            {
                new Host { IpAddress = "192.168.1.1", MacAddress = "00-1A-2B-3C-4D-5E" },
                new Host { IpAddress = "192.168.1.100", MacAddress = "00-50-56-C0-00-08" }
            },
            TracertTable = new[] { "192.168.1.1", "10.0.0.1", "8.8.8.8" }
        };
    }
}
