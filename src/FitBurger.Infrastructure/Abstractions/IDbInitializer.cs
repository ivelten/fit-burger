namespace FitBurger.Infrastructure.Abstractions;

public interface IDbInitializer
{
    Task EnsureDeletedAsync(CancellationToken cancellationToken = default);

    Task EnsureCreatedAsync(CancellationToken cancellationToken = default);
}