using FitBurger.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitBurger.Infrastructure.ValueConverters;

public sealed class CpfConverter : ValueConverter<Cpf, string>
{
    public CpfConverter()
        : base(
            cpf => cpf.ToString(CpfFormatOptions.None),
            cpf => Cpf.Parse(cpf))
    {
    }
}