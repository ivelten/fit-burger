using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Models.Abstractions;
using VxFormGenerator.Core;

namespace FitBurger.WebApp.Models.Order;

public class CreateOrder : IShouldDeliver
{
    [VxIgnore]
    public int CustomerId { get; set; }
    
    [VxIgnore]
    public int? AttendantId { get; set; }
    
    [VxIgnore]
    public int? DeliverymanId { get; set; }
    
    [Display(Name = "Rua")]
    [Required(ErrorMessage = "A rua do endereço de entrega é requerida.")]
    [StringLength(70, ErrorMessage = "A rua do endereço de entrega é muito longo. Deve ter 70 ou menos caracteres.")]
    public string? Street { get; set; }
    
    [Display(Name = "Número")]
    [StringLength(10, ErrorMessage = "O número do endereço de entrega é muito longo. Deve ter 10 ou menos caracteres.")]
    public string? Number { get; set; }
    
    [Display(Name = "Bairro")]
    [Required(ErrorMessage = "O bairro do endereço de entrega é requerido.")]
    [StringLength(50, ErrorMessage = "O bairro do endereço de entrega é muito longo. Deve ter 50 ou menos caracteres.")]
    public string? District { get; set; }
    
    [Display(Name = "CEP")]
    [Required(ErrorMessage = "O CEP do endereço de entrega é requerido.")]
    [RegularExpression("[0-9]{2}.?[0-9]{3}-?[0-9]{3}", ErrorMessage = "O CEP está em formato inválido.")]
    public string? Cep { get; set; }
    
    [VxIgnore]
    public bool ShouldDeliver { get; set; } = true;

    [VxIgnore]
    public ICollection<CreateOrderItem>? Items { get; set; } = new Collection<CreateOrderItem>();

    [VxIgnore]
    public ICollection<CreateOrderPayment>? Payments { get; set; } = new Collection<CreateOrderPayment>();
}