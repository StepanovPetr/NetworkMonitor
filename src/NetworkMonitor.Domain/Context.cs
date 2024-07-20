using Microsoft.EntityFrameworkCore;
using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Domain
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<HostInformation> HostInformations { get; set; }
    }
}