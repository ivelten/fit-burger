using FitBurger.WebApp.Models.Attendant;
using FitBurger.WebApp.Models.Customer;
using FitBurger.WebApp.Models.Deliveryman;
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
            .AddScoped<IListService<ListCustomer>, CustomerService>()
            .AddScoped<IListService<ListDeliveryman>, DeliverymanService>()
            .AddScoped<ICreateService<CreateAttendant>, AttendantService>()
            .AddScoped<ICreateService<CreateCustomer>, CustomerService>()
            .AddScoped<ICreateService<CreateDeliveryman>, DeliverymanService>()
            .AddScoped<IUpdateService<UpdateAttendant>, AttendantService>()
            .AddScoped<IUpdateService<UpdateCustomer>, CustomerService>()
            .AddScoped<IUpdateService<UpdateDeliveryman>, DeliverymanService>();
    }
}