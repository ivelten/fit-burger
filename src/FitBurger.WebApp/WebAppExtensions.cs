using FitBurger.WebApp.Models.Attendant;
using FitBurger.WebApp.Models.Customer;
using FitBurger.WebApp.Services;

namespace FitBurger.WebApp;

public static class WebAppExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped<CustomerService>()
            .AddScoped<AttendantService>()
            .AddScoped<IListService<ListAttendant>, AttendantService>()
            .AddScoped<IListService<ListCustomer>, CustomerService>();
    }
}