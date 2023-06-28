using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Enums;

namespace FitBurger.Core.Domain.Entities;

public class Order : Entity
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