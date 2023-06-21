namespace FitBurger.WebApp.Services;

public interface ICreateService<in TModel>
{
    Task CreateAsync(TModel request);
}