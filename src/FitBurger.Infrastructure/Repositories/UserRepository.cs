using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FitBurger.Infrastructure.Repositories;

public sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(IDbContextFactory<FitBurgerDbContext> contextFactory) : base(contextFactory)
    {
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        
        return await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
    }
}