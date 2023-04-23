using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitBurger.Infrastructure.ValueConverters;

public sealed class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter()
        : base(
            date => date.ToDateTime(new TimeOnly()),
            date => DateOnly.FromDateTime(date))
    {
    }
}