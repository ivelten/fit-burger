using System.Text.Json;
using FitBurger.Core.Domain.ValueObjects;
using FluentAssertions;

namespace FitBurger.UnitTests.Core.Domain.ValueObjects;

public sealed class EmailTests
{
    public static readonly object[] ValidInputs =
    {
        "test123@host.com",
        "john@testhost.com.it",
        "hello@192.168.0.1"
    };

    public static readonly object?[] InvalidInputs =
    {
        null,
        "12345678901",
        ".Y_'zZ<WtFA2&hp",
        "test123@Host.com",
        "hello@uibakery.io."
    };

    [Test(Description = "Input strings should be valid")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Input_Strings_Should_Be_Valid(string input)
    {
        Email.IsValidEmailString(input).Should().BeTrue();
    }

    [Test(Description = "TryParse should parse valid input")]
    [TestCaseSource(nameof(ValidInputs))]
    public void TryParse_Should_Parse_Valid_Input(string input)
    {
        var success = Email.TryParse(input, out var email);

        var expectedEmailValue = email.ToString();

        success.Should().BeTrue();
        expectedEmailValue.Should().Be(input);
    }

    [Test(Description = "Parse should parse valid input")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Parse_Should_Parse_Valid_Input(string input)
    {
        var email = Email.Parse(input);

        var expectedEmailValue = email.ToString();

        expectedEmailValue.Should().Be(input);
    }

    [Test(Description = "Input strings should be invalid")]
    [TestCaseSource(nameof(InvalidInputs))]
    public void Input_Strings_Should_Be_Invalid(string? input)
    {
        Email.IsValidEmailString(input).Should().BeFalse();
    }

    [Test(Description = "TryParse should not parse invalid input")]
    [TestCaseSource(nameof(InvalidInputs))]
    public void TryParse_Should_Not_Parse_Invalid_Input(string input)
    {
        var success = Email.TryParse(input, out var email);

        success.Should().BeFalse();
        email.Should().BeNull();
    }

    [Test(Description = "Parse should not parse invalid input")]
    [TestCaseSource(nameof(InvalidInputs))]
    public void Parse_Should_Not_Parse_Invalid_Input(string? input)
    {
        Action act = () => Email.Parse(input!);

        if (input is null)
            act.Should().Throw<ArgumentNullException>();
        else
            act.Should().Throw<FormatException>();
    }

    [Test(Description = "Equals to Email should return true when other Email has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equals_To_Email_Should_Return_True_When_Other_Email_Has_Same_Value(string input)
    {
        var email1 = Email.Parse(input);
        var email2 = Email.Parse(input);

        email1.Equals(email2).Should().BeTrue();
    }

    [Test(Description =
        "Equality operators to Email should return true when other Email has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equality_Operators_To_Email_Should_Return_True_When_Other_Email_Has_Same_Value(string input)
    {
        var email1 = Email.Parse(input);
        var email2 = Email.Parse(input);

        (email1 == email2).Should().BeTrue();
        (email1 != email2).Should().BeFalse();
    }

    [Test(Description = "Equals to string should return true when other Email has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equals_To_String_Should_Return_True_When_Other_Email_Has_Same_Value(string input)
    {
        var email = Email.Parse(input);

        email.Equals(input).Should().BeTrue();
    }

    [Test(Description =
        "Equality operators to Email should return true when other Email has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equality_Operators_To_String_Should_Return_True_When_Other_Email_Has_Same_Value(string input)
    {
        var email = Email.Parse(input);

        (email == input).Should().BeTrue();
        (email != input).Should().BeFalse();
        (input == email).Should().BeTrue();
        (input != email).Should().BeFalse();
    }

    [Test(Description = "Implicit conversion to string should work")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Implicit_Conversion_To_String_Should_Work(string input)
    {
        var email = Email.Parse(input);
        string stringEmail = email;

        stringEmail.Should().Be(email.ToString());
    }

    [Test(Description = "Equals to Email edge cases should work")]
    [TestCase("test123@host.com", null, false)]
    [TestCase("test123@host.com", "hello@192.168.0.1", false)]
    public void Equals_To_Email_Edge_Cases_Should_Work(string input1, string? input2, bool equals)
    {
        var email1 = Email.Parse(input1);
        var email2 = input2 is not null ? Email.Parse(input2) : null;

        email1.Equals(email2).Should().Be(equals);
    }

    [Test(Description = "Equality operators to Email edge cases should work")]
    [TestCase(null, null, true)]
    [TestCase(null, "test123@host.com", false)]
    [TestCase("test123@host.com", null, false)]
    [TestCase("test123@host.com", "hello@192.168.0.1", false)]
    public void Equality_Operators_To_Email_Edge_Cases_Should_Work(string? input1, string? input2, bool equals)
    {
        var email1 = input1 is not null ? Email.Parse(input1) : null;
        var email2 = input2 is not null ? Email.Parse(input2) : null;

        (email1 == email2).Should().Be(equals);
    }

    [Test(Description = "Equals to string edge cases should work")]
    [TestCase("test123@host.com", null, false)]
    [TestCase("test123@host.com", "hello@192.168.0.1", false)]
    public void Equals_To_String_Edge_Cases_Should_Work(string input1, string? input2, bool equals)
    {
        var email = Email.Parse(input1);

        email.Equals(input2).Should().Be(equals);
    }

    [Test(Description = "Equality operators to string edge cases should work")]
    [TestCase(null, null, true)]
    [TestCase(null, "test123@host.com", false)]
    [TestCase("test123@host.com", null, false)]
    [TestCase("test123@host.com", "hello@192.168.0.1", false)]
    public void Equality_Operators_To_String_Edge_Cases_Should_Work(string? input1, string? input2, bool equals)
    {
        var email = input1 is not null ? Email.Parse(input1) : null;

        (email == input2).Should().Be(equals);
        (input2 == email).Should().Be(equals);
    }

    [Test(Description = "Should be able to serialize to JSON")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Should_Be_Able_To_Serialize_To_Json(string input)
    {
        var email = Email.Parse(input);
        var expected = $"\"{email}\"";
        var actual = JsonSerializer.Serialize(email);

        actual.Should().Be(expected);
    }

    [Test(Description = "Should be able to deserialize from JSON")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Should_Be_Able_To_Deserialize_From_Json(string input)
    {
        var expected = Email.Parse(input);
        var json = $"\"{expected}\"";
        var actual = JsonSerializer.Deserialize<Email>(json);

        actual.Should().Be(expected);
    }
}