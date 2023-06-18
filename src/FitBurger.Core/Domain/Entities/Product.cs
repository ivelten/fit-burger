using FitBurger.Core.Domain.Entities.Abstractions;

namespace FitBurger.Core.Domain.Entities;

public class Product : Entity
{
    public Product(string description, decimal price)
    {
        Description = description;
        Price = price;
    }

    protected Product()
    {
    }

    public string Description { get; protected set; } = default!;

    public decimal Price { get; protected set; }
}