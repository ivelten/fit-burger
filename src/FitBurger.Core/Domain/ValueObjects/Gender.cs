using System.Runtime.Serialization;

namespace FitBurger.Core.Domain.ValueObjects;

public enum Gender
{
    [EnumMember(Value = "M")]
    Male = 'M',
    
    [EnumMember(Value = "F")]
    Female = 'F'
}