using Microsoft.AspNetCore.Mvc;
using NetworkMonitor.Common.Dto;

namespace NetworkMonitor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly ILogger<ValidationController> _logger;

        public ValidationController(ILogger<ValidationController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Validation")]
        public HostInformation Post(HostInformation hostInformation )
        {
            _logger.LogInformation("Сообщение получено.");
            return hostInformation;
        }
    }
}