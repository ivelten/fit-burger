namespace FitBurger.Core.Domain;

[Flags]
public enum PhoneNumberFormatOptions
{
    None = 0,
    AreaCodeParenthesis = 1,
    AreaCodeSpacing = 2,
    NumberSeparator = 4,
    All = 7
}