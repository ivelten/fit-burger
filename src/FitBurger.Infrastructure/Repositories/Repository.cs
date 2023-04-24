using FitBurger.Core.Domain.Repositories.Abstractions;

namespace FitBurger.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly FitBurgerDbContext _context;

    public Repository(FitBurgerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task AddAsync(T item, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(item, cancellationToken);
    }
}