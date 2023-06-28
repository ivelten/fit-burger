using System.ComponentModel.DataAnnotations;
using FitBurger.WebApp.Attributes;
using FitBurger.WebApp.Models.Abstractions;
using VxFormGenerator.Core;

namespace FitBurger.WebApp.Models.Product;

[Plurality("Produto", "Produtos")]
public class ListProduct : IListModel
{
    [VxIgnore]
    public int Id { get; init; }
    
    [Display(Name = "Descrição")]
    public string? Description { get; init; }

    [Display(Name = "Preço Unitário")]
    public decimal? Price { get; init; }
}