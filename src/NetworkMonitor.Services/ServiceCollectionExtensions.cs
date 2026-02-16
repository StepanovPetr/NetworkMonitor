using Microsoft.Extensions.DependencyInjection;
using NetworkMonitor.Domain;

namespace NetworkMonitor.Services;

/// <summary>
/// Расширения для регистрации сервисов доступа к Domain в контейнере DI.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Добавляет сервисы доступа к NetworkMonitor.Domain.
    /// </summary>
    /// <remarks>
    /// Перед вызовом необходимо зарегистрировать <see cref="Context"/> (DbContext) в контейнере.
    /// </remarks>
    public static IServiceCollection AddNetworkMonitorServices(this IServiceCollection services)
    {
        services.AddScoped<IHostInformationService, HostInformationService>();
        services.AddScoped<IValidationSetService, ValidationSetService>();
        services.AddScoped<IValidationRuleService, ValidationRuleService>();
        return services;
    }
}
