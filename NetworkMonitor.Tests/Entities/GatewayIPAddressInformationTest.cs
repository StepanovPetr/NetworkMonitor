using System.Net;
using System.Net.NetworkInformation;

namespace NetworkMonitor.Tests.Entities;

public class GatewayIPAddressInformationTest : GatewayIPAddressInformation
{
    public GatewayIPAddressInformationTest(string ip)
    {
        Address = IPAddress.Parse(ip);
    }

    public override IPAddress Address { get; }
}