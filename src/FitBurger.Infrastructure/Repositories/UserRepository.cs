using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FitBurger.Infrastructure.Repositories;

public sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(FitBurgerDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        return await Context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
    }
}