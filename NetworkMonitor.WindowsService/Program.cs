using NetworkMonitor.Common.ExtensionMethods;
using NetworkMonitor.Common.Interfaces;
using NetworkMonitor.Implementation.Windows;
using NetworkMonitor.WindowsService;
using System.Net.NetworkInformation;
using NetworkMonitor.Common.Settings;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        var networkInterfaceSetting = new NetworkInterfaceSetting
        {
            Name = "Ethernet"
        };
        var ipProperties = NetworkInterface
            .GetAllNetworkInterfaces()
            .GetNetworkInterfaceByName(networkInterfaceSetting)
            .GetIPProperties();

        services.AddSingleton<IWindowsCmdManager, WindowsCmdManager>();
        services.AddSingleton<IPInterfaceProperties>(ipProperties);
        services.AddSingleton<IHostInformationService, WindowsHostInformationService>();
        services.AddSingleton<IHttpClient, WindowsHttpClientMock>();

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
