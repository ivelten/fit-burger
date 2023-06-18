using FitBurger.Core.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitBurger.Infrastructure.ValueConverters;

public sealed class GenderConverter : ValueConverter<Gender, char>
{
    public GenderConverter()
        : base(
            gender => (char)(int)gender,
            gender => (Gender)gender)
    {
    }
}