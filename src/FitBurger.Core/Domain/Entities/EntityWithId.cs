namespace FitBurger.Core.Domain.Entities;

public abstract class EntityWithId
{
    protected EntityWithId()
    {
    }

    public int Id { get; protected set; } = default!;
}