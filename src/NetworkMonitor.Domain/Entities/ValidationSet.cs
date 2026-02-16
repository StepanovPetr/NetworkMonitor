namespace NetworkMonitor.Domain.Entities;

public class ValidationSet
{
    /// <summary> Id. </summary>
    public int Id { get; set; }

    public string ValidationSetsName { get; set; }

    public string Description { get; set; }

    public virtual ICollection<ValidationSetValidationRule>  ValidationSetValidationRules { get; set; }
}