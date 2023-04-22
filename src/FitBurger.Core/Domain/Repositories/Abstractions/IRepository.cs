namespace FitBurger.Core.Domain.Repositories.Abstractions;

public interface IRepository<T>
{
    Task AddAsync(T item);
}