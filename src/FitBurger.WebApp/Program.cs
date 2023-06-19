using System.Globalization;
using FitBurger.Infrastructure;
using FitBurger.Infrastructure.Abstractions;
using FitBurger.WebApp;
using VxFormGenerator.Settings.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddVxFormGenerator();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

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

var culture = CultureInfo.GetCultureInfo("pt-BR");

CultureInfo.CurrentCulture = culture;
CultureInfo.CurrentUICulture = culture;

app.Run();