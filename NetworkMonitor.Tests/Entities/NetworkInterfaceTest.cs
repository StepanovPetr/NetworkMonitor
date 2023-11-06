using System.Net.NetworkInformation;

namespace NetworkMonitor.Tests.Entities;

public class NetworkInterfaceTest : NetworkInterface
{
    public NetworkInterfaceTest(string name)
    {
        Name = name;
    }

    public override string Name { get; }
}