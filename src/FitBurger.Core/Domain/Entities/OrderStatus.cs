using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    Created,
    Preparing,
    OnTheWay,
    Delivered,
    Canceled
}