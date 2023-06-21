namespace FitBurger.WebApp.Services;

public interface IListService<TModel>
{
    Task<TModel[]> ListAsync(string? queryValue = null);
}