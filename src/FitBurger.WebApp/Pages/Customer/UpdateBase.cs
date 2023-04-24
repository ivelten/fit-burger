using FitBurger.WebApp.Models;
using FitBurger.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace FitBurger.WebApp.Pages.Customer;

public abstract class UpdateBase : ComponentBase
{
    [Inject]
    protected CustomerService CustomerService { get; set; } = default!;
    
    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

    [Parameter]
    public int Id { get; set; }
    
    protected UpdateCustomer? Model { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        Model = await CustomerService.GetAsync(Id);
    }

    protected async Task HandleValidSubmit()
    {
        if (Model is null)
            return;

        await CustomerService.UpdateAsync(Model);
        NavigationManager.NavigateTo("/customer/list");
    }
}