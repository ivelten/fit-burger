using EntityFramework.Exceptions.SqlServer;
using FitBurger.Core.Domain.Abstractions;
using FitBurger.Core.Domain.Repositories.Abstractions;
using FitBurger.Infrastructure.Abstractions;
using FitBurger.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitBurger.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");

        services.AddDbContextFactory<FitBurgerDbContext>(dbOptions =>
        {
            dbOptions.UseSqlServer(connectionString, connectionOptions =>
            {
                connectionOptions
                    .MigrationsAssembly(AssemblyMarker.Assembly.FullName)
                    .MigrationsHistoryTable("MigrationHistory")
                    .EnableRetryOnFailure();
            });

            dbOptions.UseExceptionProcessor();
            dbOptions.UseLazyLoadingProxies();
        });

        services.AddScoped<IDbInitializer, DbInitializer>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<FitBurgerDbContext>());

        return services;
    }
}