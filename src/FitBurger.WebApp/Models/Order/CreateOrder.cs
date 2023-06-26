using System.Collections.ObjectModel;

namespace FitBurger.WebApp.Models.Order;

public class CreateOrder
{
    public int CustomerId { get; set; }
    
    public int? AttendantId { get; set; }
    
    public int? DeliverymanId { get; set; }

    public ICollection<CreateOrderItem> Items { get; set; } = new Collection<CreateOrderItem>();

    public ICollection<CreateOrderPayment> Payments { get; set; } = new Collection<CreateOrderPayment>();
}