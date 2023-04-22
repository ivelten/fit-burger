using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    Created,
    Preparing,
    OnTheWay,
    Delivered,
    Canceled
}