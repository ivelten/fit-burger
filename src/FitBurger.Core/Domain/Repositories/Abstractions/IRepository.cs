using FitBurger.Core.Domain.Entities.Abstractions;

namespace FitBurger.Core.Domain.Repositories.Abstractions;

public interface IRepository<T> where T : Entity
{
    Task AddAsync(T item, CancellationToken cancellationToken = default);

    Task<T[]> GetAsync(Func<T, bool>? predicate = null, bool useFactory = false);

    Task<T?> GetAsync(int id);

    void Attach(T entity);
}