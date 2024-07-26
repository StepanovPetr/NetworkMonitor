using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetworkMonitor.Common.Dto;
using NetworkMonitor.Domain;

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
        public async Task<HostInformation> Post(HostInformation hostInformation )
        {
            _logger.LogInformation("Сообщение получено.");

            var hostInformations = await Context.HostInformations.ToListAsync();

            var rules = await Context.ValidationRules.ToListAsync();

            var sets = await Context.ValidationSets.ToListAsync();

            var validationSetValidationRuleConfigurations = await Context.
                ValidationSetValidationRules
                .Include(x => x.ValidationSet)
                .ToListAsync();

            var host = new Domain.Entities.HostInformation();

            Context.HostInformations.Add(host);
            await Context.SaveChangesAsync();

            return hostInformation;
        }
    }
}