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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HostInformationConfiguration()); 
            //ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}