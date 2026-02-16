using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Services;

/// <summary>
/// Сервис доступа к правилам валидации.
/// </summary>
public interface IValidationRuleService
{
    /// <summary>
    /// Получить все правила валидации.
    /// </summary>
    Task<IReadOnlyList<ValidationRule>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить правило по идентификатору.
    /// </summary>
    Task<ValidationRule?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавить правило валидации.
    /// </summary>
    Task<ValidationRule> AddAsync(ValidationRule entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновить правило валидации.
    /// </summary>
    Task UpdateAsync(ValidationRule entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить правило по идентификатору.
    /// </summary>
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
