using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.ValueObjects;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentMethod : byte
{
    Cash,
    CreditCard,
    DebitCard,
    Pix
}