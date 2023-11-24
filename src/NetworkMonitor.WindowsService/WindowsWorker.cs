using NetworkMonitor.Common.Constants;
using NetworkMonitor.Common.ExtensionMethods;
using NetworkMonitor.Common.Interfaces;
using NetworkMonitor.Common.Settings;

namespace NetworkMonitor.WindowsService
{
    public class WindowsWorker : BackgroundService
    {
        private readonly ILogger<WindowsWorker> _logger;
        private readonly IHostInformationService _hostInformationService;
        private readonly IHttpClient _httpClient;
        private readonly HttpClientSetting _clientSetting;

        public WindowsWorker(ILogger<WindowsWorker> logger,
            IHostInformationService hostInformationService, 
            IHttpClient httpClient, 
            HttpClientSetting clientSetting)
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
                    _logger.LogInformation("Получение настроек сети.");
                    var hostInformation = _hostInformationService.GetHostInformation();
                    _logger.LogInformation($"Настройки сети получены. {hostInformation.Log()}");
                    
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