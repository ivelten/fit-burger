using FitBurger.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBurger.Infrastructure.EntityConfigurations;

public sealed class AttendantConfiguration : IEntityTypeConfiguration<Attendant>
{
    public void Configure(EntityTypeBuilder<Attendant> builder)
    {
        builder
            .Property(x => x.Name)
            .HasColumnType("varchar(100)");

        builder
            .Property(x => x.Address)
            .HasColumnType("varchar(200)");

        builder
            .Property(x => x.Salary)
            .HasPrecision(18, 2);

        builder
            .Property(x => x.Salary)
            .HasColumnType("decimal(18,2)");
    }
}