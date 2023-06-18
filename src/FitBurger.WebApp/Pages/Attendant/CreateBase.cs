using FitBurger.WebApp.Models.Attendant;
using FitBurger.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace FitBurger.WebApp.Pages.Attendant;

public abstract class CreateBase : ComponentBase
{
    [Inject] protected AttendantService AttendantService { get; set; } = default!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    protected CreateAttendant Model { get; set; } = new();

    protected async Task HandleValidSubmit()
    {
        await AttendantService.CreateAsync(Model);
        NavigationManager.NavigateTo("/attendant/list");
    }
}