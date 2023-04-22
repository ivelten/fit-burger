using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using FitBurger.Core.Domain.Serialization.Converters;

namespace FitBurger.Core.Domain;

[JsonConverter(typeof(CpfConverter))]
public sealed partial class Cpf : IEquatable<Cpf>, IEquatable<string>
{
    private readonly string _value;

    private Cpf(string value)
    {
        _value = value;
    }

    public static bool IsValidCpfString(string? value)
    {
        if (value is null)
            return false;

        if (!FormattedRegex.IsMatch(value) && !Regex.IsMatch(value))
            return false;

        var trimmedValue = Trim(value);

        var expectedDigit = trimmedValue[9..11];
        var actualDigit = GetVerifyingDigit(trimmedValue);

        return actualDigit == expectedDigit;
    }
    
    private static string GetVerifyingDigit(string trimmedValue)
    {
        var temp = trimmedValue[..9];
        var multiplier1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var sum = 0;

        for (var i = 0; i < 9; i++)
            sum += (int)char.GetNumericValue(temp[i]) * multiplier1[i];

        var mod = GetVerifyingDigitMod(sum);

        var digit = mod.ToString();
        
        temp += digit;
        
        var multiplier2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        sum = 0;
        
        for (var i = 0; i < 10; i++)
            sum += (int)char.GetNumericValue(temp[i]) * multiplier2[i];

        mod = GetVerifyingDigitMod(sum);
        digit += mod.ToString();

        return digit;
    }
    
    private static int GetVerifyingDigitMod(int sum)
    {
        var mod = sum % 11;
        return mod < 2 ? 0 : 11 - mod;
    }

    private static string Trim(string validValue)
    {
        return validValue.Contains('.')
            ? validValue.Replace(".", "").Replace("-", "")
            : validValue;
    }

    public static bool TryParse(string? value, out Cpf cpf)
    {
        if (IsValidCpfString(value))
        {
            cpf = new Cpf(Trim(value!));
            return true;
        }

        cpf = default!;
        return false;
    }

    public static Cpf Parse(string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        
        if (TryParse(value, out var cpf))
            return cpf;

        throw new FormatException();
    }

    public string ToString(CpfFormatOptions options)
    {
        var ns = options.HasFlag(CpfFormatOptions.NumberSeparators) ? "." : "";
        var dh = options.HasFlag(CpfFormatOptions.VerifyingDigitHyphen) ? "-" : "";
        
        return $"{_value[..3]}{ns}{_value[3..6]}{ns}{_value[6..9]}{dh}{_value[9..11]}";
    }

    public override string ToString()
    {
        return ToString(CpfFormatOptions.All);
    }

    public bool Equals(Cpf? other)
    {
        return _value == other?._value;
    }

    public bool Equals(string? other)
    {
        return TryParse(other, out var otherCpf) && Equals(otherCpf);
    }

    public override bool Equals(object? obj)
    {
        return obj switch
        {
            Cpf cpf => Equals(cpf),
            string str => Equals(str),
            _ => false
        };
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public static bool operator ==(Cpf? left, Cpf? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Cpf? left, Cpf? right)
    {
        return !(left == right);
    }

    public static bool operator ==(Cpf? left, string? right)
    {
        if (left is null && right is null)
            return true;
        
        return TryParse(right, out var rightCpf) && rightCpf.Equals(left);
    }

    public static bool operator !=(Cpf? left, string? right)
    {
        return !(left == right);
    }

    public static bool operator ==(string? left, Cpf? right)
    {
        if (left is null && right is null)
            return true;
        
        return TryParse(left, out var leftCpf) && leftCpf.Equals(right);
    }

    public static bool operator !=(string? left, Cpf? right)
    {
        return !(left == right);
    }

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator string?(Cpf? value)
    {
        return value?.ToString();
    }
    
    #region Regex implementations

    private const string FormattedRegexPattern = @"[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}";
    private const string RegexPattern = @"[0-9]{11}";
    
    private static readonly Regex FormattedRegex = FormattedCpfRegex();
    private static readonly Regex Regex = CpfRegex();
    
    [GeneratedRegex(FormattedRegexPattern, RegexOptions.Compiled)]
    private static partial Regex FormattedCpfRegex();

    [GeneratedRegex(RegexPattern, RegexOptions.Compiled)]
    private static partial Regex CpfRegex();

    #endregion
}