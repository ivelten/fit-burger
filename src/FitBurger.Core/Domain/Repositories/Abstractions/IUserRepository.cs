using FitBurger.Core.Domain.Entities.Abstractions;

namespace FitBurger.Core.Domain.Repositories.Abstractions;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByUserNameAsync(string userName);
}