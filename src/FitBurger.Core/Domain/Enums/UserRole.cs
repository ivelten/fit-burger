using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRole : byte
{
    Administrator,
    Attendant,
    Deliveryman,
    Customer
}