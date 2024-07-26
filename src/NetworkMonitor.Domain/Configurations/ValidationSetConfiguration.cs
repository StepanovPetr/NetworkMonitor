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

        //builder.HasMany(x => x.ValidationRules)
        //    .WithMany(x => x.ValidationSets)
        //    .UsingEntity("validationsetsvalidationrules",
        //        j => j.HasOne(s => s.)
        //            .WithMany()
        //            .HasForeignKey(s => s.CourseId),
        //        j => j.HasOne(c => c.Student)
        //            .WithMany()
        //            .HasForeignKey(c => c.StudentId)););
    }
}