namespace FitBurger.Core.Domain.Entities.Abstractions;

public abstract class EntityWithId
{
    public int Id { get; protected set; } = default!;
}