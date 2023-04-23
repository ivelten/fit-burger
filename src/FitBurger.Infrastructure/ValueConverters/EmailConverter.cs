using FitBurger.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitBurger.Infrastructure.ValueConverters;

public sealed class EmailConverter : ValueConverter<Email, string>
{
    public EmailConverter()
        : base(
            email => email.ToString(),
            email => Email.Parse(email))
    {
    }
}