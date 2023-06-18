using FitBurger.Core.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBurger.Infrastructure.EntityConfigurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(x => x.Name)
            .HasColumnType("varchar(100)");

        builder
            .Property(x => x.Address)
            .HasColumnType("varchar(200)");

        builder
            .UseTpcMappingStrategy();
    }
}