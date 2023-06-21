using System.ComponentModel.DataAnnotations;

namespace FitBurger.WebApp.Models.Order;

public class CreateOrderItem
{
    [Display(Name = "Produto")]
    [Required(ErrorMessage = "O produto é requerido.")]
    public int? ProductId { get; set; }
    
    [Display(Name = "Quantidade")]
    [Required(ErrorMessage = "A quantidade é requerida.")]
    [Range(1, 5, ErrorMessage = "A quantidade deve ser entre 1 e 5.")]
    public int? Quantity { get; set; }
}