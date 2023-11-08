using NetworkMonitor.Common.Constants;
using NetworkMonitor.Common.Exceptions;
using NetworkMonitor.Common.ExtensionMethods;
using NetworkMonitor.Common.Settings;
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
            var networkInterfaceSetting = new NetworkInterfaceSetting
            {
                Name = name
            };

            // Act.
            var result = NetworkInterfaceBuilder
                .BuildArray(_stringList)
                .GetNetworkInterfaceByName(networkInterfaceSetting);

            // Assert.
            Assert.NotNull(result);
        }

        [Test(Description = "Сетевой интерфейс не найден.")]
        public void WindowsNetworkInterfacesManagerTests_GetNetworkInterface_NotFound()
        {
            // Arrange.
            var networkInterfaceSetting = new NetworkInterfaceSetting
            {
                Name = "NotFoundName"
            };

            // Act.
            var ex = Assert.Throws<NetworkInterfaceException>(() => NetworkInterfaceBuilder
                .BuildArray(_stringList)
                .GetNetworkInterfaceByName(networkInterfaceSetting));

            // Assert.
            Assert.AreEqual(ErrorMessages.NetworkInterfaceExceptionNotFound, ex.Message);
        }
    }
}