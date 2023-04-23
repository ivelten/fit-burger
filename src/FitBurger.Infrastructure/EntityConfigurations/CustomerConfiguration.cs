using FitBurger.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBurger.Infrastructure.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .Property(x => x.Name)
            .HasColumnType("varchar(100)");

        builder
            .Property(x => x.Address)
            .HasColumnType("varchar(200)");
    }
}