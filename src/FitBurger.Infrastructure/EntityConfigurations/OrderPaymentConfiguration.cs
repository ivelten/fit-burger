using FitBurger.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBurger.Infrastructure.EntityConfigurations;

public class OrderPaymentConfiguration : IEntityTypeConfiguration<OrderPayment>
{
    public void Configure(EntityTypeBuilder<OrderPayment> builder)
    {
        builder
            .Property(x => x.Amount)
            .HasColumnType("decimal(18,2)");
    }
}