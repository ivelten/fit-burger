using FitBurger.Infrastructure.Abstractions;

namespace FitBurger.Infrastructure;

public sealed class DbInitializer : IDbInitializer
{
    private readonly FitBurgerDbContext _context;

    public DbInitializer(FitBurgerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task EnsureDeletedAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.EnsureDeletedAsync(cancellationToken);
    }

    public async Task EnsureCreatedAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.EnsureCreatedAsync(cancellationToken);
    }
}