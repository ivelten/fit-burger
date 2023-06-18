namespace FitBurger.Core.Domain.Entities.Abstractions;

public abstract class Entity
{
    public int Id { get; protected set; } = default!;
}