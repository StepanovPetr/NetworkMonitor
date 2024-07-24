using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkMonitor.Domain.Entities;

namespace NetworkMonitor.Domain.Configurations;

internal sealed class HostInformationConfiguration : IEntityTypeConfiguration<HostInformation>
{
    public void Configure(EntityTypeBuilder<HostInformation> builder)
    {
        builder.ToTable("HostInformation");

        builder.HasKey(x => x.Id);

        builder.HasKey(x => x.Mac);

        builder.Property(x => x.HostName);

        builder.Property(x => x.Dhcp);

        builder.Property(x => x.Dns);

        builder.Property(x => x.Gateway);

        builder.Property(x => x.IPv4Address)
            .HasColumnName("Ipv4Address");
    }
}