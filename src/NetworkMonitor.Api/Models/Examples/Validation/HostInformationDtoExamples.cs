using NetworkMonitor.Common.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace NetworkMonitor.Api.Models.Examples.Validation
{
    public class HostInformationDtoExamples : IMultipleExamplesProvider<HostInformationDto>
    {

        public IEnumerable<SwaggerExample<HostInformationDto>> GetExamples()
        {
            yield return SwaggerExample.Create("Обычный запрос", new HostInformationDtoExample().GetExamples());
        }

    }
}
