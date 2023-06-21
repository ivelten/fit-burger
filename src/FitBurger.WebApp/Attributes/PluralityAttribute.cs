namespace FitBurger.WebApp.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class PluralityAttribute : Attribute
{
    public PluralityAttribute(string singular, string plural)
    {
        Singular = singular;
        Plural = plural;
    }

    public string Singular { get; init; }
    
    public string Plural { get; init; }
}