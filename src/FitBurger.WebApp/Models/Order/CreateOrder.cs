using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using VxFormGenerator.Core;

namespace FitBurger.WebApp.Models.Order;

public class CreateOrder
{
    [VxIgnore]
    public int CustomerId { get; set; }
    
    [VxIgnore]
    public int? AttendantId { get; set; }
    
    [VxIgnore]
    public int? DeliverymanId { get; set; }
    
    [Display(Name = "Endereço de entrega")]
    [Required(ErrorMessage = "O endereço de entrega é requerido.")]
    [StringLength(200, ErrorMessage = "O endereço de entrega é muito longo. Deve ter 200 ou menos caracteres.")]
    public string? DeliveryAddress { get; set; }

    [VxIgnore]
    public ICollection<CreateOrderItem> Items { get; set; } = new Collection<CreateOrderItem>();

    [VxIgnore]
    public ICollection<CreateOrderPayment> Payments { get; set; } = new Collection<CreateOrderPayment>();
}