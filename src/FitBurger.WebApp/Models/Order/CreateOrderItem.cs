using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;
using VxFormGenerator.Core;

namespace FitBurger.WebApp.Models.Order;

[Plurality("Item de Pedido", "Itens de Pedido")]
public class CreateOrderItem : IProduct
{
    [VxIgnore, Ignore]
    [Display(Name = "Id")]
    [Required(ErrorMessage = "O Id é requerido")]
    public int? ProductId { get; set; }
    
    [VxIgnore]
    [Display(Name = "Descrição")]
    public string? Description { get; set; }

    [Display(Name = "Quantidade")]
    [Required(ErrorMessage = "A quantidade é requerida.")]
    [Range(1, 5, ErrorMessage = "A quantidade deve ser entre 1 e 5.")]
    public int? Quantity { get; set; }
}