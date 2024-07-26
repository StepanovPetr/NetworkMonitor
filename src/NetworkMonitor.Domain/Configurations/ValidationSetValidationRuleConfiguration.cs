using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkMonitor.Domain.Entities;
using System.Reflection.Metadata;

namespace NetworkMonitor.Domain.Configurations;

public class ValidationSetValidationRuleConfiguration : IEntityTypeConfiguration<ValidationSetValidationRule>
{
    public void Configure(EntityTypeBuilder<ValidationSetValidationRule> builder)
    {
        builder.ToTable("validationSetsvalidationRules");

        builder
            .HasKey(t => t.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(x => x.ValidationRulesId)
            .HasColumnName("validationRule_id");

        builder.Property(x => x.ValidationSetsId)
            .HasColumnName("validationSet_id");

        builder.HasOne(pt => pt.ValidationSet)
                .WithMany(t => t.ValidationSetValidationRules)
                .HasForeignKey(e => e.ValidationSetsId);

    }
}