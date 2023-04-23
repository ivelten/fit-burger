using FitBurger.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBurger.Infrastructure.EntityConfigurations;

public sealed class DeliverymanConfiguration : IEntityTypeConfiguration<Deliveryman>
{
    public void Configure(EntityTypeBuilder<Deliveryman> builder)
    {
        builder
            .Property(x => x.Name)
            .HasColumnType("varchar(100)");

        builder
            .Property(x => x.EmergencyContact)
            .HasColumnType("varchar(200)");

        builder
            .Property(x => x.LicensePlate)
            .HasColumnType("char(7)");

        builder
            .Property(x => x.DrivingLicense)
            .HasColumnType("varchar(12)");
    }
}