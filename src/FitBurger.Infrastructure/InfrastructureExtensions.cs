using EntityFramework.Exceptions.SqlServer;
using FitBurger.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitBurger.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");
        
        services.AddDbContext<FitBurgerDbContext>(dbOptions =>
        {
            dbOptions.UseSqlServer(connectionString, connectionOptions =>
            {
                connectionOptions
                    .MigrationsAssembly(AssemblyMarker.Assembly.FullName)
                    .MigrationsHistoryTable("MigrationHistory")
                    .EnableRetryOnFailure();
            });

            dbOptions.UseExceptionProcessor();
        });

        services.AddScoped<IDbInitializer, DbInitializer>();

        return services;
    }
}