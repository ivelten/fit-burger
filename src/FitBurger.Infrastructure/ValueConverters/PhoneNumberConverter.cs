using FitBurger.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitBurger.Infrastructure.ValueConverters;

public sealed class PhoneNumberConverter : ValueConverter<PhoneNumber, string>
{
    public PhoneNumberConverter()
        : base(
            number => number.ToString(PhoneNumberFormatOptions.None),
            number => PhoneNumber.Parse(number))
    {
    }
}