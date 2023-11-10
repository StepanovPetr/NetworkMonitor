using System.Collections;
using System.Net;
using System.Net.NetworkInformation;

namespace NetworkMonitor.Tests.Entities;

public class IPAddressCollectionTest : IPAddressCollection, IEnumerable
{
    private List<IPAddress> _addresses;

    public IPAddressCollectionTest()
    {
        _addresses = new List<IPAddress>();
    }

    public IPAddressCollectionTest(string address)
    {
        _addresses ??= new List<IPAddress>();
        _addresses.Add(IPAddress.Parse(address));
    }

    public sealed override void Add(IPAddress address)
    {
        _addresses.Add(address);
    }

    public sealed override bool Contains(IPAddress address)
    {
        return _addresses.Contains(address);
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public sealed override IEnumerator<IPAddress> GetEnumerator()
    {
        return _addresses.GetEnumerator();
    }

    public sealed override int Count => _addresses.Count;
}