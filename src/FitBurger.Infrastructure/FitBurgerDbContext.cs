using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Enums;
using FitBurger.Core.Domain.ValueObjects;
using FitBurger.Infrastructure.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace FitBurger.Infrastructure;

public class FitBurgerDbContext : DbContext, IUnitOfWork
{
    public FitBurgerDbContext(DbContextOptions<FitBurgerDbContext> options) : base(options)
    {
    }

    internal DbSet<Attendant> Attendants { get; init; } = default!;

    internal DbSet<Booking> Bookings { get; init; } = default!;

    internal DbSet<Customer> Customers { get; init; } = default!;

    internal DbSet<Deliveryman> Deliverymen { get; init; } = default!;

    internal DbSet<Order> Orders { get; init; } = default!;

    internal DbSet<OrderItem> OrderItems { get; init; } = default!;

    internal DbSet<Product> Products { get; init; } = default!;

    internal DbSet<OrderPayment> OrderPayments { get; init; } = default!;

    internal DbSet<User> Users { get; init; } = default!;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await SaveChangesAsync(cancellationToken);
        }
        catch
        {
            await UndoChangesAsync(cancellationToken);
            throw;
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<string>()
            .HaveColumnType("varchar(256)");

        configurationBuilder
            .Properties<decimal>()
            .HaveColumnType("decimal(18,2)");
        
        configurationBuilder
            .Properties<Cpf>()
            .HaveConversion<CpfConverter>()
            .HaveColumnType("char(11)");

        configurationBuilder
            .Properties<Email>()
            .HaveConversion<EmailConverter>()
            .HaveColumnType("varchar(320)");

        configurationBuilder
            .Properties<Gender>()
            .HaveConversion<GenderConverter>()
            .HaveColumnType("char(1)");

        configurationBuilder
            .Properties<PhoneNumber>()
            .HaveConversion<PhoneNumberConverter>()
            .HaveColumnType("varchar(11)");

        configurationBuilder
            .Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in
                 modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetProperties()
                         .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(256)");

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyMarker.Assembly);

        base.OnModelCreating(modelBuilder);
    }

    private async Task UndoChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State != EntityState.Unchanged);

        foreach (var dbEntityEntry in entries)
            switch (dbEntityEntry.State)
            {
                case EntityState.Added:
                {
                    dbEntityEntry.State = EntityState.Detached;
                    break;
                }
                case EntityState.Modified:
                {
                    await dbEntityEntry.ReloadAsync(cancellationToken);
                    break;
                }
                case EntityState.Deleted:
                {
                    dbEntityEntry.State = EntityState.Modified;
                    await dbEntityEntry.ReloadAsync(cancellationToken);
                    break;
                }
            }
    }
}