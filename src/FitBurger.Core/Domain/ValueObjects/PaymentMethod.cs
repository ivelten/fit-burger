using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.ValueObjects;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentMethod
{
    Cash,
    CreditCard,
    DebitCard,
    Pix
}