using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Domain.Configurations;

public class ValidationSetConfiguration : IEntityTypeConfiguration<ValidationSet>
{
    public void Configure(EntityTypeBuilder<ValidationSet> builder)
    {
        builder.ToTable("validationsets");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(x => x.ValidationSetsName)
            .HasColumnName("validationsetsname");

        builder.Property(x => x.Description)
            .HasColumnName("description");
    }
}