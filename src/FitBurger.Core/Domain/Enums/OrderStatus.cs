using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    [Display(Name = "Preparando")]
    Preparing,
    
    [Display(Name = "A caminho")]
    OnTheWay,
    
    [Display(Name = "Entregue")]
    Delivered,
    
    [Display(Name = "Cancelado")]
    Canceled
}