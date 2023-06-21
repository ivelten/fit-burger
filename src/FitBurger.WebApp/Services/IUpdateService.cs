namespace FitBurger.WebApp.Services;

public interface IUpdateService<TModel>
{
    Task<TModel?> GetAsync(int id);

    Task UpdateAsync(int id, TModel request);
}