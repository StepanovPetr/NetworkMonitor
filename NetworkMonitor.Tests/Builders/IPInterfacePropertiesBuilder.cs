using System.Net.NetworkInformation;
using Moq;
using NetworkMonitor.Tests.Entities;

namespace NetworkMonitor.Tests.Builders;

public class IPInterfacePropertiesBuilder
{
    private Mock<IPInterfaceProperties> _mockIpInterfaceProperties = new();
    private const string _ip = "192.168.0.1";

    /// <summary> Создание нового экземпляра IPInterfacePropertiesBuilder. </summary>
    /// <returns> Новый экземпляр IPInterfacePropertiesBuilder </returns>
    public static IPInterfacePropertiesBuilder CreateBuilder()
    {
        return new();
    }

    public IPInterfacePropertiesBuilder SetDhcp(string ip)
    {
        IPAddressCollection addressCollectionTest = new IPAddressCollectionTest(ip);

        _mockIpInterfaceProperties.SetupGet(i => i.DhcpServerAddresses)
            .Returns(addressCollectionTest);
        return this;
    }

    public IPInterfacePropertiesBuilder SetDns(string ip)
    {
        IPAddressCollection addressCollectionTest = new IPAddressCollectionTest(ip);

        _mockIpInterfaceProperties.SetupGet(i => i.DnsAddresses)
            .Returns(addressCollectionTest);
        return this;
    }

    public IPInterfacePropertiesBuilder SetGateway(string ip)
    {
        GatewayIPAddressInformationCollectionTest addressCollectionTest = new GatewayIPAddressInformationCollectionTest(ip);

        _mockIpInterfaceProperties.SetupGet(i => i.GatewayAddresses)
            .Returns(addressCollectionTest);
        return this;
    }

    /// <summary> Получение экземпляра класса IPInterfaceProperties. </summary>
    /// <returns> Экземпляр класса IPInterfaceProperties. </returns>
    public IPInterfaceProperties Build()
    {
        return _mockIpInterfaceProperties.Object;
    }
}