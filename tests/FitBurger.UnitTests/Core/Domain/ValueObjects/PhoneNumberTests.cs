using System.Text.Json;
using FitBurger.Core.Domain.ValueObjects;
using FitBurger.Core.Domain.ValueObjects.Options;
using FluentAssertions;

namespace FitBurger.UnitTests.Core.Domain.ValueObjects;

public sealed class PhoneNumberTests
{
    public static readonly object[] ValidInputs =
    {
        "6983997803",
        "(69)8399-7803",
        "(69) 8399-7803",
        "44924075993",
        "(44)92407-5993",
        "(44) 92407-5993"
    };

    public static readonly object?[] InvalidInputs =
    {
        null,
        "12345678901",
        ".Y_'zZ<WtFA2&hp",
        "69583997803",
        "(23)58399-7803",
        "(39) 58399-7803",
        "52604075993",
        "(72)60407-5993"
    };

    [Test(Description = "Input strings should be valid")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Input_Strings_Should_Be_Valid(string input)
    {
        PhoneNumber.IsValidPhoneNumberString(input).Should().BeTrue();
    }

    [Test(Description = "TryParse should parse valid input")]
    [TestCaseSource(nameof(ValidInputs))]
    public void TryParse_Should_Parse_Valid_Input(string input)
    {
        var success = PhoneNumber.TryParse(input, out var phoneNumber);

        var expectedPhoneNumberValue =
            input.Contains('(')
                ? phoneNumber.ToString()
                : phoneNumber.ToString(PhoneNumberFormatOptions.None);

        success.Should().BeTrue();
        expectedPhoneNumberValue.Replace(" ", "").Should().Be(input.Replace(" ", ""));
    }

    [Test(Description = "Parse should parse valid input")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Parse_Should_Parse_Valid_Input(string input)
    {
        var phoneNumber = PhoneNumber.Parse(input);

        var expectedPhoneNumberValue =
            input.Contains('(')
                ? phoneNumber.ToString()
                : phoneNumber.ToString(PhoneNumberFormatOptions.None);

        expectedPhoneNumberValue.Replace(" ", "").Should().Be(input.Replace(" ", ""));
    }

    [Test(Description = "Input strings should be invalid")]
    [TestCaseSource(nameof(InvalidInputs))]
    public void Input_Strings_Should_Be_Invalid(string? input)
    {
        PhoneNumber.IsValidPhoneNumberString(input).Should().BeFalse();
    }

    [Test(Description = "TryParse should not parse invalid input")]
    [TestCaseSource(nameof(InvalidInputs))]
    public void TryParse_Should_Not_Parse_Invalid_Input(string input)
    {
        var success = PhoneNumber.TryParse(input, out var phoneNumber);

        success.Should().BeFalse();
        phoneNumber.Should().BeNull();
    }

    [Test(Description = "Parse should not parse invalid input")]
    [TestCaseSource(nameof(InvalidInputs))]
    public void Parse_Should_Not_Parse_Invalid_Input(string? input)
    {
        Action act = () => PhoneNumber.Parse(input!);

        if (input is null)
            act.Should().Throw<ArgumentNullException>();
        else
            act.Should().Throw<FormatException>();
    }

    [Test(Description = "Equals to PhoneNumber should return true when other PhoneNumber has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equals_To_PhoneNumber_Should_Return_True_When_Other_PhoneNumber_Has_Same_Value(string input)
    {
        var phoneNumber1 = PhoneNumber.Parse(input);
        var phoneNumber2 = PhoneNumber.Parse(input);

        phoneNumber1.Equals(phoneNumber2).Should().BeTrue();
    }

    [Test(Description =
        "Equality operators to PhoneNumber should return true when other PhoneNumber has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equality_Operators_To_PhoneNumber_Should_Return_True_When_Other_PhoneNumber_Has_Same_Value(string input)
    {
        var phoneNumber1 = PhoneNumber.Parse(input);
        var phoneNumber2 = PhoneNumber.Parse(input);

        (phoneNumber1 == phoneNumber2).Should().BeTrue();
        (phoneNumber1 != phoneNumber2).Should().BeFalse();
    }

    [Test(Description = "Equals to string should return true when other PhoneNumber has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equals_To_String_Should_Return_True_When_Other_PhoneNumber_Has_Same_Value(string input)
    {
        var phoneNumber = PhoneNumber.Parse(input);

        phoneNumber.Equals(input).Should().BeTrue();
    }

    [Test(Description =
        "Equality operators to PhoneNumber should return true when other PhoneNumber has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equality_Operators_To_String_Should_Return_True_When_Other_PhoneNumber_Has_Same_Value(string input)
    {
        var phoneNumber = PhoneNumber.Parse(input);

        (phoneNumber == input).Should().BeTrue();
        (phoneNumber != input).Should().BeFalse();
        (input == phoneNumber).Should().BeTrue();
        (input != phoneNumber).Should().BeFalse();
    }

    [Test(Description = "Implicit conversion to string should work")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Implicit_Conversion_To_String_Should_Work(string input)
    {
        var phoneNumber = PhoneNumber.Parse(input);
        string stringPhoneNumber = phoneNumber;

        stringPhoneNumber.Should().Be(phoneNumber.ToString());
    }

    [Test(Description = "Equals to PhoneNumber edge cases should work")]
    [TestCase("(69) 8399-7803", null, false)]
    [TestCase("(69) 8399-7803", "(44) 92407-5993", false)]
    public void Equals_To_PhoneNumber_Edge_Cases_Should_Work(string input1, string? input2, bool equals)
    {
        var phoneNumber1 = PhoneNumber.Parse(input1);
        var phoneNumber2 = input2 is not null ? PhoneNumber.Parse(input2) : null;

        phoneNumber1.Equals(phoneNumber2).Should().Be(equals);
    }

    [Test(Description = "Equality operators to PhoneNumber edge cases should work")]
    [TestCase(null, null, true)]
    [TestCase(null, "(69) 8399-7803", false)]
    [TestCase("(69) 8399-7803", null, false)]
    [TestCase("(69) 8399-7803", "(44) 92407-5993", false)]
    public void Equality_Operators_To_PhoneNumber_Edge_Cases_Should_Work(string? input1, string? input2, bool equals)
    {
        var phoneNumber1 = input1 is not null ? PhoneNumber.Parse(input1) : null;
        var phoneNumber2 = input2 is not null ? PhoneNumber.Parse(input2) : null;

        (phoneNumber1 == phoneNumber2).Should().Be(equals);
    }

    [Test(Description = "Equals to string edge cases should work")]
    [TestCase("(69) 8399-7803", null, false)]
    [TestCase("(69) 8399-7803", "(44) 92407-5993", false)]
    public void Equals_To_String_Edge_Cases_Should_Work(string input1, string? input2, bool equals)
    {
        var phoneNumber = PhoneNumber.Parse(input1);

        phoneNumber.Equals(input2).Should().Be(equals);
    }

    [Test(Description = "Equality operators to string edge cases should work")]
    [TestCase(null, null, true)]
    [TestCase(null, "(69) 8399-7803", false)]
    [TestCase("(69) 8399-7803", null, false)]
    [TestCase("(69) 8399-7803", "(44) 92407-5993", false)]
    public void Equality_Operators_To_String_Edge_Cases_Should_Work(string? input1, string? input2, bool equals)
    {
        var phoneNumber = input1 is not null ? PhoneNumber.Parse(input1) : null;

        (phoneNumber == input2).Should().Be(equals);
        (input2 == phoneNumber).Should().Be(equals);
    }

    [Test(Description = "Should be able to serialize to JSON")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Should_Be_Able_To_Serialize_To_Json(string input)
    {
        var phoneNumber = PhoneNumber.Parse(input);
        var expected = $"\"{phoneNumber}\"";
        var actual = JsonSerializer.Serialize(phoneNumber);

        actual.Should().Be(expected);
    }

    [Test(Description = "Should be able to deserialize from JSON")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Should_Be_Able_To_Deserialize_From_Json(string input)
    {
        var expected = PhoneNumber.Parse(input);
        var json = $"\"{expected}\"";
        var actual = JsonSerializer.Deserialize<PhoneNumber>(json);

        actual.Should().Be(expected);
    }
}