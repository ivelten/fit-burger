using FitBurger.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBurger.Infrastructure.EntityConfigurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .Property(x => x.Street)
            .HasColumnType("varchar(200)");

        builder
            .Property(x => x.ReceiverName)
            .HasColumnType("varchar(100)");

        builder
            .UseTpcMappingStrategy();
    }
}