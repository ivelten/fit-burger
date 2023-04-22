using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using FitBurger.Core.Domain.ValueObjects.Serialization.Converters;

namespace FitBurger.Core.Domain.ValueObjects;

[JsonConverter(typeof(PhoneNumberConverter))]
public sealed partial class PhoneNumber : IEquatable<PhoneNumber>, IEquatable<string>
{
    private readonly string _value;

    private PhoneNumber(string value)
    {
        _value = value;
    }

    public static bool IsValidPhoneNumberString(string? value)
    {
        if (value is null)
            return false;

        return FormattedRegex.IsMatch(value) || Regex.IsMatch(value);
    }

    private static string Trim(string validValue)
    {
        return validValue.Contains('(')
            ? validValue.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "")
            : validValue;
    }
    
    public static bool TryParse(string? value, out PhoneNumber phoneNumber)
    {
        if (IsValidPhoneNumberString(value))
        {
            phoneNumber = new PhoneNumber(Trim(value!));
            return true;
        }

        phoneNumber = default!;
        return false;
    }

    public static PhoneNumber Parse(string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        
        if (TryParse(value, out var phoneNumber))
            return phoneNumber;

        throw new FormatException();
    }

    public string ToString(PhoneNumberFormatOptions options)
    {
        var op = options.HasFlag(PhoneNumberFormatOptions.AreaCodeParenthesis) ? "(" : "";
        var cp = options.HasFlag(PhoneNumberFormatOptions.AreaCodeParenthesis) ? ")" : "";
        var sp = options.HasFlag(PhoneNumberFormatOptions.AreaCodeSpacing) ? " " : "";
        var hp = options.HasFlag(PhoneNumberFormatOptions.NumberSeparator) ? "-" : "";

        return _value.Length == 10 
            ? $"{op}{_value[..2]}{cp}{sp}{_value[2..6]}{hp}{_value[6..10]}"
            : $"{op}{_value[..2]}{cp}{sp}{_value[2..7]}{hp}{_value[7..11]}";
    }

    public override string ToString()
    {
        return ToString(PhoneNumberFormatOptions.All);
    }

    public bool Equals(PhoneNumber? other)
    {
        if (other is null)
            return false;
        
        if (ReferenceEquals(this, other))
            return true;
        
        return _value == other._value;
    }

    public bool Equals(string? other)
    {
        return TryParse(other, out var otherNumber) && Equals(otherNumber);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || 
               (obj is PhoneNumber otherNumber && Equals(otherNumber)) ||
               (obj is string other && Equals(other));
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
    
    public static bool operator ==(PhoneNumber? left, PhoneNumber? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(PhoneNumber? left, PhoneNumber? right)
    {
        return !(left == right);
    }
    
    public static bool operator ==(PhoneNumber? left, string? right)
    {
        if (left is null && right is null)
            return true;
        
        return TryParse(right, out var rightNumber) && rightNumber.Equals(left);
    }

    public static bool operator !=(PhoneNumber? left, string? right)
    {
        return !(left == right);
    }

    public static bool operator ==(string? left, PhoneNumber? right)
    {
        if (left is null && right is null)
            return true;
        
        return TryParse(left, out var leftNumber) && leftNumber.Equals(right);
    }

    public static bool operator !=(string? left, PhoneNumber? right)
    {
        return !(left == right);
    }
    
    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator string?(PhoneNumber? value)
    {
        return value?.ToString();
    }
    
    # region Regex implementations
    
    private const string FormattedRegexPattern =
        @"^\((?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)\s*(?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$";

    private const string RegexPattern =
        @"^(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])(?:[2-8]|9[1-9])[0-9]{3}[0-9]{4}$";
    
    private static readonly Regex FormattedRegex = FormattedPhoneRegex();
    private static readonly Regex Regex = PhoneRegex();
    
    [GeneratedRegex(FormattedRegexPattern, RegexOptions.Compiled)]
    private static partial Regex FormattedPhoneRegex();

    [GeneratedRegex(RegexPattern, RegexOptions.Compiled)]
    private static partial Regex PhoneRegex();
    
    #endregion
}