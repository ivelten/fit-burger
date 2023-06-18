namespace FitBurger.Core.Domain.ValueObjects.Options;

[Flags]
public enum CpfFormatOptions
{
    None = 0,
    NumberSeparators = 1,
    VerifyingDigitHyphen = 2,
    All = 3
}