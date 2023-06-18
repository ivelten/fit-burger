using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using FitBurger.Core.Domain.ValueObjects.Serialization.Converters;

namespace FitBurger.Core.Domain.ValueObjects;

[JsonConverter(typeof(EmailJsonConverter))]
public sealed partial class Email : IEquatable<Email>, IEquatable<string>
{
    private readonly string _value;

    private Email(string value)
    {
        _value = value;
    }

    public bool Equals(Email? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return _value == other._value;
    }

    public bool Equals(string? other)
    {
        return TryParse(other, out var otherEmail) && Equals(otherEmail);
    }

    public static bool IsValidEmailString(string? value)
    {
        return value is not null && Regex.IsMatch(value);
    }

    public static bool TryParse(string? value, out Email email)
    {
        if (IsValidEmailString(value))
        {
            email = new Email(value!);
            return true;
        }

        email = default!;
        return false;
    }

    public static Email Parse(string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        if (TryParse(value, out var email))
            return email;

        throw new FormatException();
    }

    public override string ToString()
    {
        return _value;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) ||
               (obj is Email otherEmail && Equals(otherEmail)) ||
               (obj is string other && Equals(other));
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public static bool operator ==(Email? left, Email? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Email? left, Email? right)
    {
        return !(left == right);
    }

    public static bool operator ==(Email? left, string? right)
    {
        if (left is null && right is null)
            return true;

        return TryParse(right, out var rightEmail) && rightEmail.Equals(left);
    }

    public static bool operator !=(Email? left, string? right)
    {
        return !(left == right);
    }

    public static bool operator ==(string? left, Email? right)
    {
        if (left is null && right is null)
            return true;

        return TryParse(left, out var leftEmail) && leftEmail.Equals(right);
    }

    public static bool operator !=(string? left, Email? right)
    {
        return !(left == right);
    }

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator string?(Email? value)
    {
        return value?.ToString();
    }

    #region Regex implementations

    private const string RegexPattern =
        @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";

    private static readonly Regex Regex = EmailRegex();

    [GeneratedRegex(RegexPattern, RegexOptions.Compiled)]
    private static partial Regex EmailRegex();

    #endregion
}