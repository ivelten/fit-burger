using FitBurger.WebApp.Models;
using FitBurger.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace FitBurger.WebApp.Pages.Customer;

public abstract class CreateBase : ComponentBase
{
    [Inject]
    protected CustomerService CustomerService { get; set; } = default!;
    
    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

    protected CreateCustomer Model { get; set; } = new();
    
    protected async Task HandleValidSubmit()
    {
        await CustomerService.Create(Model);
        NavigationManager.NavigateTo("/");
    }
}