namespace FitBurger.Core.Domain.Entities;

public class Product
{
    public Product(string description, decimal price)
    {
        Description = description;
        Price = price;
    }

    protected Product()
    {
    }

    public int Id { get; protected set; }

    public string Description { get; protected set; } = default!;
    
    public decimal Price { get; protected set; }
}