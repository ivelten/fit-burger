using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FitBurger.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    public Repository(FitBurgerDbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    protected FitBurgerDbContext Context { get; }

    public async Task AddAsync(T item, CancellationToken cancellationToken = default)
    {
        await Context.Set<T>().AddAsync(item, cancellationToken);
    }

    public async Task<T[]> GetAsync(Func<T, bool>? predicate = null)
    {
        if (predicate is null)
            return await Context.Set<T>().ToArrayAsync();

        return await Context.Set<T>().Where(predicate).AsQueryable().ToArrayAsync();
    }

    public async Task<T?> GetAsync(int id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }
}