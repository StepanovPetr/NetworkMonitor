using NetworkMonitor.Common.Dto;
using NetworkMonitor.Implementation;
using NetworkMonitor.Tests.Builders;
using NUnit.Framework;

namespace NetworkMonitor.Tests
{
    [TestFixture(Description = "Тесты для WindowsNetworkInterfacesManagerTests.")]
    public class WindowsNetworkInterfacesManagerTests
    {
        private List<string> _stringList = new List<string>()
        {
            "Ethernet",
            "Ethernet1",
            "Bluetooth Network Connection",
        };

        [Test(Description = "Тест поучения сетевого адаптера по имени.")]
        [TestCase("Ethernet")]
        [TestCase("Ethernet1")]
        [TestCase("Bluetooth Network Connection")]
        public void WindowsNetworkInterfacesManagerTests_GetNetworkInterface_Should(string name)
        {
            // Arrange.
            var windowsNetworkInterfacesManager = new WindowsNetworkInterfacesManager();

            var networkInterfaceSetting = new NetworkInterfaceSetting
            {
                Name = name
            };

            // Act.
            var result = windowsNetworkInterfacesManager.GetNetworkInterface(NetworkInterfaceBuilder
                    .BuildArray(_stringList),
                networkInterfaceSetting);

            // Assert.
            Assert.NotNull(result);
        }
    }
}