namespace FitBurger.Core.Domain.Entities;

public class Product
{
    public Product(string description, decimal value)
    {
        Description = description;
        Value = value;
    }

    protected Product()
    {
    }

    public int Id { get; protected set; }

    public string Description { get; protected set; } = default!;
    
    public decimal Value { get; protected set; }
}