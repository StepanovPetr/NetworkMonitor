namespace NetworkMonitor.Domain.Entities;

public class ValidationRule
{
    /// <summary> Id. </summary>
    public int Id { get; set; }

    public string ValidationRuleName { get; set; }

    public string Description { get; set; }

    public List<ValidationSet> ValidationSets { get; } = new List<ValidationSet>();

    public virtual ICollection<ValidationSetValidationRule> ValidationSetValidationRules { get; set; }
}