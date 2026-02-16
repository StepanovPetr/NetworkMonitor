using Microsoft.EntityFrameworkCore;
using NetworkMonitor.Domain;
using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Services;

/// <inheritdoc />
public class ValidationRuleService : IValidationRuleService
{
    private readonly Context _context;

    public ValidationRuleService(Context context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ValidationRule>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ValidationRules
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ValidationRule?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.ValidationRules
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ValidationRule> AddAsync(ValidationRule entity, CancellationToken cancellationToken = default)
    {
        _context.ValidationRules.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(ValidationRule entity, CancellationToken cancellationToken = default)
    {
        _context.ValidationRules.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.ValidationRules.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _context.ValidationRules.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
