using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Entities;
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
    
    private async Task UndoChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State != EntityState.Unchanged);

        foreach (var dbEntityEntry in entries)
        {
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
}