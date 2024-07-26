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
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(x => x.Mac)
            .HasColumnName("mac");

        builder.Property(x => x.HostName)
            .HasColumnName("hostname");

        builder.Property(x => x.Dhcp)
            .HasColumnName("dhcp");

        builder.Property(x => x.Dns)
            .HasColumnName("dns");

        builder.Property(x => x.Gateway)
            .HasColumnName("gateway");

        builder.Property(x => x.IPv4Address)
            .HasColumnName("ipv4address");
    }
}