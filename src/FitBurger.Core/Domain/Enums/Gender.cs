using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitBurger.Core.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    [Display(Name = "Masculino")]
    Male = 'M',
    
    [Display(Name = "Feminino")]
    Female = 'F'
}