using FitBurger.WebApp.Services;

namespace FitBurger.WebApp;

public static class WebAppExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .AddScoped<CustomerService>()
            .AddScoped<AttendantService>();
    }
}