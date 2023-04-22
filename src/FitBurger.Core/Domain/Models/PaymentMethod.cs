using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentMethod
{
    Cash,
    CreditCard,
    DebitCard,
    Pix
}