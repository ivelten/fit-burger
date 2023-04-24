using FitBurger.Core.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

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

    public async Task<T[]> GetAsync(Func<T, bool>? predicate = null)
    {
        if (predicate is null)
            return await _context.Set<T>().ToArrayAsync();

        return await _context.Set<T>().Where(predicate).AsQueryable().ToArrayAsync();
    }
}