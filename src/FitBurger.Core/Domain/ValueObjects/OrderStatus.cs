using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.ValueObjects;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    Created,
    Preparing,
    OnTheWay,
    Delivered,
    Canceled
}