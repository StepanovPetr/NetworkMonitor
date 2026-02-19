using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Domain;
using Swashbuckle.AspNetCore.Filters;
using NetworkMonitor.Api.Models.Examples.Validation;

namespace NetworkMonitor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly ILogger<ValidationController> _logger;
        private Context Context { get; set; }

        public ValidationController(ILogger<ValidationController> logger, Context context)
        {
            _logger = logger;
            Context = context;
        }

        [HttpPost(Name = "Validation")]
        [SwaggerRequestExample(typeof(HostInformationDto), typeof(HostInformationDtoExamples))]
        [SwaggerResponseExample(200, typeof(HostInformationDtoExample))]
        public async Task<HostInformationDto> Post(HostInformationDto hostInformation )
        {
            _logger.LogInformation("Сообщение получено.");

            var hostInformations = await Context.HostInformation.ToListAsync();
            var rules = await Context.ValidationRules.ToListAsync();
            var sets = await Context.ValidationSets.ToListAsync();
            var listAsync = await Context.ValidationSetValidationRules.ToListAsync();

            return hostInformation;
        }
    }
}