using System.Collections;
using System.Net;
using System.Net.NetworkInformation;

namespace NetworkMonitor.Tests.Entities;

public class GatewayIPAddressInformationCollectionTest : GatewayIPAddressInformationCollection, IEnumerable
{
    private List<GatewayIPAddressInformationTest> _addresses;

    public GatewayIPAddressInformationCollectionTest()
    {
        _addresses = new List<GatewayIPAddressInformationTest>();
    }

    public GatewayIPAddressInformationCollectionTest(string address)
    {
        _addresses = new List<GatewayIPAddressInformationTest>();
        _addresses.Add(new GatewayIPAddressInformationTest(address));
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public sealed override IEnumerator<GatewayIPAddressInformation> GetEnumerator()
    {
        return _addresses.GetEnumerator();
    }

    public sealed override int Count => _addresses.Count;
}