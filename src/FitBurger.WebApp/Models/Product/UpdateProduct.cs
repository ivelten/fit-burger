using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Attributes;

namespace FitBurger.WebApp.Models.Product;

[Plurality("Produto", "Produtos")]
public class UpdateProduct
{
    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "A descrição é requerida.")]
    [StringLength(256, ErrorMessage = "A descrição do produto não deve ultrapassar 256 caracteres.")]
    public string? Description { get; set; }

    [Display(Name = "Preço Unitário")]
    [Required(ErrorMessage = "O preço unitário é requerido.")]
    public decimal? Price { get; set; }
}