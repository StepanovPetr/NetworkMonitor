using Microsoft.EntityFrameworkCore;
using NetworkMonitor.Domain;
using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Services;

/// <inheritdoc />
public class ValidationSetService : IValidationSetService
{
    private readonly Context _context;

    public ValidationSetService(Context context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ValidationSet>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ValidationSets
            .Include(x => x.ValidationSetValidationRules!)
            .ThenInclude(x => x.ValidationRule)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ValidationSet?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.ValidationSets
            .Include(x => x.ValidationSetValidationRules!)
            .ThenInclude(x => x.ValidationRule)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ValidationSet> AddAsync(ValidationSet entity, CancellationToken cancellationToken = default)
    {
        _context.ValidationSets.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(ValidationSet entity, CancellationToken cancellationToken = default)
    {
        _context.ValidationSets.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.ValidationSets.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _context.ValidationSets.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
