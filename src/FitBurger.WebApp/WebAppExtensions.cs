using FitBurger.WebApp.Models.Attendant;
using FitBurger.WebApp.Models.Customer;
using FitBurger.WebApp.Models.Deliveryman;
using FitBurger.WebApp.Models.Product;
using FitBurger.WebApp.Services;
using Microsoft.AspNetCore.Components.Authorization;

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
            .AddScoped<IListService<ListProduct>, ProductService>()
            .AddScoped<ICreateService<CreateAttendant>, AttendantService>()
            .AddScoped<ICreateService<CreateCustomer>, CustomerService>()
            .AddScoped<ICreateService<CreateDeliveryman>, DeliverymanService>()
            .AddScoped<ICreateService<CreateProduct>, ProductService>()
            .AddScoped<IUpdateService<UpdateAttendant>, AttendantService>()
            .AddScoped<IUpdateService<UpdateCustomer>, CustomerService>()
            .AddScoped<IUpdateService<UpdateDeliveryman>, DeliverymanService>()
            .AddScoped<IUpdateService<UpdateProduct>, ProductService>();

        services.AddScoped<CustomAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(serviceProvider =>
            serviceProvider.GetRequiredService<CustomAuthenticationStateProvider>());
    }
}