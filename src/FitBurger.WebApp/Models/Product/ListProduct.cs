using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;

namespace FitBurger.WebApp.Models.Product;

[Plurality("Produto", "Produtos")]
public class ListProduct : IListModel
{
    public int Id { get; init; }
    
    [Display(Name = "Descrição")]
    public string? Description { get; init; } = default!;

    [Display(Name = "Preço Unitário")]
    public decimal? Price { get; init; }
}