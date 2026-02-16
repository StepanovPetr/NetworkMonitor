using Microsoft.EntityFrameworkCore;
using NetworkMonitor.Domain;
using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Services;

/// <inheritdoc />
public class HostInformationService : IHostInformationService
{
    private readonly Context _context;

    public HostInformationService(Context context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<HostInformation>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.HostInformation
            .Include(x => x.ValidationSet)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<HostInformation?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.HostInformation
            .Include(x => x.ValidationSet)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<HostInformation?> GetByMacAsync(string mac, CancellationToken cancellationToken = default)
    {
        return await _context.HostInformation
            .Include(x => x.ValidationSet)
            .FirstOrDefaultAsync(x => x.Mac == mac, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<HostInformation> AddAsync(HostInformation entity, CancellationToken cancellationToken = default)
    {
        _context.HostInformation.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(HostInformation entity, CancellationToken cancellationToken = default)
    {
        _context.HostInformation.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.HostInformation.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _context.HostInformation.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
