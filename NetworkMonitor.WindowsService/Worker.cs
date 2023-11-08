using NetworkMonitor.Common.Constants;
using NetworkMonitor.Common.Interfaces;
using System.Net.NetworkInformation;

namespace NetworkMonitor.WindowsService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostInformationService _hostInformationService;
        private readonly IHttpClient _httpClient;

        public Worker(ILogger<Worker> logger, IWindowsCmdManager cmdManager, IPInterfaceProperties ipInterfaceProperties, IHostInformationService hostInformationService, IHttpClient httpClient)
        {
            _logger = logger;
            _hostInformationService = hostInformationService;
            _httpClient = httpClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var hostInformation = _hostInformationService.GetHostInformation();

            _logger.LogInformation($"Gateway - {hostInformation.Gateway}");
            _logger.LogInformation($"HostName - {hostInformation.HostName}");
            _logger.LogInformation($"IPv4Address - {hostInformation.IPv4Address}");
            _logger.LogInformation($"DHCP - {hostInformation.Dhcp}");

            _logger.LogInformation("DNS сервера:");
            foreach (var address in hostInformation.DnsList)
            {
                _logger.LogInformation(address);
            }

            _logger.LogInformation("Таблица трассировки:");
            foreach (var address in hostInformation.TracertTable)
            {
                _logger.LogInformation(address);
            }

            _logger.LogInformation("Таблица ARP:");
            foreach (var address in hostInformation.ArpTable)
            {
                _logger.LogInformation($"{address.IpAddress} - {address.MacAddress}");
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                _httpClient.SendHostInformation(hostInformation);
                await Task.Delay(5000);
                Console.WriteLine(InfoMessages.HttpClientMessageSent);
            }
        }
    }
}