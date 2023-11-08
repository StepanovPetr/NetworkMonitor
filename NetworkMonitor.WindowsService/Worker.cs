using NetworkMonitor.Common.Constants;
using NetworkMonitor.Common.Interfaces;
using NetworkMonitor.Common.Settings;
using System.Net.NetworkInformation;

namespace NetworkMonitor.WindowsService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostInformationService _hostInformationService;
        private readonly IHttpClient _httpClient;
        private readonly HttpClientSetting _clientSetting;

        public Worker(ILogger<Worker> logger, IWindowsCmdManager cmdManager, IPInterfaceProperties ipInterfaceProperties, IHostInformationService hostInformationService, IHttpClient httpClient, HttpClientSetting clientSetting)
        {
            _logger = logger;
            _hostInformationService = hostInformationService;
            _httpClient = httpClient;
            _clientSetting = clientSetting;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation($"Получение настроек сети.");
                    var hostInformation = _hostInformationService.GetHostInformation();
                    _logger.LogInformation($"Настройки сети получены.");

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

                    _httpClient.SendHostInformation(hostInformation);
                    _logger.LogInformation(InfoMessages.HttpClientMessageSent);

                    await Task.Delay(_clientSetting.Delay > 5000
                        ? _clientSetting.Delay
                        : DefaultValues.SendHostInformationDelay,
                        stoppingToken);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}