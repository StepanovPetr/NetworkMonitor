using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Services;

/// <summary>
/// Сервис доступа к наборам правил валидации.
/// </summary>
public interface IValidationSetService
{
    /// <summary>
    /// Получить все наборы правил валидации.
    /// </summary>
    Task<IReadOnlyList<ValidationSet>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить набор правил по идентификатору.
    /// </summary>
    Task<ValidationSet?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавить набор правил валидации.
    /// </summary>
    Task<ValidationSet> AddAsync(ValidationSet entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновить набор правил валидации.
    /// </summary>
    Task UpdateAsync(ValidationSet entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить набор правил по идентификатору.
    /// </summary>
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
