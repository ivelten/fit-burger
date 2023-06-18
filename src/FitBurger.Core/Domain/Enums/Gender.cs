using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Male = 'M',
    Female = 'F'
}