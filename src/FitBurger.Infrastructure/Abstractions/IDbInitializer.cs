namespace FitBurger.Infrastructure.Abstractions;

public interface IDbInitializer
{
    Task EnsureDeletedAsync();
    
    Task EnsureCreatedAsync();
}