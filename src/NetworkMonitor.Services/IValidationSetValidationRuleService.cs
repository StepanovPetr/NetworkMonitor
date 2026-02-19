using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Services;

/// <summary>
/// Сервис доступа к связям набор правил валидации — правило валидации (много-ко-многим).
/// </summary>
public interface IValidationSetValidationRuleService
{
    /// <summary>
    /// Получить все связи.
    /// </summary>
    Task<IReadOnlyList<ValidationSetValidationRule>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить связь по идентификатору.
    /// </summary>
    Task<ValidationSetValidationRule?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить связи по идентификатору набора правил.
    /// </summary>
    Task<IReadOnlyList<ValidationSetValidationRule>> GetByValidationSetIdAsync(int validationSetId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить связи по идентификатору правила валидации.
    /// </summary>
    Task<IReadOnlyList<ValidationSetValidationRule>> GetByValidationRuleIdAsync(int validationRuleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавить связь.
    /// </summary>
    Task<ValidationSetValidationRule> AddAsync(ValidationSetValidationRule entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновить связь.
    /// </summary>
    Task UpdateAsync(ValidationSetValidationRule entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить связь по идентификатору.
    /// </summary>
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
