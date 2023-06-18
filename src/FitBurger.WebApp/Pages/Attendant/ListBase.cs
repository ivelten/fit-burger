using FitBurger.WebApp.Models.Attendant;
using FitBurger.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace FitBurger.WebApp.Pages.Attendant;

public abstract class ListBase : ComponentBase
{
    [Inject] protected AttendantService AttendantService { get; set; } = default!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    protected ListAttendant[]? Model { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Model = await AttendantService.ListAsync();
    }
}