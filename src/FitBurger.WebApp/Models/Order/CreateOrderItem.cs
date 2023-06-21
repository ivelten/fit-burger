using System.ComponentModel.DataAnnotations;

namespace FitBurger.WebApp.Models.Order;

public class CreateOrderItem
{
    [Display(Name = "Id")]
    public int ProductId { get; set; }
    
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O nome é requerido")]
    public string? ProductName { get; set; }
    
    [Display(Name = "Quantidade")]
    [Required(ErrorMessage = "A quantidade é requerida.")]
    [Range(1, 5, ErrorMessage = "A quantidade deve ser entre 1 e 5.")]
    public int? Quantity { get; set; }
}