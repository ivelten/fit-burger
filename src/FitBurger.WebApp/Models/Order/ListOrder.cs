using System.ComponentModel.DataAnnotations;
using FitBurger.Core.Domain.Enums;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;

namespace FitBurger.WebApp.Models.Order;

[Plurality("Pedido", "Pedidos")]
public class ListOrder : IListModel, IOrderStatus
{
    [Ignore]
    public int Id { get; init; }
    
    [Ignore]
    public int CustomerId { get; init; }

    [Display(Name = "Cliente")] 
    public string CustomerName { get; init; } = default!;
    
    [Display(Name = "Motoboy")]
    public string? DeliverymanName { get; init; }
    
    [Display(Name = "Entregar?")]
    public bool ShouldDeliver { get; init; }
    
    [Display(Name = "Status")]
    public OrderStatus Status { get; set; }
}