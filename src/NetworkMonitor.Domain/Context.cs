using Microsoft.EntityFrameworkCore;
using NetworkMonitor.Domain.Configurations;
using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Domain
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<HostInformation> HostInformations { get; set; }

        public DbSet<ValidationSet> ValidationSets { get; set; }

        public DbSet<ValidationRule> ValidationRules { get; set; }

        public DbSet<ValidationSetValidationRule> ValidationSetValidationRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HostInformationConfiguration());
            modelBuilder.ApplyConfiguration(new ValidationRuleConfiguration());
            modelBuilder.ApplyConfiguration(new ValidationSetConfiguration());
            modelBuilder.ApplyConfiguration(new ValidationSetValidationRuleConfiguration());
            //ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}