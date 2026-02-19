using Microsoft.EntityFrameworkCore;
using NetworkMonitor.Domain;
using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Services;

/// <inheritdoc />
public class ValidationSetValidationRuleService : IValidationSetValidationRuleService
{
    private readonly Context _context;

    public ValidationSetValidationRuleService(Context context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ValidationSetValidationRule>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ValidationSetValidationRules
            .Include(x => x.ValidationSet)
            .Include(x => x.ValidationRule)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ValidationSetValidationRule?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.ValidationSetValidationRules
            .Include(x => x.ValidationSet)
            .Include(x => x.ValidationRule)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ValidationSetValidationRule>> GetByValidationSetIdAsync(int validationSetId, CancellationToken cancellationToken = default)
    {
        return await _context.ValidationSetValidationRules
            .Include(x => x.ValidationSet)
            .Include(x => x.ValidationRule)
            .Where(x => x.ValidationSetsId == validationSetId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<ValidationSetValidationRule>> GetByValidationRuleIdAsync(int validationRuleId, CancellationToken cancellationToken = default)
    {
        return await _context.ValidationSetValidationRules
            .Include(x => x.ValidationSet)
            .Include(x => x.ValidationRule)
            .Where(x => x.ValidationRulesId == validationRuleId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ValidationSetValidationRule> AddAsync(ValidationSetValidationRule entity, CancellationToken cancellationToken = default)
    {
        _context.ValidationSetValidationRules.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(ValidationSetValidationRule entity, CancellationToken cancellationToken = default)
    {
        _context.ValidationSetValidationRules.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.ValidationSetValidationRules.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _context.ValidationSetValidationRules.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
