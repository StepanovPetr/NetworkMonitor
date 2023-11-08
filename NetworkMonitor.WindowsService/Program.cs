using NetworkMonitor.Common.ExtensionMethods;
using NetworkMonitor.Common.Interfaces;
using NetworkMonitor.Implementation.Windows;
using NetworkMonitor.WindowsService;
using System.Net.NetworkInformation;
using NetworkMonitor.Common.Settings;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(config =>
     {
         config.ServiceName = "NetworkMonitor.WindowsService";
     })
    .ConfigureServices(services =>
    {
        var networkInterfaceSetting = configuration.GetSection("NetworkInterfaceSetting").Get<NetworkInterfaceSetting>();
        var httpClientSetting = configuration.GetSection("HttpClientSetting").Get<HttpClientSetting>();

        var ipProperties = NetworkInterface
            .GetAllNetworkInterfaces()
            .GetNetworkInterfaceByName(networkInterfaceSetting)
            .GetIPProperties();

        services.AddSingleton<IWindowsCmdManager, WindowsCmdManager>();
        services.AddSingleton<IPInterfaceProperties>(ipProperties);
        services.AddSingleton<IHostInformationService, WindowsHostInformationService>();
        services.AddSingleton<IHttpClient, WindowsHttpClientMock>();
        services.AddSingleton<HttpClientSetting>(httpClientSetting);

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();