using FitBurger.WebApp.Models.Attendant;
using FitBurger.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace FitBurger.WebApp.Pages.Attendant;

public abstract class UpdateBase : ComponentBase
{
    [Inject]
    protected AttendantService AttendantService { get; set; } = default!;
    
    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

    [Parameter]
    public int Id { get; set; }
    
    protected UpdateAttendant? Model { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        Model = await AttendantService.GetAsync(Id);
    }

    protected async Task HandleValidSubmit()
    {
        if (Model is null)
            return;

        await AttendantService.UpdateAsync(Model);
        NavigationManager.NavigateTo("/attendant/list");
    }
}