﻿using NetworkMonitor.Implementation.HostInformationService;
using NetworkMonitor.Tests.Builders;
using NUnit.Framework;

namespace NetworkMonitor.Tests
{
    [TestFixture(Description = "Тесты для WindowsHostInformationService.")]
    public class WindowsHostInformationServiceTests
    {
        [Test(Description = "Тест поучения адреса DHCP.")]
        public void WindowsHostInformationService_GetDhcp_Should()
        {
            // Arrange.
            var iPInterfaceProperties = IPInterfacePropertiesBuilder
                .CreateBuilder()
                .SetDhcp("192.168.1.1")
                .Build();

            var windowsHostInformationService = new WindowsHostInformationService(iPInterfaceProperties);

            // Act.
            var result = windowsHostInformationService.GetDhcp();

            // Assert.
            Assert.AreEqual("192.168.1.1", result);
        }

        [Test(Description = "Тест поучения адреса DNS.")]
        public void WindowsHostInformationService_GetDns_Should()
        {
            // Arrange.
            var iPInterfaceProperties = IPInterfacePropertiesBuilder
                .CreateBuilder()
                .SetDns("192.168.1.1")
                .Build();

            var windowsHostInformationService = new WindowsHostInformationService(iPInterfaceProperties);

            // Act.
            var result = windowsHostInformationService.GetDnsList();

            // Assert.
            Assert.AreEqual("192.168.1.1", result.FirstOrDefault());
        }

        [Test(Description = "Тест поучения адреса Шлюза.")]
        public void WindowsHostInformationService_GetGateway_Should()
        {
            // Arrange.
            var iPInterfaceProperties = IPInterfacePropertiesBuilder
                .CreateBuilder()
                .SetGateway("192.168.1.1")
                .Build();

            var windowsHostInformationService = new WindowsHostInformationService(iPInterfaceProperties);

            // Act.
            var result = windowsHostInformationService.GetGateway();

            // Assert.
            Assert.AreEqual("192.168.1.1", result);
        }
    }
}