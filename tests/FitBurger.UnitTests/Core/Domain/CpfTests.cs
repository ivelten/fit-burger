using FitBurger.Core.Domain;
using FluentAssertions;

namespace FitBurger.UnitTests.Core.Domain;

public sealed class CpfTests
{
    public static readonly object[] ValidInputs =
    {
        "50802816770",
        "508.028.167-70",
        "26161321505",
        "261.613.215-05",
        "16947628741",
        "169.476.287-41"
    };

    public static readonly object?[] InvalidInputs =
    {
        null,
        "12345678901",
        ".Y_'zZ<WtFA2&hp",
        "50802816771",
        "508.028.167-71",
        "26161321503",
        "261.613.215-03",
        "16947628799",
        "169.476.287-99",
    };
    
    [Test(Description = "Input strings should be valid")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Input_Strings_Should_Be_Valid(string input)
    {
        Cpf.IsValidCpfString(input).Should().BeTrue();
    }
    
    [Test(Description = "TryParse should parse valid input")]
    [TestCaseSource(nameof(ValidInputs))]
    public void TryParse_Should_Parse_Valid_Input(string input)
    {
        var success = Cpf.TryParse(input, out var cpf);
        var expectedCpfValue = input.Length == 11 ? cpf.ToString(CpfFormatOptions.None) : cpf.ToString();

        success.Should().BeTrue();
        expectedCpfValue.Should().Be(input);
    }
    
    [Test(Description = "Parse should parse valid input")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Parse_Should_Parse_Valid_Input(string input)
    {
        var cpf = Cpf.Parse(input);
        var expectedCpfValue = input.Length == 11 ? cpf.ToString(CpfFormatOptions.None) : cpf.ToString();
        
        expectedCpfValue.Should().Be(input);
    }
    
    [Test(Description = "Input strings should be invalid")]
    [TestCaseSource(nameof(InvalidInputs))]
    public void Input_Strings_Should_Be_Invalid(string? input)
    {
        Cpf.IsValidCpfString(input).Should().BeFalse();
    }
    
    [Test(Description = "TryParse should not parse invalid input")]
    [TestCaseSource(nameof(InvalidInputs))]
    public void TryParse_Should_Not_Parse_Invalid_Input(string input)
    {
        var success = Cpf.TryParse(input, out var cpf);

        success.Should().BeFalse();
        cpf.Should().BeNull();
    }
    
    [Test(Description = "Parse should not parse invalid input")]
    [TestCaseSource(nameof(InvalidInputs))]
    public void Parse_Should_Not_Parse_Invalid_Input(string input)
    {
        Action act = () => Cpf.Parse(input);

        act.Should().Throw<FormatException>();
    }

    [Test(Description = "Equals to Cpf should return true when other Cpf has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equals_To_Cpf_Should_Return_True_When_Other_Cpf_Has_Same_Value(string input)
    {
        var cpf1 = Cpf.Parse(input);
        var cpf2 = Cpf.Parse(input);

        cpf1.Equals(cpf2).Should().BeTrue();
    }
    
    [Test(Description = "Equality operators to Cpf should return true when other Cpf has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equality_Operators_To_Cpf_Should_Return_True_When_Other_Cpf_Has_Same_Value(string input)
    {
        var cpf1 = Cpf.Parse(input);
        var cpf2 = Cpf.Parse(input);

        (cpf1 == cpf2).Should().BeTrue();
        (cpf1 != cpf2).Should().BeFalse();
    }
    
    [Test(Description = "Equals to string should return true when other Cpf has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equals_To_String_Should_Return_True_When_Other_Cpf_Has_Same_Value(string input)
    {
        var cpf = Cpf.Parse(input);

        cpf.Equals(input).Should().BeTrue();
    }
    
    [Test(Description = "Equality operators to Cpf should return true when other Cpf has the same value")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Equality_Operators_To_String_Should_Return_True_When_Other_Cpf_Has_Same_Value(string input)
    {
        var cpf = Cpf.Parse(input);

        (cpf == input).Should().BeTrue();
        (cpf != input).Should().BeFalse();
        (input == cpf).Should().BeTrue();
        (input != cpf).Should().BeFalse();
    }

    [Test(Description = "Implicit conversion to string should work")]
    [TestCaseSource(nameof(ValidInputs))]
    public void Implicit_Conversion_To_String_Should_Work(string input)
    {
        var cpf = Cpf.Parse(input);
        string stringCpf = cpf;

        stringCpf.Should().Be(cpf.ToString());
    }
    
    [Test(Description = "Equals to Cpf edge cases should work")]
    [TestCase("508.028.167-70", null, false)]
    [TestCase("508.028.167-70", "169.476.287-41", false)]
    public void Equals_To_Cpf_Edge_Cases_Should_Work(string input1, string? input2, bool equals)
    {
        var cpf1 = Cpf.Parse(input1);
        var cpf2 = input2 is not null ? Cpf.Parse(input2) : null;

        cpf1.Equals(cpf2).Should().Be(equals);
    }

    [Test(Description = "Equality operators to Cpf edge cases should work")]
    [TestCase(null, null, true)]
    [TestCase(null, "508.028.167-70", false)]
    [TestCase("508.028.167-70", null, false)]
    [TestCase("508.028.167-70", "169.476.287-41", false)]
    public void Equality_Operators_To_Cpf_Edge_Cases_Should_Work(string? input1, string? input2, bool equals)
    {
        var cpf1 = input1 is not null ? Cpf.Parse(input1) : null;
        var cpf2 = input2 is not null ? Cpf.Parse(input2) : null;

        (cpf1 == cpf2).Should().Be(equals);
    }
    
    [Test(Description = "Equals to string edge cases should work")]
    [TestCase("508.028.167-70", null, false)]
    [TestCase("508.028.167-70", "169.476.287-41", false)]
    public void Equals_To_String_Edge_Cases_Should_Work(string input1, string? input2, bool equals)
    {
        var cpf = Cpf.Parse(input1);

        cpf.Equals(input2).Should().Be(equals);
    }

    [Test(Description = "Equality operators to string edge cases should work")]
    [TestCase(null, null, true)]
    [TestCase(null, "508.028.167-70", false)]
    [TestCase("508.028.167-70", null, false)]
    [TestCase("508.028.167-70", "169.476.287-41", false)]
    public void Equality_Operators_To_String_Edge_Cases_Should_Work(string? input1, string? input2, bool equals)
    {
        var cpf = input1 is not null ? Cpf.Parse(input1) : null;

        (cpf == input2).Should().Be(equals);
        (input2 == cpf).Should().Be(equals);
    }
}