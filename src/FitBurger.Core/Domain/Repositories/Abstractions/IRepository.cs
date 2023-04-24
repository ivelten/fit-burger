using System.Diagnostics.CodeAnalysis;

namespace FitBurger.Core.Domain.Repositories.Abstractions;

public interface IRepository<in T> where T : class
{
    Task AddAsync(T item, CancellationToken cancellationToken = default);
}