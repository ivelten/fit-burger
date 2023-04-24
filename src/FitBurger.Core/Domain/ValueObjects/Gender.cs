using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.ValueObjects;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Male = 'M',
    Female = 'F'
}