using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Entities.Abstractions;
using FitBurger.Core.Domain.Enums;

namespace FitBurger.Core.Domain.Entities;

[Display(Name = "Pedido")]
public class Order : Entity
{
    public Order(
        string street,
        string number,
        string district,
        string cep,
        bool shouldDelivery,
        OrderStatus status = OrderStatus.Preparing,
        TimeSpan? deliveryTime = null,
        string? receiverName = null)
    {
        Street = street;
        Number = number;
        District = district;
        Cep = cep;
        ShouldDelivery = shouldDelivery;
        Status = status;
        DeliveryTime = deliveryTime;
        ReceiverName = receiverName;
        Items = new Collection<OrderItem>();
        Payments = new Collection<OrderPayment>();
    }

    protected Order()
    {
    }

    public string Street { get; protected set; } = default!;
    public string Number { get; protected set; } = default!;
    public string District { get; protected set; } = default!;
    public string Cep { get; protected set; } = default!;

    public OrderStatus Status { get; protected set; }

    public TimeSpan? DeliveryTime { get; protected set; }

    public bool ShouldDelivery { get; protected set; }
    
    public string? ReceiverName { get; protected set; }

    public virtual Customer Customer { get; protected set; } = default!;
    
    public virtual Attendant? Attendant { get; protected set; }
    
    public virtual Deliveryman? Deliveryman { get; protected set; }

    public virtual ICollection<OrderItem> Items { get; protected set; } = default!;

    public virtual ICollection<OrderPayment> Payments { get; protected set; } = default!;

    public void SetStatus(OrderStatus status)
    {
        Status = status;
    }
}