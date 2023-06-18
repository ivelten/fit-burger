using FitBurger.Core.Domain.Entities.Abstractions;

namespace FitBurger.Core.Domain.Repositories.Abstractions;

public interface IRepository<T> where T : EntityWithId
{
    Task AddAsync(T item, CancellationToken cancellationToken = default);

    Task<T[]> GetAsync(Func<T, bool>? predicate = null);

    Task<T?> GetAsync(int id);
}