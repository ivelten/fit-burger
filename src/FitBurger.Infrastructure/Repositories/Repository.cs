using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FitBurger.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    public Repository(IDbContextFactory<FitBurgerDbContext> contextFactory)
    {
        ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }
    
    protected IDbContextFactory<FitBurgerDbContext> ContextFactory { get; }

    public async Task AddAsync(T item, CancellationToken cancellationToken = default)
    {
        await using var context = await ContextFactory.CreateDbContextAsync(cancellationToken);
        await context.Set<T>().AddAsync(item, cancellationToken);
    }

    public async Task<T[]> GetAsync(Func<T, bool>? predicate = null)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        
        if (predicate is null)
            return await context.Set<T>().ToArrayAsync();

        return await context.Set<T>().Where(predicate).AsQueryable().ToArrayAsync();
    }

    public async Task<T?> GetAsync(int id)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        
        return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }
}