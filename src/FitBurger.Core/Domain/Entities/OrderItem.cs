namespace FitBurger.Core.Domain.Entities;

public class OrderItem : EntityWithId
{
    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    protected OrderItem()
    {
    }

    public int Quantity { get; protected set; }
    
    public virtual Product Product { get; protected set; } = default!;

    public virtual Order Order { get; protected set; } = default!;
}