using System.Collections.ObjectModel;

namespace FitBurger.Core.Domain.Models;

public class Order
{
    public Order(
        string deliveryAddress,
        OrderStatus status = OrderStatus.Created,
        TimeSpan? deliveryTime = null,
        string? receiverName = null)
    {
        DeliveryAddress = deliveryAddress;
        Status = status;
        DeliveryTime = deliveryTime;
        ReceiverName = receiverName;
        Items = new Collection<OrderItem>();
        Payments = new Collection<OrderPayment>();
    }

    protected Order()
    {
    }

    public int Id { get; protected set; }

    public string DeliveryAddress { get; protected set; } = default!;
    
    public OrderStatus Status { get; protected set; }
    
    public TimeSpan? DeliveryTime { get; protected set; }
    
    public string? ReceiverName { get; protected set; }
    
    public virtual Customer Customer { get; protected set; } = default!;
    
    public virtual Attendant? Attendant { get; protected set; }
    
    public virtual Deliveryman? Deliveryman { get; protected set; }

    public virtual ICollection<OrderItem> Items { get; protected set; } = default!;

    public virtual ICollection<OrderPayment> Payments { get; protected set; } = default!;
}