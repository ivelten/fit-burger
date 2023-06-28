using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FitBurger.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    public Repository(FitBurgerDbContext context, IDbContextFactory<FitBurgerDbContext> contextFactory)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }
    
    protected FitBurgerDbContext Context { get; }
    protected IDbContextFactory<FitBurgerDbContext> ContextFactory { get; }

    public async Task AddAsync(T item, CancellationToken cancellationToken = default)
    {
        await Context.Set<T>().AddAsync(item, cancellationToken);
    }

    public async Task<T[]> GetAsync(Func<T, bool>? predicate = null, bool useFactory = false)
    {
        var context = useFactory ? await ContextFactory.CreateDbContextAsync() : Context;

        try
        {
            if (predicate is null)
                return await context.Set<T>().ToArrayAsync();

            return await context.Set<T>().Where(predicate).AsQueryable().ToArrayAsync();
        }
        finally
        {
            if (useFactory)
                await context.DisposeAsync();
        }
    }

    public async Task<T?> GetAsync(int id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Attach(T entity)
    {
        Context.Attach(entity);
    }
}