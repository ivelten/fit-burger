namespace FitBurger.WebApp.Models.Abstractions;

public interface IProduct
{
    int? ProductId { get; set; }
    
    string? Description { get; set; }
}