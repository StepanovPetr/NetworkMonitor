using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Services;

/// <summary>
/// Сервис доступа к информации о хостах.
/// </summary>
public interface IHostInformationService
{
    /// <summary>
    /// Получить все записи о хостах.
    /// </summary>
    Task<IReadOnlyList<HostInformation>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить запись о хосте по идентификатору.
    /// </summary>
    Task<HostInformation?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить запись о хосте по MAC-адресу.
    /// </summary>
    Task<HostInformation?> GetByMacAsync(string mac, CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавить запись о хосте.
    /// </summary>
    Task<HostInformation> AddAsync(HostInformation entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновить запись о хосте.
    /// </summary>
    Task UpdateAsync(HostInformation entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить запись о хосте по идентификатору.
    /// </summary>
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
