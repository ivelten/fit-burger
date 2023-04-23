using FitBurger.Infrastructure;
using FitBurger.Infrastructure.Abstractions;
using FitBurger.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}
else
{
    var serviceScope = app.Services.CreateScope();
    var dbInitializer = serviceScope.ServiceProvider.GetRequiredService<IDbInitializer>();

    await dbInitializer.EnsureDeletedAsync();
    await dbInitializer.EnsureCreatedAsync();
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();