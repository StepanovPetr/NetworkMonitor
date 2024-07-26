using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Domain.Configurations;

public class ValidationRuleConfiguration : IEntityTypeConfiguration<ValidationRule>
{
    public void Configure(EntityTypeBuilder<ValidationRule> builder)
    {
        builder.ToTable("validationrules");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(x => x.ValidationRuleName)
            .HasColumnName("validationrulename");

        builder.Property(x => x.Description)
            .HasColumnName("description");

        builder.HasMany(x => x.ValidationSets)
            .WithMany(x => x.ValidationRules)
            .UsingEntity("validationsetsvalidationrules");

    }
}