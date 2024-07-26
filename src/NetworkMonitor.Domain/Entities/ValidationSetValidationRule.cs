namespace NetworkMonitor.Domain.Entities;

public class ValidationSetValidationRule
{
    /// <summary> Id. </summary>
    public int Id { get; set; }

    public int ValidationRulesId { get; set; }

    public int ValidationSetsId { get; set; }

    public ValidationSet ValidationSet { get; set; }

    //public ValidationRule ValidationRule { get; set; }
}