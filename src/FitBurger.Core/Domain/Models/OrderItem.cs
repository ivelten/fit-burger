namespace FitBurger.Core.Domain.Models;

public class OrderItem
{
    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    protected OrderItem()
    {
    }

    public int Id { get; protected set; }

    public int Quantity { get; protected set; }
    
    public virtual Product Product { get; protected set; } = default!;

    public virtual Order Order { get; protected set; } = default!;
}