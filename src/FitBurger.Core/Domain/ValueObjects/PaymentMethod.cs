using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.ValueObjects;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentMethod : byte
{
    [Display(Name = "Espécie")]
    Cash,
    
    [Display(Name = "Cartão de Crédito")]
    CreditCard,
    
    [Display(Name = "Cartão de Débito")]
    DebitCard,
    
    [Display(Name = "Pix")]
    Pix
}