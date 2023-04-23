namespace FitBurger.Core.Domain.Repositories.Abstractions;

public interface IRepository<in T>
{
    Task AddAsync(T item);
}