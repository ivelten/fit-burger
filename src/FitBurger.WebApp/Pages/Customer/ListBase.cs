using FitBurger.WebApp.Models;
using FitBurger.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace FitBurger.WebApp.Pages.Customer;

public abstract class ListBase : ComponentBase
{
    [Inject]
    protected CustomerService CustomerService { get; set; } = default!;
    
    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

    protected ListCustomer[]? Model { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Model = await CustomerService.ListAsync();
    }
}