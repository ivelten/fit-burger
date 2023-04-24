using System.Diagnostics.CodeAnalysis;

namespace FitBurger.Core.Domain.Repositories.Abstractions;

public interface IRepository<T> where T : class
{
    Task AddAsync(T item, CancellationToken cancellationToken = default);

    Task<T[]> GetAsync(Func<T, bool>? predicate = null);
}