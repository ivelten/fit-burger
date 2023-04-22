using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitBurger.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");
        
        return services.AddDbContext<FitBurgerDbContext>(dbOptions =>
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
    }
}