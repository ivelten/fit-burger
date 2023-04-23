using FitBurger.Infrastructure.Abstractions;

namespace FitBurger.Infrastructure;

public sealed class DbInitializer : IDbInitializer
{
    private readonly FitBurgerDbContext _context;

    public DbInitializer(FitBurgerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task EnsureDeletedAsync()
    {
        await _context.Database.EnsureDeletedAsync();
    }

    public async Task EnsureCreatedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
    }
}