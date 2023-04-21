using System.Diagnostics.CodeAnalysis;

namespace FitBurger.Core.Domain;

public sealed class Cpf : IEquatable<Cpf>, IEquatable<string>
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

        if (value.Length != 11 && value.Length != 14)
            return false;

        if (value.Length == 14 && (value[3] != '.' || value[7] != '.' || value[11] != '-'))
            return false;

        var trimmedValue = Trim(value);

        if (!trimmedValue.All(char.IsDigit))
            return false;

        var expectedDigit = trimmedValue[9..11];
        var actualDigit = GetDigit(trimmedValue);

        return actualDigit == expectedDigit;
    }
    
    private static string GetDigit(string trimmedValue)
    {
        var temp = trimmedValue[..9];
        var multiplier1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var sum = 0;

        for (var i = 0; i < 9; i++)
            sum += (int)char.GetNumericValue(temp[i]) * multiplier1[i];

        var mod = GetMod(sum);

        var digit = mod.ToString();
        
        temp += digit;
        
        var multiplier2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        sum = 0;
        
        for (var i = 0; i < 10; i++)
            sum += (int)char.GetNumericValue(temp[i]) * multiplier2[i];

        mod = GetMod(sum);
        digit += mod.ToString();

        return digit;
    }

    private static string Trim(string value)
    {
        return value.Length == 14
            ? value.Trim().Replace(".", "").Replace("-", "")
            : value;
    }

    private static int GetMod(int sum)
    {
        var mod = sum % 11;
        
        return mod < 2 ? 0 : 11 - mod;
    }

    public static bool TryParse(string? value, out Cpf cpf)
    {
        if (IsValidCpfString(value))
        {
            var trimmedValue = Trim(value!);
            
            cpf = new Cpf(trimmedValue);
            
            return true;
        }

        cpf = default!;
        
        return false;
    }

    public static Cpf Parse(string value)
    {
        if (TryParse(value, out var cpf))
            return cpf;

        throw new FormatException();
    }

    public string ToString(CpfFormatOptions options)
    {
        var s = options.HasFlag(CpfFormatOptions.NumberSeparators) ? "." : "";
        var h = options.HasFlag(CpfFormatOptions.VerifyingDigitHyphen) ? "-" : "";
        
        return $"{_value[..3]}{s}{_value[3..6]}{s}{_value[6..9]}{h}{_value[9..11]}";
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
        if (other is null)
            return false;

        return other.Length switch
        {
            11 => ToString(CpfFormatOptions.None) == other,
            14 => ToString(CpfFormatOptions.All) == other,
            _ => false
        };
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
}